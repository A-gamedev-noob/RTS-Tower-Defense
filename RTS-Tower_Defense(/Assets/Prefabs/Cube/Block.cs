using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public bool _isExplored = false;
    public Block _exploredFrom;

    Vector2Int _gridPose;
    const int _gridSize = 10;

    void Start()
    {
        
    }

    public int GetGridSize()
    {
        return _gridSize;
    }

    public Vector2Int GetGridPose()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / _gridSize),
            Mathf.RoundToInt(transform.position.z / _gridSize));
    }

    public void SetColor(Color color)
    {
        MeshRenderer renderer =  transform.Find("Top").GetComponent<MeshRenderer>();
        renderer.material.color = color;
    }
    
}
