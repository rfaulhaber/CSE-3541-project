using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {
	public Rigidbody rb;
	public float speed;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
		{
			rb.velocity += transform.forward * Time.deltaTime * speed;
		}

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			transform.Rotate(new Vector3(-speed, 0, 0f));
		}

		if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
		{
			transform.Rotate(new Vector3(0f, -speed, 0f));
		}

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			transform.Rotate(new Vector3(speed, 0, 0f));
		}

		if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
		{
			transform.Rotate(new Vector3(0f, speed, 0f));
		}
	}
}
