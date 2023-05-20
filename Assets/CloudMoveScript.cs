using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is tied to the prefab cloud object
public class CloudMoveScript : MonoBehaviour
{
    //cloud's movement speed
    public float moveSpeed = 10;
    
    //the X coordinate that goes past the camera screen
    public float deadZone = -27;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Moves the cloud to the left.
         Time.deltaTime makes the movement consistent across different platforms */
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        
        //deletes the cloud if its X coordinate bypasses the deadZone
        if (transform.position.x < deadZone)
        {
            Debug.Log("Cloud deleted");
            Destroy(gameObject);
        }
    }
}
