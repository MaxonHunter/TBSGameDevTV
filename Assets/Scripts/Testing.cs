using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    
    [SerializeField] Unit unit;
    
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            GridSystemVisual.Instance.HideAllGridPositions();
            GridSystemVisual.Instance.ShowGridPositionList(
                unit.GetMoveAction().GetValidActionGridPositionList());
        }
    }
}
