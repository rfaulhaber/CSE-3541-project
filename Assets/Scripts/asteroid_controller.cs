using UnityEngine;
using System.Collections;

public class asteroid_controller : MonoBehaviour {

    public Vector3 rotation;
    public GameObject small_asteroid_one, small_asteroid_two, explosion;

    // Use this for initialization
    void Start () {
        rotation = new Vector3(Random.Range(-.3F, .3F), Random.Range(-.3F, .3F), Random.Range(-.3F, .3F));
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotation);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Projectile(Clone)")
        {
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
            Instantiate(small_asteroid_one, gameObject.transform.position, gameObject.transform.rotation);
        }
        else
        {
            Instantiate(small_asteroid_two, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

}
