using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerCollision playerCollision;
    public float jumpVelocity = 5f;
    public float jumpSlowDown = 7f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool jumpRequest = false;
    public bool wallJump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //regular jump
        if(Input.GetKeyDown(KeyCode.Space) && playerCollision.groundTouched.Count != 0)
        {
            jumpRequest = true;
            wallJump = false;
        }
        //wall jump
        if (Input.GetKeyDown(KeyCode.Space) && (playerCollision.groundTouched.Count == 0 && playerCollision.wallTouched.Count != 0))
        {
            wallJump = true;
        }

    }
    private void FixedUpdate()
    {
        if (jumpRequest)
        {
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            jumpRequest = false;
            wallJump = false;
        }
        if(wallJump)
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

