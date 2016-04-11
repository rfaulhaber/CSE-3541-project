﻿using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {
	public Rigidbody rb;
	public float speed;

	private Vector3 currentVelocity = Vector3.zero;
	private Vector3 currentAngularVelocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		// move forward
		if (Input.GetKey(KeyCode.Space))
		{
			rb.velocity += transform.forward * Time.deltaTime * 2f;
		}

		// rotate downward
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			rb.AddTorque(new Vector3(0, 0, -speed));
		}

		// rotate left
		if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
		{
			rb.AddTorque(new Vector3(0f, speed, 0f));
		}

		// rotate upward
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			rb.AddTorque(new Vector3(0, 0, speed));
		}

		// rotate right
		if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
		{
			rb.AddTorque(new Vector3(0f, -speed, 0f));
		}

		// stabilize
		if (Input.GetKey(KeyCode.Q))
		{
			if (rb.velocity != Vector3.zero)
			{ 
				rb.velocity = Vector3.SmoothDamp(rb.velocity, Vector3.zero, ref currentVelocity, 0.5f);
			}

			if (rb.angularVelocity != Vector3.zero)
			{
				rb.angularVelocity = Vector3.SmoothDamp(rb.angularVelocity, Vector3.zero, ref currentAngularVelocity, 0.5f);
			}
		}
	}
}
