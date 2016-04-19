using UnityEngine;
using System.Collections;

public class small_asteroid_controller : MonoBehaviour {

    public Vector3 rotation;
    public GameObject explosion;

    // Use this for initialization
    void Start () {
        rotation = new Vector3(Random.Range(-.7F, .7F), Random.Range(-.7F, .7F), Random.Range(-.7F, .7F));
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(rotation);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Projectile(Clone)")
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
