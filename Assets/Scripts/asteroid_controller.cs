using UnityEngine;
using System.Collections;

public class asteroid_controller : MonoBehaviour {

    public Vector3 rotation, movement;
    public GameObject player, asteroid_small_a, asteroid_small_b, explosion;
    public float init_delay = 2;
    public bool collided = false;

    // Use this for initialization
    void Start () {
        rotation = new Vector3(Random.Range(-.3F, .3F), Random.Range(-.3F, .3F), Random.Range(-.3F, .3F));
        movement = new Vector3(Random.Range(-1F, 1F), Random.Range(-1F, 1F), Random.Range(-1F, 1F));
        player = GameObject.Find("drone");
    }
	
	// Update is called once per frame
	void Update () {
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
            MakeSmallAsteroid();
            MakeSmallAsteroid();
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

    void MakeSmallAsteroid()
    {
        if (Random.Range(1, 3) == 1)
        {
            Instantiate(asteroid_small_a, gameObject.transform.position, Random.rotation);
        }
        else
        {
            Instantiate(asteroid_small_b, gameObject.transform.position, Random.rotation);
        }
    }

}
