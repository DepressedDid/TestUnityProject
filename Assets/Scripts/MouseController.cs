using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseController : MonoBehaviour
{
    public Camera mainCamera;
    private Rigidbody playerRigidbody;
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
   
    }
    void FixedUpdate()
    {
        RotationToCursor();
    }
    private Vector3 GetCursorPositionInWorld()
    {
        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition.z = mainCamera.transform.position.y;
        Vector3 worldCoordinate = mainCamera.ScreenToWorldPoint(cursorPosition);
        Vector3 playerPosition = transform.position;
        playerPosition.y = 0;
        Vector3 localCoordinate = worldCoordinate - playerPosition;
        return localCoordinate;
    }
    private Vector3 ObjectToCursorVectorCalculate()
    {
        return GetCursorPositionInWorld() - Vector3.zero;
    }
    private void RotationToCursor()
    {
        Vector3 result = ObjectToCursorVectorCalculate();
        result.Normalize();
        float angle = Vector3.SignedAngle(Vector3.forward, result, Vector3.up);
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(90f,0f,-angle));
        playerRigidbody.rotation = deltaRotation;
    }
}
