using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    // This starts the game, where the actual gameplay scene is located.
    public void StartGame()
    {
       
        SceneManager.LoadScene("SampleScene"); 
    }

    // Exit the game.
    public void QuitGame()
    {
        Application.Quit();
    }

   



}


