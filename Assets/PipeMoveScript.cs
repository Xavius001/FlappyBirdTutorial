using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script is tied to the prefab pipe object
public class PipeMoveScript : MonoBehaviour
{
    //pipe prefab movement speed
    public float moveSpeed = 5;
    
    //the X coordinate that goes past the camera screen
    public float deadZone = -45;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Moves the pipe to the left.
         Time.deltaTime makes the movement consistent across different platforms */
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        //deletes the pipe if its X coordinate bypasses the deadZone
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }
}
