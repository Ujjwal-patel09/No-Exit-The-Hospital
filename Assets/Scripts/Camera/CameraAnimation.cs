using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    [SerializeField]FP_PlayerController fP_PlayerController;
    [SerializeField]Animator playerAnimator;

    private void Awake() 
    {
        playerAnimator = GetComponent<Animator>();
        fP_PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<FP_PlayerController>();    
    }

    // Update is called once per frame
    void Update()
    {   

        if(fP_PlayerController.iswalking)
        {
            playerAnimator.SetBool("CameraBobbing",true);
        }else
        {
            playerAnimator.SetBool("CameraBobbing",false);
        }
    }
}
