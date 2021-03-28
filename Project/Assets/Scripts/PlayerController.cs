using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    //Interaction data, public, to be set in Unity editor
    public InteractionInputData interaction;

    //Character controller for movement, collision
    private CharacterController cc;

    //Camera
    private GameObject cameraObject;

    //Vector variables for storing input
    private Vector2 movementVector;
    private Vector2 cameraVector;
    private bool clicked;

    //Settings for move speed and camera sensitivity, public to allow changing in Unity
    public float speed = 50f;
    public float cameraSensititivity = 10;

    //Setting for gravity
    public float gravity = -10;

    void Start()
    {
        //Get the character controller and camera
        cc = GetComponent<CharacterController>();
        cameraObject = Camera.main.gameObject;

        //Set up interaction scriptable object
        interaction.Reset();
    }

    //Event handlers for input
    private void OnMove(CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>();
    }

    public void OnLook(CallbackContext context)
    {
        cameraVector = context.ReadValue<Vector2>();
    }

    public void OnInteract(CallbackContext context)
    {
        bool data = context.ReadValueAsButton();

        //Only go on when the button press/click begins
        if (data && !clicked)
        {
            interaction.p_interactPress = true;
        }

        //Track whether button is pressed or not
        clicked = data;
    }

    void Update()
    {
        //Calculating new camera rotation
        Vector3 cameraDelta = new Vector3(-cameraVector.y, 0, 0) * Time.deltaTime * cameraSensititivity;
        Vector3 cameraRotation = cameraObject.transform.rotation.eulerAngles;
        cameraRotation += cameraDelta;

        //Updating camera rotation
        cameraObject.transform.rotation = Quaternion.Euler(cameraRotation);

        //Calculating new body rotation
        Vector3 bodyRotationDelta = new Vector3(0, cameraVector.x, 0) * Time.deltaTime * cameraSensititivity;
        Vector3 bodyRotation = gameObject.transform.rotation.eulerAngles;
        bodyRotation += bodyRotationDelta;

        //Updating body rotation
        gameObject.transform.rotation = Quaternion.Euler(bodyRotation);

        //Applying movement
        Vector3 movementDelta = new Vector3(movementVector.x, 0, movementVector.y) * Time.deltaTime * speed;
        movementDelta += new Vector3(0, gravity, 0) * Time.deltaTime;
        movementDelta = transform.TransformDirection(movementDelta);
        cc.Move(movementDelta * 0.1f);
    }
}
