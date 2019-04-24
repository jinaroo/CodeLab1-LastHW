using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // get mouse input
        float horizontalMouseSpeed = Input.GetAxis("Mouse X");
        float verticalMouseSpeed = Input.GetAxis("Mouse Y");
        
        // use mouse input to rotate camera
        transform.Rotate(0f, horizontalMouseSpeed, 0f);
        Camera.main.transform.Rotate(-verticalMouseSpeed, 0f, 0f);
        
        // unroll the camera
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y);
    }
}
