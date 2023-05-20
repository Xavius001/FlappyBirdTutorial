using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnScript : MonoBehaviour
{
    //references the cloud prefab object (keep in mind it has its own script)
    public GameObject cloud;
    
    //spawnRate in seconds
    public float spawnRate = 1;
    
    //timer in seconds
    private float timer = 0;
    
    //offset for the Y coordinate of the cloud prefab
    public float heightOffset = 11;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /* Update is called once per frame
     * Adds a cloud prefab on the game screen every second
     */
    void Update()
    {
        /* Adds to the timer if its less than the spawnRate
         */
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime; //deltaTime keeps it consistent across all platforms
        }
        
        //spawns the cloud prefab and resets the timer
        else
        {
            spawnCloud();
            timer = 0;
        }
    }

    //Spawns the cloud prefab object on the screen with a random Y coordinate
    void spawnCloud()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        //Instantiate(prefab, transform.position, transform.rotation) --> general syntax
        //new Vector3(transform.position.x, transform.position.y, transform.position.z) --> general syntax
        Instantiate(cloud, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
