using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RotationToCursor();
    }
    private Vector3 GetCursorPositionInWorld()
    {
        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition.z = mainCamera.transform.position.y;
        return transform.parent.InverseTransformPoint(mainCamera.ScreenToWorldPoint(cursorPosition));
    }

    private Vector3 ObjectToCursorVectorCalculate()
    {
        return GetCursorPositionInWorld() - Vector3.zero;
    }

    private void RotationToCursor()
    {
        Vector3 result = ObjectToCursorVectorCalculate();
        result.Normalize();
        float angle = Vector3.Angle(transform.parent.forward, result);
        if (ObjectToCursorVectorCalculate().x<0)
        {
            gameObject.transform.eulerAngles = new Vector3(90f,0f,angle) ; 
        }
        else if(ObjectToCursorVectorCalculate().x>0)
        {
            gameObject.transform.eulerAngles = new Vector3(90f,0f,-angle) ;
        }
        
    }
}
