using UnityEngine;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Rigidbody rb;
    public PlayerCollision playerCollision;
    public float movementSpeed = 200f;
    public float maxSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector3(movementSpeed, rb.velocity.y,0);
            if (playerCollision.wallTouched.Count != 0)
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector3(-movementSpeed, rb.velocity.y, 0);
        }
        


    }
}
