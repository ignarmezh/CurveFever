﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

    public float speed = 3f;
    public float rotationSpeed = 200f;

    public string inputAxis = "Horizontal";

    float horizontal = 0f;
	
	// Update is called once per frame
	void Update () {
        horizontal = Input.GetAxisRaw(inputAxis);
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime,Space.Self);
        transform.Rotate(Vector3.forward * -horizontal * rotationSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);
    }
}
