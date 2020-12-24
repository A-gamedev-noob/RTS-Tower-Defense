using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

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
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / _gridSize) * _gridSize,
            Mathf.RoundToInt(transform.position.z / _gridSize) * _gridSize);
    }

    public void SetColor(Color color)
    {
        MeshRenderer renderer =  transform.Find("Top").GetComponent<MeshRenderer>();
        renderer.material.color = color;
    }
    
}
