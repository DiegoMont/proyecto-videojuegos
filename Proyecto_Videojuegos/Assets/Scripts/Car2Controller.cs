﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2Controller : MonoBehaviour
{

	Rigidbody2D rb;

	[SerializeField]
	float accelerationPower = 5f;
	[SerializeField]
	float steeringPower = 5f;
	float steeringAmount, speed, direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() {

    	steeringAmount = - Input.GetAxis("HorizontalPersonal");
    	speed = Input.GetAxis("VerticalPersonal")*accelerationPower;
    	direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
    	rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

    	rb.AddRelativeForce(Vector2.up * speed);
    	rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
    }
}
