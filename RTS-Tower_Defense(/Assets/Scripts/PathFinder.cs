using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    
    [SerializeField] Block _startPoint,_endPoint;
    Block _searchCenter;

    Dictionary<Vector2Int,Block> _grid = new Dictionary<Vector2Int, Block>();
    Queue<Block> _queue = new Queue<Block>();
    List<Block> _path = new List<Block>(); 

    bool _isRunning = true;

    Vector2Int[] _directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    void Start()
    {
        LoadBlocks();
        //SetColorStartAndEnd();
    }
    
    void SetColorStartAndEnd()
    {
        _startPoint.SetColor(Color.green);
        _endPoint.SetColor(Color.red);
    }

    void LoadBlocks()
    {
        var Blocks = FindObjectsOfType<Block>();
        foreach(Block block in Blocks)
        {
            bool exists = _grid.ContainsKey(block.GetGridPose());
            if(!exists)
            {
                _grid.Add(block.GetGridPose(),block);  
            }
            else{
                Debug.LogWarning("Removed overlaping block => "+block.name);
                Destroy(block.gameObject);
            }
        }
    }

    void Searching()
    {
        _queue.Enqueue(_startPoint);
        while(_queue.Count > 0 && _isRunning)
        {
            _searchCenter = _queue.Dequeue();
            _searchCenter._isExplored = true;
            HaltIfEndPointFound(_searchCenter);
            ExploreNeighbors();
        }
    }

    void CreatePath()
    {
        Block Previous = _endPoint;
        while(Previous != _startPoint)
        {
            _path.Add(Previous);
            Previous = Previous._exploredFrom;
        }
        _path.Add(_startPoint);
        _path.Reverse();
        
    }

    public List<Block> GetPath()
    {
        Searching();
        CreatePath();
        return _path;
    }

    void ExploreNeighbors()
    {
        if(!_isRunning){return;}
        foreach (Vector2Int direction in _directions)
        {
            Vector2Int Pos = _searchCenter.GetComponent<Block>().GetGridPose() + direction;
            if(_grid.ContainsKey(Pos))
            {
                QueueBlock(Pos);
            }
        }
    }

    void QueueBlock(Vector2Int Pos)
    {
        Block Neighbour = _grid[Pos];
        if(!Neighbour._isExplored && !_queue.Contains(Neighbour))
        {
            _queue.Enqueue(Neighbour);
            Neighbour._exploredFrom = _searchCenter;
        }    
    }

    void HaltIfEndPointFound(Block block)
    {
        if(block == _endPoint)
        {
            _isRunning = false;
            print("Endpoint found!! => "+block.name);
        }
    }

}
