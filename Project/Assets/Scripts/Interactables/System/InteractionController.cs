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

        bool hit = Physics.SphereCast(_ray, rayRadius, out hitInfo, rayDistance);//, interactableLayer);

        if(hit){
            IInteractable _interactable = hitInfo.transform.GetComponent<IInteractable>();

            if(_interactable != null && _interactable.IsInteractable){
                if(interactionData.IsEmpty() || !interactionData.IsSameObj(_interactable)){
                    interactionData.Interactable = _interactable;
                    hoverUIController.SetHoverMessage(interactionData.Interactable.HoverMessage);
                } else {
                    hoverUIController.SetHoverMessage(interactionData.Interactable.HoverMessage);
                }
            }
        } else {
            interactionData.Reset();
            hoverUIController.ResetUI();
        }

        Debug.DrawRay(_ray.origin,_ray.direction, hit ? Color.green : Color.red);
    }

    private void CheckForInteractionInput(){
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
