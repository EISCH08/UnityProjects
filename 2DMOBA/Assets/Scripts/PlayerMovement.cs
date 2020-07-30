using UnityEngine;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Rigidbody rb;
    public PlayerCollision playerCollision;
    public float movementSpeed = 10f;
    public float slowDownSpeed = 2f;
    public float maxSpeed = 10;
    public float airControl = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    // Controls the left and right movement for the player. 

    void Update()
    {
         
        if (playerCollision.rightTouched.Count == 0)
        {
            if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            {
                rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, 0);
            }
            if (Input.GetKey("d") && Mathf.Abs(rb.velocity.x) <= maxSpeed)
            {
                //On Ground Movement
                if (playerCollision.groundTouched.Count != 0)
                {
                    rb.velocity += Vector3.right * movementSpeed * Time.deltaTime;
                }
                //In Air Movement
                else
                {
                    
                    rb.velocity = new Vector3(rb.velocity.x + (airControl * Time.deltaTime), rb.velocity.y, 0);
                }
                

            }
            //ground slow down
            else if (playerCollision.groundTouched.Count != 0 && rb.velocity.x > 0)
            {
                rb.velocity += new Vector3(-slowDownSpeed * Time.deltaTime, 0, 0);
            }
        }

        if (playerCollision.leftTouched.Count == 0)

        {
            if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            {
                rb.velocity = new Vector3(maxSpeed, rb.velocity.y, 0);
            }
            if (Input.GetKey("a") && Mathf.Abs(rb.velocity.x) <= maxSpeed)
            {
                //On Ground Movement
                if(playerCollision.groundTouched.Count != 0)
                {
                    rb.velocity += Vector3.left * movementSpeed * Time.deltaTime;
                }
                //In Air Movement
                else
                {
                    rb.velocity = new Vector3(rb.velocity.x - (airControl * Time.deltaTime), rb.velocity.y,0);
                }
                

            }
            //ground slow down
            else if (playerCollision.groundTouched.Count != 0 && rb.velocity.x < 0)
            {
                rb.velocity += new Vector3(slowDownSpeed * Time.deltaTime, 0, 0);
            }


        }
        
        
        
        
            

        



    }
}
