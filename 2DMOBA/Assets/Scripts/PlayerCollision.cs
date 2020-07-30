using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody rb;
    public List<Collider> wallTouched = new List<Collider>();
    public List<Collider> leftTouched = new List<Collider>();
    public List<Collider> rightTouched = new List<Collider>();
    public List<Collider> groundTouched = new List<Collider>();
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] points = new ContactPoint[2];
        collision.GetContacts(points);
        for (int i = 0; i < points.Length; i++)
        {
            //if colliding with the wall
            //check right side
            if (points[i].normal == Vector3.right && !wallTouched.Contains(collision.collider))
            {
                wallTouched.Add(collision.collider);
                leftTouched.Add(collision.collider);
                
                return;
            }
            //check left side
            if (points[i].normal == Vector3.left && !wallTouched.Contains(collision.collider))
            {
                wallTouched.Add(collision.collider);
                rightTouched.Add(collision.collider);
                
                return;
            }

            //if colliding with the ground
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
        if (rightTouched.Contains(collision.collider))
        {
            rightTouched.Remove(collision.collider);
        }
        if (leftTouched.Contains(collision.collider))
        {
            leftTouched.Remove(collision.collider);
        }
        if (groundTouched.Contains(collision.collider))
        {
            groundTouched.Remove(collision.collider);
        }
    }
}
