using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyBoardController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody playerRigidbody;

    public Transform emptyTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        KeyBoardMoving();
    }

    void KeyBoardMoving()
    {
        float directionVertical = Input.GetAxis("Vertical");
        float directionHorizontal = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = (new Vector3(directionHorizontal, 0f, directionVertical) * Time.fixedDeltaTime * speed);
        emptyTransform.position = playerRigidbody.position;
    }
}
