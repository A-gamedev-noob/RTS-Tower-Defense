using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    
    [SerializeField] Block _startPoint,_endPoint;
    Dictionary<Vector2Int,Block> _grid = new Dictionary<Vector2Int, Block>();
    Queue<Block> queue = new Queue<Block>();
    Block _searchCenter;
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
        SetColorStartAndEnd();
        FindPath();
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
                print("Removed overlaping block => "+block.name);
                Destroy(block.gameObject);
            }
        }
    }

    void FindPath()
    {
        queue.Enqueue(_startPoint);
        while(queue.Count > 0 && _isRunning)
        {
            _searchCenter = queue.Dequeue();
            print("Searching from => "+_searchCenter.name);
            _searchCenter._isExplored = true;
            HaltIfEndPointFound(_searchCenter);
            ExploreNeighbors();
        }
    }

    void ExploreNeighbors()
    {
        if(!_isRunning){return;}
        foreach (Vector2Int direction in _directions)
        {
            Vector2Int Pos = _searchCenter.GetComponent<Block>().GetGridPose() + direction;
            try
            {
                QueueBlock(Pos);
            }    
            catch
            {
                
            }
        }
    }

    void QueueBlock(Vector2Int Pos)
    {
        Block Neighbour = _grid[Pos];
        if(!Neighbour._isExplored && !queue.Contains(Neighbour))
        {
            Neighbour.SetColor(Color.blue);
            queue.Enqueue(Neighbour);
            Neighbour._exploredFrom = _searchCenter;
            print("Queueing " + Neighbour.name);
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
