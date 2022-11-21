using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{

    protected Action onActionComplete;
    protected Unit unit;
    protected bool isActive;
    protected int actionPointCost = 1;

    protected virtual void Awake() 
    {
        unit = GetComponent<Unit>();    
    }

    public virtual bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
        return validGridPositionList.Contains(gridPosition);

    }

    public virtual int GetActionPointCost()
    {
        return actionPointCost;
    }


    public abstract string GetActionName();
    public abstract void TakeAction(GridPosition gridPosition, Action onActionComplete);
    public abstract List<GridPosition> GetValidActionGridPositionList();



}
