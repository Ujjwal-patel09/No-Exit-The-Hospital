using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PossessBar : MonoBehaviour
{
    [SerializeField] private Image FillImage;
    [SerializeField] private float MaxTimeForPossess;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private AudioSource DeathSound;
    [SerializeField] private Animator Cameraholder;
    [SerializeField] private FP_PlayerController fP_PlayerController; 
    private float TimeRemaining;
    private bool StartTimer;

    private void Start() 
    {
        TimeRemaining = 0;
        StartTimer = true;
    }

    private void Update() 
    {

        if(TimeRemaining >= MaxTimeForPossess)
        {
            StartTimer = false;
            DeathSound.enabled = true;
            Cameraholder.SetTrigger("DeathAnim");
            fP_PlayerController.enabled = false;
            //Cursor.lockState = CursorLockMode.None;
            StartCoroutine(ChangeScene());

        }

        if(StartTimer)
        {
            TimeRemaining += Time.deltaTime;
            FillImage.fillAmount = TimeRemaining/MaxTimeForPossess;
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        Cursor.lockState = CursorLockMode.None;
        sceneLoader.LoadNextScene(2);
    }
}
