using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Static class for handling switching between scenes
public class PuzzleSceneManager 
{
    //Track whether in a puzzle or not
    private static bool inPuzzle = false;

    //Name of puzzle scene in use
    private static string sceneString;

    private static GameObject camera;

    //Switches to the puzzle scene specified
    public static void SwitchToPuzzle(string scene)
    {
        //Sanity check that we are not trying to enter a puzzle from a puzzle
        if (!inPuzzle)
        {
            PauseScene();

            //Additive to keep the previous scene loaded
            AsyncOperation operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            operation.allowSceneActivation = true;

            sceneString = scene;
            inPuzzle = true;
        }
    }

    //Exits the puzzle, resumes the previous scene
    public static void ExitPuzzle()
    {
        //Sanity check that we are not trying to exit a puzzle when there is no puzzle
        if (inPuzzle)
        {
            AsyncOperation operation = SceneManager.UnloadSceneAsync(sceneString);
            operation.completed += UnloadDone;

            inPuzzle = false;
        }
    }

    //Event handler for when scene is unloaded
    private static void UnloadDone(AsyncOperation operation)
    {
        //Only unpause when game is done unloading the puzzle
        UnPauseScene();
    }

    //TODO: Depending on player implementation, these two methods might be able to be combined

    //Pauses current scene
    private static void PauseScene()
    {
        //TODO: will need to disable the player in the main scene. Player not implemented yet
        camera = Camera.main.gameObject;
        camera.SetActive(false);
    }

    //Unpauses current scene
    private static void UnPauseScene()
    {
        //TODO: will need to enable the player in the main scene. Player not implemented yet
        camera.SetActive(true);
    }

    public static void QuitGame() {
        Application.Quit();
    }
}
