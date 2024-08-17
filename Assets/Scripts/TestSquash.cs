using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSquash : MonoBehaviour
{
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            Squashable.ToggleSquash(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            Squashable.ToggleSquash(transform.position, true);
        }

        var speed = 3.0f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * (Time.deltaTime * speed);
        } 
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * (Time.deltaTime * speed);
        } 
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * (Time.deltaTime * speed);
        } 
        
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * (Time.deltaTime * speed);
        } 
    }
}
