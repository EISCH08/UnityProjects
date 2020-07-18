﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCubeMovement : MonoBehaviour
{
    public float speed = 5f;
    //adjust this to change how high it goes
    public float height = 0.5f;
    private void Start()
    {
        height = Random.Range(0f, height);
        speed = Random.Range(1,speed);

    }
    void Update()
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        Vector3 pos = transform.position;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, newY * height, pos.z) ;
    }

}