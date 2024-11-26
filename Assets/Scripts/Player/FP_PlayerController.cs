using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class FP_PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    private Vector3 MoveDirection;
    private float MoveSpeed;
   
    // player Input //
    [HideInInspector]public  float InputX;
    [HideInInspector]public  float InputZ;

    [Header("Walking")]
    [SerializeField] private bool Can_Walk = true;
    [SerializeField] private float walking_speed = 3f;
    [HideInInspector]public bool iswalking;

    [Header("Sounds")]
    [SerializeField]private AudioSource PlayerWalkSound;
   // [SerializeField]private AudioSource PlayerBreathingSound;
    
    void Start() 
    {
      characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        movement();
        Setpoition();
        PlayAudio();
    }

    private void PlayerInput()
    {
      InputX = Input.GetAxis("Horizontal");
      InputZ = Input.GetAxis("Vertical");
    }

    private void movement()
    {    
        // for move in direction of  camera facing//
        MoveDirection = transform.right * InputX + transform.forward * InputZ;
        characterController.Move(MoveDirection.normalized * MoveSpeed * Time.deltaTime);

        //  for walking //
        if(Can_Walk)
        {
            if(MoveDirection.magnitude > 0.1f || MoveDirection.magnitude < -0.1f)
            {
                MoveSpeed = walking_speed;
                iswalking = true;  
            }else
            {
                iswalking = false;
            }
        }
    }

    private void Setpoition()
    {
        transform.localPosition = new Vector3(transform.position.x,0,transform.position.z);
    }

    private void PlayAudio()
    {
        if(iswalking)
        {
            PlayerWalkSound.enabled = true;
        }else
        {
            PlayerWalkSound.enabled = false;
        }
    }
}
