using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    //must make reference objects to the componenets

    //can contact the bird's rigidbody (hitbox/hurtbox)
    public Rigidbody2D myRigidBody;

    //controls how high the bird flaps
    public float flapStrength;

    //makes an in-direct reference to our logic script
    public LogicScript logic;

    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        //default: talks to puppet (object name) and its transform

        //references the logic script via tag
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //continuously goes up 10 units
        //myRigidBody.velocity = Vector2.up * 10;

        /*
         * only goes up X units when space bar is pressed and bird is alive
         * this stops the score from going up despite the bird being dead
         */
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }

        //will display the game over screen when the bird goes offscreen
        if (transform.position.y > 17 || transform.position.y < -17)
        {
            endGame();
        }

    }

    //will display the game over screen when the bird hits the pipe automatically
    private void OnCollisionEnter2D(Collision2D collision)
    {
        endGame();
    }

    //calls the game over method from the logic script
    public void endGame()
    {
        logic.gameOver();
        birdIsAlive = false;
    }

}
