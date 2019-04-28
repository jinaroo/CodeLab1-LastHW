using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    public float speed = 1f;
    public float orbitRadius = 5.5f;
    public float turnSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 forwardDir = transform.forward;

            if (Input.GetKey(KeyCode.D))
            {
//                forwardDir = Quaternion.AngleAxis(turnSpeed * Time.deltaTime, transform.up) * forwardDir;
            }
            
            Vector3 targetPos = transform.position + forwardDir * speed * Time.deltaTime; // where we are now plus where we want to be
           
            Vector3 targetMoveDir = targetPos - transform.position; // b - a

            Vector3 newUp = transform.position.normalized * orbitRadius; // fixed length vector that points out from the sphere
            
            Vector3 newRight = Vector3.Cross(targetMoveDir, newUp).normalized; // always points towards the right
        
            transform.forward = Vector3.Cross(newUp, newRight).normalized; // movement direction tangent to sphere

            transform.position += forwardDir * speed * Time.deltaTime; // move in the correct direction

            transform.position = transform.position.normalized * orbitRadius; // stops him from flying away by sticking to orbitRadius

            transform.up = newUp.normalized; // keeps him oriented upwards
        }

        if (Input.GetKey(KeyCode.D))
        {
            // none of the below rotates the player properly
//            transform.RotateAround(transform.up, turnSpeed * Time.deltaTime);
//            transform.RotateAround(transform.position, transform.up, turnSpeed * Time.deltaTime);
//            transform.Rotate(transform.up, turnSpeed * Time.deltaTime, Space.Self);
//            transform.forward = Quaternion.AngleAxis(turnSpeed * Time.deltaTime, Vector3.up) * transform.forward; // rotate player around transform.up
        }
    }
}
