using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeMiddleScript : MonoBehaviour
{
    //refernces the logic script indirectly
    public LogicScript logic;
    
    //references the bird script indirectly
    public BirdScript bird; 
    
    // Start is called before the first frame update
    void Start()
    {
        //same as dragging and dropping components into references but happens during runtime 
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); //references the logic script via tag
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>(); //references the bird script via tag
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    //Automatically triggers if the bird's ridgedbody touches the middle of the pipes (a ridgedbody between the top and bottom pipes of the pipe prefab)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //only adds score when the bird is alive
        //checks if the collision happens on the bird's layer (3rd layer)
        //Checks if the bird is alive from the bird script
        //Calls the add score method from the logic script and updates the player's current score
        if (collision.gameObject.layer == 3 && bird.birdIsAlive == true)
        {
            logic.addScore(1);
        }
    }
}
