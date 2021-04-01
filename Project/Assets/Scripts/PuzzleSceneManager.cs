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
    private static GameObject player;

    //Switching non-puzzle scenes
    public static void SceneSwitch(string scene)
    {
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);

        sceneString = scene;
    }

    //Switches to the puzzle scene specified
    public static void SwitchToPuzzle(string scene)
    {
        //Entering puzzle from main scene
        if (!inPuzzle)
        {
            PauseScene();

            //Additive to keep the previous scene loaded
            AsyncOperation operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            operation.allowSceneActivation = true;

            sceneString = scene;
            inPuzzle = true;
        } else //Entering puzzle from a puzzle
        {
            //Additive to keep the previous scene loaded
            AsyncOperation operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

            //Only unload after the new scene completes loading, need to pass new scene string
            operation.completed += sender => PuzzleSwitch(scene);
            operation.allowSceneActivation = true;

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

    //Event handler for switching puzzles
    private static void PuzzleSwitch(string scene)
    {
        //Only unload previous puzzle once game loads the new one
        SceneManager.UnloadSceneAsync(sceneString);

        //Only set new scene string after the old one is used for unloaded
        sceneString = scene;
    }

    //Pauses current scene
    private static void PauseScene()
    {
        //Should run only once when pause is first used
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //Player should be set to something, just a sanity check
        if (player != null)
        {
            //Camera is a child of the player, will be disabled and enabled as a side effect of the player
            player.SetActive(false);
        }
        
    }

    //Unpauses current scene
    private static void UnPauseScene()
    {
        //Should never run, should have already been set by pause, but here for sanity checking
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //Player should be set to something, just a sanity check
        if (player != null)
        {
            //Camera is a child of the player, will be disabled and enabled as a side effect of the player
            player.SetActive(true);
        }
    }

    public static void QuitGame() {
        Application.Quit();
    }
}
