using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Block> _pathWay;
    [SerializeField] float _travelSpeed = 0.2f;
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        _pathWay = pathFinder.GetPath();
        StartCoroutine(Traversal(_pathWay));
    }


    IEnumerator Traversal(List<Block> path)
    {
        foreach(Block block in path)
        {
            transform.position = new Vector3(block.transform.position.x,0f,block.transform.position.z);
            yield return new WaitForSeconds(_travelSpeed);
        }
    }
    

}
