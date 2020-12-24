using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorCube : MonoBehaviour
{
    [SerializeField] bool _snap = true;
    [SerializeField] TextMesh _txtMesh;
    Block block;

    void Awake() 
    {
        block = GetComponent<Block>();
    }

    void Update()
    {
        if(_snap)
        {
            SnapToGrid();
            LabelText();
        }
    }

    private void LabelText()
    {
        int GridSize = block.GetGridSize();
        Vector2 GridPos = block.GetGridPose();
        string LocTxt = GridPos.x / GridSize + "," + GridPos.y / GridSize; ;
        _txtMesh.text = LocTxt;
        transform.name = "Cube (" + GridPos.x / GridSize + "," + GridPos.y / GridSize + ")";
    }

    private void SnapToGrid()
    {
        int GridSize = block.GetGridSize();
        Vector2 GridPos = block.GetGridPose(); 
        transform.position = new Vector3(GridPos.x, 0f,GridPos.y);
    }
}
