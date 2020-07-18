
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 4f;
    public float screenPixelBuffer = 20f;
    public float xMovementDistance = 20f;
    public float yMovementDistance = 20f;
    private Vector3 anchorMousePos;
    private bool mouse2refresh = true;
    
    public Camera mainCamera;
    

    // Start is called before the first frame update
    void Start()
    {
       anchorMousePos= Input.mousePosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
 

        Vector3 cameraMovement = new Vector3(0f, 0f, 0f);
        Vector3 mousePos = Input.mousePosition;
        float mouseXAdjust = mousePos.x - Screen.width / 2 ;
        float mouseYAdjust = mousePos.y - Screen.height / 2 ;
        Vector3 oldpos = transform.position;



        if (Input.GetKey(KeyCode.Mouse2))
        {
            if(mouse2refresh)
            {
                oldpos = transform.position;
                anchorMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
               
                Debug.Log("ANCHOR:" + anchorMousePos);
               
                
                mouse2refresh = false;
            }

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - anchorMousePos;
            Vector3 viewPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if ( viewPoint.x > .1 && viewPoint.x < .9 && viewPoint.y > .1 && viewPoint.y < .9 )
            {
                transform.position = oldpos + -pos * (cameraSpeed * Time.deltaTime) * 2;
                
            }
            else
            {
                Debug.Log("MOUSE ABOUT TO GO OFF SCREEN");
            }




            //transform.position = oldpos + -pos * (cameraSpeed * Time.deltaTime) * 2;

            


            




            



        }
        
        

        else
        {
            mouse2refresh = true;
            if (mousePos.x < screenPixelBuffer)
            {
                cameraMovement+= new Vector3(-xMovementDistance, mouseYAdjust/10, 0);
            }
            if (mousePos.x > Screen.width - screenPixelBuffer)
            {

                cameraMovement += new Vector3(xMovementDistance, mouseYAdjust / 10, 0);

            }
            if (mousePos.y < screenPixelBuffer)
            {
                cameraMovement += new Vector3(mouseXAdjust / 10, -yMovementDistance, 0);
            }
            if (mousePos.y > Screen.height - screenPixelBuffer)
            {

                cameraMovement += new Vector3(mouseXAdjust / 10, yMovementDistance, 0);

            }
            transform.position = Vector3.MoveTowards(mainCamera.transform.position, transform.position + cameraMovement, cameraSpeed * Time.deltaTime);


        }





    }
}

