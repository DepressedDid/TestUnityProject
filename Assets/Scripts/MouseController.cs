using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Camera mainCamera;
    private Rigidbody playerRigidbody;
    public Transform AxisEmpty;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //RotationToCursor();
    }
    void FixedUpdate()
    {
        RotationToCursor();
    }
    private Vector3 GetCursorPositionInWorld()
    {
        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition.z = mainCamera.transform.position.y;
        return AxisEmpty.InverseTransformPoint(mainCamera.ScreenToWorldPoint(cursorPosition));
    }

    private Vector3 ObjectToCursorVectorCalculate()
    {
        return GetCursorPositionInWorld() - Vector3.zero;
    }

    private void RotationToCursor()
    {
        Vector3 result = ObjectToCursorVectorCalculate();
        result.Normalize();
        float angle = Vector3.Angle(AxisEmpty.forward, result);
        if (ObjectToCursorVectorCalculate().x<0)
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(90f,0f,angle));
            playerRigidbody.rotation = deltaRotation;
        }
        else if(ObjectToCursorVectorCalculate().x>0)
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(90f,0f,-angle));
            playerRigidbody.rotation=deltaRotation;
        }
        
    }
}
