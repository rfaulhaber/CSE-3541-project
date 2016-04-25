using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {
	public Rigidbody rb;
	public float speed;
	public GameObject projectile;

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
			rb.AddRelativeTorque(new Vector3(-speed, 0, 0));
		}

		// rotate left
		if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
		{
			rb.AddRelativeTorque(new Vector3(0f, speed, 0f));
		}

		// rotate upward
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			rb.AddRelativeTorque(new Vector3(speed, 0, 0));
		}

		// rotate right
		if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
		{
			rb.AddRelativeTorque(new Vector3(0f, -speed, 0f));
		}

		// stabilize
		if (Input.GetKey(KeyCode.Tab))
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

		if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetMouseButtonDown(0))
		{
			GameObject blaster = GameObject.FindGameObjectWithTag("blaster");
			Instantiate(projectile, blaster.transform.position, blaster.transform.rotation);
		}

		// if you're not moving forward and your moving, progressively slow down
		if (!Input.GetKey(KeyCode.Space) && rb.velocity != Vector3.zero && !Input.GetKey(KeyCode.Tab))
		{
			rb.velocity = Vector3.SmoothDamp(rb.velocity, Vector3.zero, ref currentVelocity, 1.5f);
		}

		if (rb.angularVelocity != Vector3.zero && (!(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && !(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && !(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow)) && !Input.GetKey(KeyCode.Tab)))
		{
			rb.angularVelocity = Vector3.SmoothDamp(rb.angularVelocity, Vector3.zero, ref currentAngularVelocity, 1f);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name.Contains("asteroid"))
		{
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			score_controller.playerDeath(ref player);
		}
	}
}
