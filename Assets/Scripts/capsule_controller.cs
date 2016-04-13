using UnityEngine;
using System.Collections;

public class capsule_controller : MonoBehaviour {

	public float projectileForce;

	private Vector3 direction;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody>();
		direction = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(direction * projectileForce);
		Destroy(gameObject, 1.5f);
	}
}
