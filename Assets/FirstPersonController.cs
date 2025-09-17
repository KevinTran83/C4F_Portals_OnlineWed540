using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 10, lookSpeed = 150, jumpSpeed = 25;
    public Transform head;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        if ( Input.GetAxis("Jump") != 0
          && Physics.Raycast(transform.position-transform.up, -transform.up, 1)
           ) Jump();
        Move();
    }

    private void Look()
    { 
        transform.Rotate(0,
                         Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime,
                         0);
        head.Rotate     (-Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime,
                         0,
                         0);
    }

    private void Jump() { Vector3 temp = rb.velocity;
                          temp.y       = jumpSpeed;
                          rb.velocity  = temp;
                        }

    private void Move()
    {
        Vector3 forwardDir = transform.forward * Input.GetAxis("Vertical");
        Vector3 rightDir   = transform.right   * Input.GetAxis("Horizontal");

        float velY = rb.velocity.y;

        Vector3 velocity = (forwardDir + rightDir).normalized * moveSpeed;
        velocity.y = velY;

        rb.velocity = velocity;
    }
}
