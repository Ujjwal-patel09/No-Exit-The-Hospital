using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    #region Singleton
    public static Player_Interaction instance;
    private void Awake() 
    { 
        if(instance == null && instance != this)
        {
            instance = this;
        }
    }
    #endregion

    // for player raycast variables for identifies npc//
    [SerializeField]public Transform interactor_Source_Cam;
    [SerializeField]public float interact_range;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(interactor_Source_Cam.position,interactor_Source_Cam.forward);
            if(Physics.Raycast(ray,out RaycastHit Hit_Info,interact_range))// cast a ray from player camera in forward and geeting hit info //
            {
                if(Hit_Info.collider.gameObject.TryGetComponent(out Door door))//  if hit info collides with Door Object, so It gets Door Script from it//
                {
                    door.IsPlayerNearDoor = true;
                }
            }
        }
        
    }

    public Door Get_Door_Object()// used in Interaction_ui script for display "Mouse 0 Click" Ui Icon in scene//
    {
        Ray r = new Ray(interactor_Source_Cam.position,interactor_Source_Cam.forward);
        if(Physics.Raycast(r,out RaycastHit Hit_Info,interact_range))
        { 
            if(Hit_Info.collider.gameObject.TryGetComponent(out Door door))//  if hit info collides with Door Object, so It gets Door Script from it//
            {
               return door;
            }
        }
        return null;
    }

    /*public I_Interactable Get_Interactable_object()// used in Playeri_intereact_ui script for display "E" button ui in scene//
    {
        if(isInteract == false)
        {
            Ray r = new Ray(interactor_Source_Cam.position,interactor_Source_Cam.forward);
            if(Physics.Raycast(r,out RaycastHit Hit_Info,interact_range))
            { 
                if(Hit_Info.collider.gameObject.TryGetComponent(out I_Interactable i_Interactable))
                {
                 return i_Interactable;
                }
            }
        }
        return null;
    }*/
}
