using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int randomSeed = 100;

    public float minSpawnTime = 0.1f;
    public float maxSpawnTime = 1.5f;

    //public float minForce = 100.0f;
    //public float maxForce = 200.0f;

    //public float minTorque = 100.0f;
    //public float maxTorque = 200.0f;

    public float topLocation;
    public float bottomLocation;
    public float leftLocation;
    public float rightLocation;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    float currSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(randomSeed);
        currSpawnTime = maxSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currSpawnTime >= 0.0f)
        {
            currSpawnTime -= Time.deltaTime;
            return;
        }
        currSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Vector3 location = Vector3.zero;

        // enemies are spawned directly outside of the fov of camera
        // so either within the X bounds and either over/under cam
        // or in Y bounds and left/right cam
        location.x = Random.Range(leftLocation, rightLocation);
        location.y = Random.Range(bottomLocation, topLocation);
        int locationindicator = Random.Range(1, 3);
        if (Random.Range(1,3) >= 2)
        { // spawn on left/right side of screen
            if (locationindicator == 1)
            {
                location.x = leftLocation;
            } else {
                location.x = rightLocation;
            }
            location.y = Random.Range(bottomLocation, topLocation);
        } else
        { // spawn on top/down side of screen
            if (locationindicator == 1)
            {
                location.y = topLocation;
            }
            else
            {
                location.y = bottomLocation;
            }
            location.x = Random.Range(leftLocation, rightLocation);
        }


        int enemynum = (int)Random.Range(1, 4); // randomly generate an enemy to spawn
        if (enemynum == 3)
        {
            GameObject newEnemy = Instantiate(enemy3, location, Quaternion.identity);
            // opportunity to add additional time to timer here based upon enemy type
        } else if (enemynum == 2)
        {
            GameObject newEnemy = Instantiate(enemy2, location, Quaternion.identity);
        } else 
        {
            GameObject newEnemy = Instantiate(enemy1, location, Quaternion.identity);
        }
        

        //float randForce = Random.Range(minForce, maxForce);
        //newAsteroid.GetComponent<Rigidbody2D>().AddForce(Vector3.left * randForce);

        //float randTorque = Random.Range(minTorque, maxTorque);
        //newAsteroid.GetComponent<Rigidbody2D>().AddTorque(randTorque);
    }
}
