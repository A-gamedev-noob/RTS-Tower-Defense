using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    
    Dictionary<Vector2Int,Block> _grid = new Dictionary<Vector2Int, Block>();
    [SerializeField] GameObject _startPoint,_endPoint;

    void Start()
    {
        LoadBlocks();
        SetColorStartAndEnd();
    }

    void SetColorStartAndEnd()
    {
        _startPoint.GetComponent<Block>().SetColor(Color.green);
        _endPoint.GetComponent<Block>().SetColor(Color.red);
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
                Destroy(block.gameObject);
            }
        }
    }

}
