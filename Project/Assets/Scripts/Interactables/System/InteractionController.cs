using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Edited version of code from tutorial by VeryHotShark on youtube

public class InteractionController : MonoBehaviour
{
    [Header("Data Objects")]
    [SerializeField] private InteractionData interactionData;
    [SerializeField] private InteractionInputData interactionInputData;
    [SerializeField] private HoverUIController hoverUIController;

    [Space]
    [Header("Ray Settings")]
    [SerializeField] private float rayDistance;
    [SerializeField] private float rayRadius;
    //[SerializeField] private LayerMask interactableLayer;
    
    private Camera p_cam;
    private bool p_interacting;

    void Start(){
        DontDestroyOnLoad(gameObject);
    }

    void Awake() {
        p_cam = FindObjectOfType<Camera>();
    }

    void Update() {
        CheckForInteractable();
        CheckForInteractionInput();
    }

    private void CheckForInteractable(){
        
        Ray _ray = new Ray(p_cam.transform.position,p_cam.transform.forward);
        RaycastHit hitInfo;

        //look straight ahead (with some wiggle room) for an interactable object

        bool hit = Physics.SphereCast(_ray, rayRadius, out hitInfo, rayDistance);//, interactableLayer);

        if(hit){
            IInteractable _interactable = hitInfo.transform.GetComponent<IInteractable>();

            if(_interactable != null && _interactable.IsInteractable){
                if(interactionData.IsEmpty() || !interactionData.IsSameObj(_interactable)){
                    //If there is a hit and the object hit is not already in controller, update the item in the controller
                    interactionData.Interactable = _interactable;
                    hoverUIController.SetHoverMessage(interactionData.Interactable.HoverMessage);
                } else {
                    //Ensures that hover message is up to date
                    hoverUIController.SetHoverMessage(interactionData.Interactable.HoverMessage); 
                }
            }
        } else {
            //if there is no hit, reset
            interactionData.Reset();
            hoverUIController.ResetUI();
        }

        Debug.DrawRay(_ray.origin,_ray.direction, hit ? Color.green : Color.red);
    }

    private void CheckForInteractionInput(){
        //on press, interact
        if(!interactionData.IsEmpty()){
            if(interactionData.Interactable.IsInteractable){
                if(interactionInputData.InteractPress){
                    interactionData.Interact();
                    interactionData.Reset();
                    hoverUIController.ResetUI();
                }
            }
        }

        interactionInputData.Reset();
    }

    public void UpdateText(){
        hoverUIController.SetHoverMessage(interactionData.Interactable.HoverMessage);
    }
}
