using UnityEngine;
using System.Collections;

public class make_asteroid : MonoBehaviour {
    public GameObject asteroid_a, asteroid_b, asteroid_small_a, asteroid_small_b, player;
    public float make = 1f;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 50; i++)
        {
            MakeRandAsteroid(Random.Range(1, 7));
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (make > 0)
        {
            make -= Time.deltaTime;
        }
        else
        {
            MakeRandAsteroid(Random.Range(1, 7));
            make = 1;
        }
    }

    // type  correspond to asteroid type: a = 1, b = 2, small_a = 3, small_b = 4
    void MakeRandAsteroid(int type)
    {
        Vector3 location = SetLocation(Random.Range(1, 4));
        if (type == 1 || type == 2)
        {
            Instantiate(asteroid_a, location, Random.rotation);
        }
        else if (type == 3 || type == 4)
        {
            Instantiate(asteroid_b, location, Random.rotation);
        }
        else if (type == 5)
        {
            Instantiate(asteroid_small_a, location, Random.rotation);
        }
        else
        {
            Instantiate(asteroid_small_b, location, Random.rotation);
        }
    }

    // axis correspond to axis as range: x = 1, y = 2, z = 3
    Vector3 SetLocation(int axis)
    {
        bool sign = false;
        Vector3 location = Vector3.zero;
        if (Random.Range(1, 3) == 1)
        {
            sign = true;
        }
        if (axis == 1)
        {
            if (sign)
            {
                location = new Vector3(player.transform.position.x + 50f, Random.Range(-50f, 50f), Random.Range(-50f, 50f));
            }
            else
            {
                location = new Vector3(player.transform.position.x - 50f, Random.Range(-50f, 50f), Random.Range(-50f, 50f));
            }
        }
        else if (axis == 2)
        {
            if (sign)
            {
                location = new Vector3(Random.Range(-50f, 50f), player.transform.position.y + 50f, Random.Range(-50f, 50f));
            }
            else
            {
                location = new Vector3(Random.Range(-50f, 50f), player.transform.position.y - 50f, Random.Range(-50f, 50f));
            }
        }
        else
        {
            if (sign)
            {
                location = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), player.transform.position.z + 50f);
            }
            else
            {
                location = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), player.transform.position.z - 50f);
            }
        }
        return location;
    }
}
