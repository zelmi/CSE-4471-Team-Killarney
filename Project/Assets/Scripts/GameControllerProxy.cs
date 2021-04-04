using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Just a proxy for the real GameController, so that the win and lose scenes can access it for UI events
public class GameControllerProxy : MonoBehaviour
{
    GameController controller;
    void Start()
    {
        //Get the controller
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void StartGame()
    {
        //Just call the controller's method
        controller.StartGame();
    }

    public void QuitGame()
    {
        //Just call the controller's method
        controller.QuitGame();
    }
}
