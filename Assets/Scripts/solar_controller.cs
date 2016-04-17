using UnityEngine;
using System.Collections;

public class solar_controller : MonoBehaviour {

    public GameObject player;

    private Vector3 init_pos;
    private float x_change = 0;
    private float y_change = 0;
    private float z_change = 0;

    // Use this for initialization
    void Start () {
        init_pos = transform.position;
        player = GameObject.Find("drone");
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = init_pos + player.transform.position;
        transform.position = pos;
        x_change = init_pos.x - pos.x;
        y_change = init_pos.y - pos.y;
        z_change = init_pos.z - pos.z;
    }
}
