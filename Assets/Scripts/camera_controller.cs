using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class camera_controller : MonoBehaviour {

	public GameObject player;
	public TextMesh speedText;
	public TextMesh directionText;
	public TextMesh scoreMesh;
	public TextMesh livesMesh;

	private float playerSpeed;
	private Vector3 playerDirection;
	private Rigidbody playerRB;

	void Start()
	{
		playerRB = player.GetComponent<Rigidbody>();
		playerSpeed = playerRB.velocity.magnitude;
		playerDirection = playerRB.transform.forward;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			Debug.Log("Adjust camera!");
		}
	}

	void LateUpdate()
	{
		if (score_controller.state == score_controller.GameState.PLAYING)
		{
			playerSpeed = playerRB.velocity.magnitude;
			playerDirection = playerRB.transform.eulerAngles;

			speedText.text = playerSpeed.ToString();
			directionText.text = playerDirection.ToString();

			scoreMesh.text = "Score: " + score_controller.score.ToString();
			livesMesh.text = "Lives: " + score_controller.lives.ToString();
		} else
		{
			speedText.text = "";
			directionText.text = "";

			scoreMesh.text = "";
			livesMesh.text = "";
		}
	}
}
