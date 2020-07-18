using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody rb;
    public List<Collider> wallTouched = new List<Collider>();
    public List<Collider> groundTouched = new List<Collider>();
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] points = new ContactPoint[2];
        collision.GetContacts(points);
        for (int i = 0; i < points.Length; i++)
        {
            //if colliding with the ground
            if ((points[i].normal == Vector3.right || points[i].normal == Vector3.left) && !wallTouched.Contains(collision.collider))
            {
                wallTouched.Add(collision.collider);
                Debug.Log("wall Touched");
                return;
            }
            if (points[i].normal == Vector3.up && !groundTouched.Contains(collision.collider))
            {
                groundTouched.Add(collision.collider);
                return;
            }
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (wallTouched.Contains(collision.collider))
        {
            wallTouched.Remove(collision.collider);
        }
        if (groundTouched.Contains(collision.collider))
        {
            groundTouched.Remove(collision.collider);
        }
    }
}
