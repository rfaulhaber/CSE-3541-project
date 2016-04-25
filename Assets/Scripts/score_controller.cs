using UnityEngine;
using System.Collections;

public class score_controller : MonoBehaviour {

	private Rigidbody playerRB;

	public static int score = 0;
	public static int lives = 3;

	public enum GameState { PLAYING, PAUSED, MAIN_MENU }
	public enum Difficulty { EASY, HARD, EXTREME }

	public GameState state = GameState.PLAYING;
	public Difficulty difficulty = Difficulty.EASY;

	void Start()
	{
		GameObject.Find("death_camera").GetComponent<Camera>().enabled = false;
	}


	public static void playerDeath(ref GameObject player)
	{
		Rigidbody playerRB = player.GetComponent<Rigidbody>();

		lives--;
		Debug.Log("Collided with asteroid!");
		score = 0;
		playerRB.velocity = Vector3.zero;
		playerRB.angularVelocity = Vector3.zero;

		if (lives == 0)
		{
			GameObject.Find("death_camera").GetComponent<Camera>().enabled = true;
			GameObject.Find("player_camera").GetComponent<Camera>().enabled = false;

			player.transform.position = new Vector3(-2000, 2000, 2000);
		}

		else
		{
			player.transform.position = Vector3.zero;
		}
	}

	public static void playerReset()
	{
		GameObject.Find("death_camera").GetComponent<Camera>().enabled = false;
		GameObject.Find("player_camera").GetComponent<Camera>().enabled = true;
		lives = 3;
		score = 0;
	}
}
