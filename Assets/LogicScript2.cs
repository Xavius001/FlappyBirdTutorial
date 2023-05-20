using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Title Scene Script
public class LogicScript2 : MonoBehaviour
{   
    /*
     * Is tied to the title screen object within the canvas
     * on the title scene
     */
    public GameObject titleScreen;
    
    /*
     * shows the title scene & screen
     * as soon as the game starts
     */
    void Start()
    {
        Debug.Log("Title Screen");
        titleScreen.SetActive(true);
    }

    //Is tied to the start button on the title scene
    public void startGame()
    {
        Debug.Log("Starting Game");
        /*
         * Title scene must be the first and only scene LOADED
         * This method will load the game scene and unload the title scene
         * so both don't show at the same time
         */

        //1 = game scene
        SceneManager.LoadScene(1);
        //0 = title scene
        SceneManager.UnloadScene(0);
    }

    public void closeGame()
    {
        /*
         * closes the application completely
         * can only be done when the game itself
         * is a separate application (after building). 
         * Cannot be tested in unity itself.
         */
        Application.Quit();
    }
}
