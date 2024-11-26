using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    [SerializeField]private FP_PlayerController fP_PlayerController;
    [SerializeField]private Camera_Mouse_Look camera_Mouse_Look;
    [SerializeField]private Animator FinishDoorAnimator;
    [SerializeField]private AudioSource finishSound;
    [SerializeField]private AudioSource PlayerfootstepSound;
    [SerializeField]private SceneLoader sceneLoader;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerfootstepSound.enabled = false;
            finishSound.enabled = true;
            camera_Mouse_Look.enabled = false;
            fP_PlayerController.enabled = false;
            FinishDoorAnimator.SetBool("OpenDoor",true);
            StartCoroutine(ChangeScene());
            
        }
        
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(7);
        Cursor.lockState = CursorLockMode.None;
        sceneLoader.LoadNextScene(3);

    }
}
