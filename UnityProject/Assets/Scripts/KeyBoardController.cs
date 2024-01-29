using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyBoardController : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyBoardMoving();
    }
    void KeyBoardMoving()
    {
        float direction = Input.GetAxis("Horizontal");
        Vector3 convertedHorizontalVector = transform.InverseTransformDirection(new Vector3(1, 0, 0) );
        transform.Translate( convertedHorizontalVector * Time.deltaTime * speed * direction);
        direction = Input.GetAxis("Vertical");
        Vector3 convertedVerticalVector = transform.InverseTransformDirection(new Vector3(0, 0, 1) );
        transform.Translate( convertedVerticalVector * Time.deltaTime * speed * direction);
    }
}
