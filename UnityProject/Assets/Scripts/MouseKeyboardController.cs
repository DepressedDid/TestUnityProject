using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseKeyboardController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyBoardMoving();
        var mouse = Input.mouseScrollDelta;
        Debug.Log(mouse);
    }


    void KeyBoardMoving()
    {
        float direction = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(1,0,0) * Time.deltaTime * speed * direction);
        direction = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0,1,0) * Time.deltaTime * speed * direction);
    }
}
