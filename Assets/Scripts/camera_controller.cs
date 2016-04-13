using UnityEngine;
using System.Collections;

public class camera_controller : MonoBehaviour {

	public GameObject player;
	public TextMesh speedText;
	public TextMesh directionText;
	public TextMesh scoreMesh;

	private float playerSpeed;
	private Vector3 playerDirection;
	private Rigidbody playerRB;

	void Start()
	{
		playerRB = player.GetComponent<Rigidbody>();
		playerSpeed = playerRB.velocity.magnitude;
		playerDirection = playerRB.transform.forward;
	}

	void LateUpdate()
	{
		playerSpeed = playerRB.velocity.magnitude;
		playerDirection = playerRB.transform.eulerAngles;

		speedText.text = playerSpeed.ToString();
		directionText.text = playerDirection.ToString();
	}
}
