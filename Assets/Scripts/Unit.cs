using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    GridPosition currentGridPosition;
    MoveAction moveAction;
    SpinAction spinAction;
    BaseAction[] baseActionArray;

    private void Awake() 
    {
        moveAction = GetComponent<MoveAction>();
        spinAction = GetComponent<SpinAction>();
        baseActionArray = GetComponents<BaseAction>();
    }

    void Start() 
    {
        currentGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(currentGridPosition, this);    
    }

    void Update()
    {

        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if(newGridPosition != currentGridPosition)
        {
            LevelGrid.Instance.UnitMovedGridPosition(this, currentGridPosition, newGridPosition);
            currentGridPosition = newGridPosition;
        }
    }

    public MoveAction GetMoveAction()
    {
        return moveAction;
    }

    public SpinAction GetSpinAction()
    {
        return spinAction;
    }

    public GridPosition GetGridPosition()
    {
        return currentGridPosition;
    }

    public BaseAction[] GetBaseActionArray()
    {
        return baseActionArray;
    }

}
