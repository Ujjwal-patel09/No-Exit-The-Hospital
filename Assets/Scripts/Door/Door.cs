using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]private Animator DoorAnimator;

    public bool IsPlayerNearDoor;
    public bool OpenDoor;

    [SerializeField] private AudioSource OpenDoorSound;
    [SerializeField] private AudioSource CloseDoorSound;

    void Start() 
    {
        IsPlayerNearDoor = false;
        OpenDoor = false;
    }
    
    void Update() 
    {
        if(IsPlayerNearDoor)
        {
            if(OpenDoor)
            {
                DoorAnimator.SetBool("OpenDoor",false);
                CloseDoorSound.enabled = true;
                StartCoroutine(ResetSound());
                OpenDoor = false;
                IsPlayerNearDoor = false;
            }else
            {
                DoorAnimator.SetBool("OpenDoor",true);
                OpenDoorSound.enabled = true;
                StartCoroutine(ResetSound());
                OpenDoor = true;
                IsPlayerNearDoor = false;
            }
        }
        
    }

    IEnumerator ResetSound()
    {
        yield return new WaitForSeconds(1.5f);
        OpenDoorSound.enabled = false;
        CloseDoorSound.enabled = false;
    }
}
