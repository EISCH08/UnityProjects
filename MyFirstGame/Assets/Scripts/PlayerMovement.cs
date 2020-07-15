
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce = 500f;
    private bool playerJumped = false;
   
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y <= 1.1)
        {
            playerJumped = false;
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }
        if(rb.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        if (Input.GetKey("space"))
        {
            if (playerJumped == false)
            {
                Debug.Log("Player Jumped");
               rb.AddForce(0, jumpForce * Time.deltaTime,0);
                playerJumped = true;
            }
        }

        

    }
}
