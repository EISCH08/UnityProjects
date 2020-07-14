
using UnityEngine;



public class BackGroundMovement : MonoBehaviour
{
    public GameObject menuCube;
    private GameObject[] brickList;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public int spawnRate;
    public int spawnLimit;
    // Start is called before the first frame update
 
    // Update is called once per frame
    void FixedUpdate()
    {
        //assigns rigidbody to cube
        Rigidbody rb = menuCube.GetComponent<Rigidbody>();
        //adds a force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        //cude dies
        if (rb.position.y < -1)
        {
            //limits the number of cubes spawned in at once
            brickList = GameObject.FindGameObjectsWithTag("MenuCube");
            if (brickList.Length < spawnLimit)
            {
                //spawns in s[awnRate additional cubes
                for (int i = 0; i < spawnRate; i++)
                {
                    Instantiate(menuCube, new Vector3(0, 1, 0), transform.rotation);
                }
            }
            
            Destroy(menuCube);
            

        }


    }
}
