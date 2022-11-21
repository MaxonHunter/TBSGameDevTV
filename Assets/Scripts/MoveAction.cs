using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveAction : BaseAction
{

    [SerializeField] Animator unitAnimator;
    [SerializeField] int maxMoveDistance = 4;
    Vector3 targetPosition;

    protected override void Awake()
    {
        base.Awake();
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveUnit();
    }
        private void MoveUnit()
    {
        
        if(!isActive) { return; }

        float stoppingDistance = 0.1f;
        
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            float moveSpeed = 4f;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
            
            unitAnimator.SetBool("isMoving", true);
        }
        else
        {
            unitAnimator.SetBool("isMoving", false);
            isActive = false;
            onActionComplete();
        }
        
        float rotateSpeed = 10f;
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

    }
        public override void TakeAction(GridPosition targetPosition, Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        this.targetPosition = LevelGrid.Instance.GetWorldPosition(targetPosition);
        isActive = true;
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitGridPostion = unit.GetGridPosition();

        for(int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for(int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridPostion + offsetGridPosition;
                if(!LevelGrid.Instance.IsValidGridPostion(testGridPosition)) { continue; }
                if(testGridPosition == unitGridPostion) { continue; }
                if(LevelGrid.Instance.HasAUnitAtGridPosition(testGridPosition)) { continue; }
                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }

    public override string GetActionName()
    {
        return "Move";
    }

}
