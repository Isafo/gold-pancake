﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 1.0f;
    public float JumpSpeed = 100.0f;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            Debug.Log(Input.GetAxis("Horizontal"));
            rb.AddForce(Vector2.up * JumpSpeed);
        }
	}
}