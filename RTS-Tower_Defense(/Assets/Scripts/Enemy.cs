using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Block> _blocks;
    [SerializeField] float _travelSpeed = 0.2f;
    void Start()
    {
        StartCoroutine(Traversal());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Traversal()
    {
        foreach(Block block in _blocks)
        {
            transform.position = new Vector3(block.transform.position.x,0f,block.transform.position.z);
            yield return new WaitForSeconds(_travelSpeed);
        }
    }

}
