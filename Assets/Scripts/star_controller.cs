using UnityEngine;
using System.Collections;

public class star_controller : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		transform.position = new Vector3(Random.Range(-10000, 10000), Random.Range(-10000, 10000), Random.Range(-10000, 10000));
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(new Vector3(0f, 0.025f, 0f));

	}
}
