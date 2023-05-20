using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeSpawnScript : MonoBehaviour
{
    //references the pipe prefab we made
    public GameObject pipe;
    
    //spawnRate in seconds
    public float spawnRate = 3;

    //timer in seconds
    private float timer = 0;

    //offset for the Y coordinate of the pipe prefab
    public float heightOffset = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe(); //spawns a pipe prefab as soon as the game scene is loaded
    }

    // Update is called once per frame
    void Update()
    {
        //Adds to the timer if its less than the spawnRate
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }

        //spawns the pipe prefab and resets the timer
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    //Spawns the pipe prefab object on the screen with a random Y coordinate
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        //Instantiate(prefab, transform.position, transform.rotation) --> general syntax
        //new Vector3(transform.position.x, transform.position.y, transform.position.z) --> general syntax
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
