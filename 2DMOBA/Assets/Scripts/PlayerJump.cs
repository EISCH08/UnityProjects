using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerMovement movement;
    public PlayerCollision playerCollision;
    public float jumpVelocity = 5f;
    public float quickFallVelocity = 4f;
    public float jumpSlowDown = 7f;
    public float fallMultiplier = 2.5f;
    public float wallSlideSpeedMax = 3;
    float wallStickTime = .25f;
    float timeToWallUnstick;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;
    bool fastFallCheck = false;
    public bool wallSliding = false;
    
   
    // Start is called before the first frame update
    void Start()
    {
        wallLeap.x = movement.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        //wall sliding
        wallSliding = false;
        if((playerCollision.rightTouched.Count!=0 || playerCollision.leftTouched.Count != 0) && rb.velocity.y < 0 )
        {
            wallSliding = true;
            
            if(rb.velocity.y < -wallSlideSpeedMax)
            {
                rb.velocity = new Vector3(0, -wallSlideSpeedMax, 0);
            }
            if (timeToWallUnstick > 0)
            {
                if(((playerCollision.rightTouched.Count != 0 && Input.GetKey("a")) && Input.anyKey) || ((playerCollision.leftTouched.Count != 0 && Input.GetKey("d")) && Input.anyKey))
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else 
                {
                    timeToWallUnstick = wallStickTime;
                }


            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (wallSliding)
            {   //wall climb
                fastFallCheck = true;
                if (playerCollision.rightTouched.Count != 0 )
                {
                    rb.velocity = new Vector3(-wallLeap.x, wallLeap.y, 0);
                }
                if (playerCollision.leftTouched.Count != 0 )
                {
                    rb.velocity = new Vector3(wallLeap.x, wallLeap.y, 0);
                }



            }
            //regular jump
            if (playerCollision.groundTouched.Count != 0)
            {
                fastFallCheck = true;
                rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
                

            }




        }
        //quick fall
        if (Input.GetKeyDown("s") && playerCollision.groundTouched.Count == 0 && fastFallCheck && rb.velocity.y >0)
        {
            rb.velocity =new Vector3(rb.velocity.x, 0, 0);
            fastFallCheck = false;
        }

    }
    private void FixedUpdate()
    {

        
        
        //rising
        if(rb.velocity.y>0)
        {

            rb.velocity += Vector3.up * -jumpSlowDown * Time.deltaTime;
        }



        //falling
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        

    }

    

}

