using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    private float cameraYPosition;
    private Rigidbody camera;
    // Start is called before the first frame update
    void Start()
    {
        cameraYPosition = transform.position.y - playerTransform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        CameraFollowing();
    }

    private void CameraFollowing()
    {
        Vector3 playert = playerTransform.position;
        playert.y += cameraYPosition;
        transform.position = playert;
    }
}
