using UnityEngine;
using System.Collections;

public class star_controller : MonoBehaviour
{

    // Use this for initialization
    void Start()
	{
    }

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(new Vector3(0f, 0.025f, 0f));
    }
}
