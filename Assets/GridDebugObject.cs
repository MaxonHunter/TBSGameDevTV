using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{

    [SerializeField] TextMeshPro textMeshPro;
    GridObject gridObject;
    
    void Update() 
    {
        textMeshPro.text = gridObject.ToString();
    }
    
    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
    }
}
