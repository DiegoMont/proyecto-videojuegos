﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceAmbulanceController : MonoBehaviour
{
    
	public Transform target;
	public Vector3 _target;
	public float Speed;
	public GameObject ObjectToRotate;
    public float DegreesOffset = 0;
    // Start is called before the first frame update
    void Start()
    {
        //_target = target;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
    void Move() {
    	float distance = Vector3.Distance(gameObject.transform.position, _target);
    	gameObject.transform.position = Vector3.Lerp(transform.position, _target, (Time.deltaTime*Speed)/distance);
    }
    */
}