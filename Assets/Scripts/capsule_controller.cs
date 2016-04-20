using UnityEngine;
using System.Collections;

public class capsule_controller : MonoBehaviour {

	public float projectileForce;

	private Vector3 direction;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		direction = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(direction * projectileForce);
		Destroy(gameObject, 2.5f);
    }

    void OnCollisionEnter(Collision col)
    {

    }
}
