using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
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
            if(_txtMesh != null)
            {
                LabelText();
            }
        }
    }

    private void LabelText()
    {
        int GridSize = block.GetGridSize();
        Vector2 GridPos = block.GetGridPose();
        string LocTxt = GridPos.x + "," + GridPos.y ; ;
        _txtMesh.text = LocTxt;
        transform.name = "Cube (" + GridPos.x + "," + GridPos.y + ")";
    }

    private void SnapToGrid()
    {
        int GridSize = block.GetGridSize();
        Vector2 GridPos = block.GetGridPose(); 
        transform.position = new Vector3(GridPos.x * GridSize, 0f,GridPos.y * GridSize);
    }
}
