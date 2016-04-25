using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class button_handler : MonoBehaviour {

	private Button tryAgainButton;

	// Use this for initialization
	void Start () {
		tryAgainButton = GameObject.FindGameObjectWithTag("TryAgainButton").GetComponent<Button>();
		tryAgainButton.onClick.AddListener(() => score_controller.playerReset());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
