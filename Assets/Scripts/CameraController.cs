using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera virtualCamera;
    Vector3 inputMoveDirection;
    Vector3 rotationDirection;
    Vector3 targetFollowOffset;
    CinemachineTransposer transposer;
    const float MIN_FOLLOWY_OFFSET = 2f;
    const float MAX_FOLLOWY_OFFSET = 12f;
   float moveSpeed = 10f;
   float rotationSpeed = 150f;
   float zoomSpeed = 3f;
    float zoomAmount = 1f;


   void Start() 
   {
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        targetFollowOffset = transposer.m_FollowOffset;
   }
    void Update()
    {
        MoveCamera();
        RotateCamera(); 
        ZoomCamera();
    }

    private void MoveCamera()
    {

       if(Input.GetKey(KeyCode.A))
       {
            inputMoveDirection = Vector3.left;
            transform.Translate(inputMoveDirection * moveSpeed * Time.deltaTime);
       }
              if(Input.GetKey(KeyCode.D))
       {
            inputMoveDirection = Vector3.right;
            transform.Translate(inputMoveDirection * moveSpeed * Time.deltaTime);
       }
              if(Input.GetKey(KeyCode.W))
       {
            inputMoveDirection = Vector3.forward;
            transform.Translate(inputMoveDirection * moveSpeed * Time.deltaTime);
       }
              if(Input.GetKey(KeyCode.S))
       {
            inputMoveDirection = Vector3.back;
            transform.Translate(inputMoveDirection * moveSpeed * Time.deltaTime);
       }
    }

    void RotateCamera()
    {
        if(Input.GetKey(KeyCode.Q))
       {
            rotationDirection = Vector3.up;
            transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
       }
        if(Input.GetKey(KeyCode.E))
       {
            rotationDirection = Vector3.down;
            transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
       }

    }

    void ZoomCamera()
    {
       
        if(Input.mouseScrollDelta.y > 0)
        {
            targetFollowOffset.y -= zoomAmount;
        }
        if(Input.mouseScrollDelta.y < 0)
        {
            targetFollowOffset.y += zoomAmount;
        }

        targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, MIN_FOLLOWY_OFFSET, MAX_FOLLOWY_OFFSET);
        transposer.m_FollowOffset = Vector3.Lerp(transposer.m_FollowOffset, targetFollowOffset, zoomSpeed * Time.deltaTime);

    }
}
