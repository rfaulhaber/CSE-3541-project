using UnityEngine;
using System.Collections;

public class small_asteroid_controller : MonoBehaviour {

    public Vector3 rotation, movement;
    public GameObject player, explosion;
    public float init_delay = 2;
    public bool collided = false;

    // Use this for initialization
    void Start () {
        rotation = new Vector3(Random.Range(-.7F, .7F), Random.Range(-.7F, .7F), Random.Range(-.7F, .7F));
        movement = new Vector3(Random.Range(-4F, 4F), Random.Range(-4F, 4F), Random.Range(-4F, 4F));
        player = GameObject.Find("drone");
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(rotation);
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) > 300f)
        {
            Destroy(gameObject);
        }
        if (init_delay > 0)
        {
            init_delay -= Time.deltaTime;
        }
        if (!collided)
        {
            transform.Translate(movement * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!collided && init_delay <= 0)
        {
            collided = true;
        }
        if (col.gameObject.name == "Projectile(Clone)")
        {
			score_controller.score++;
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
