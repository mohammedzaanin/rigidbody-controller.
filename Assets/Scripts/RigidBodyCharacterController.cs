using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyCharacterController : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 input;
    bool jump = false;
    float battahSpeed = 5f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
    }

    void Update()
    {
        input = new Vector3(-Input.GetAxisRaw("Horizontal"),
                            0,
                            -Input.GetAxisRaw("Vertical"));
        input = input.normalized * battahSpeed;

        input.y = rigidbody.velocity.y;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            rigidbody.drag = 0.5f;
            rigidbody.AddForce(Vector3.up * 6, ForceMode.Impulse);
            jump = false;
        }
        else
        {
            rigidbody.drag = 0;
            rigidbody.velocity = input;
        }
    }
}
