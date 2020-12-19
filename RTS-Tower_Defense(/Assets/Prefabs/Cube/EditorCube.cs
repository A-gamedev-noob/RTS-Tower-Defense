using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorCube : MonoBehaviour
{
    [Range(1f,20f)]
    [SerializeField] int _gridSize = 10;
    [SerializeField] bool _snap = true;
    [SerializeField] TextMesh _txtMesh;

    void Update()
    {
        if(_snap)
        {
            Vector3 SnaPos;
            SnaPos.x = Mathf.RoundToInt(transform.position.x / _gridSize) * _gridSize;
            SnaPos.z = Mathf.RoundToInt(transform.position.z / _gridSize) * _gridSize;

            _txtMesh.text = SnaPos.x/_gridSize + "," + SnaPos.z/_gridSize;

            transform.position = new Vector3(SnaPos.x,0f,SnaPos.z);
        }
    }
}
