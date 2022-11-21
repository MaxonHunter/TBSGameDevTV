using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitSelectedVisual : MonoBehaviour
{

    [SerializeField] Unit unit;
    MeshRenderer meshRenderer;

    private void Awake() 
    {
        meshRenderer = GetComponent<MeshRenderer>();    
    }

    void Start() 
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UpdateVisual();
    }

    void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (UnitActionSystem.Instance.GetSelectedUnit() == unit)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }
}
