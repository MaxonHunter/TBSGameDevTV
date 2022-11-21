/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{

    [SerializeField] Animator unitAnimator;
    Vector3 targetPosition;

    void Awake()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveUnit();
    }
        private void MoveUnit()
    {
        float stoppingDistance = 0.1f;

        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
            
            float rotateSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
            unitAnimator.SetBool("isMoving", true);
        }
        else
        {
            unitAnimator.SetBool("isMoving", false);
        }
    }
        public Vector3 Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
        return targetPosition;
    }


}*/
