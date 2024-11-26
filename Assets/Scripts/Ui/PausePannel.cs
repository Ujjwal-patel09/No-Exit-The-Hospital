using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePannel : MonoBehaviour
{
    [SerializeField]private GameObject Pausepannel;
    [SerializeField]private Camera_Mouse_Look camera_Mouse_Look;
    [SerializeField]private Slider Sensitivityslider;
    [SerializeField]private GameObject PauseIcon;
    
    private void Start() 
    {
        Sensitivityslider.value = 20f;
        
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            camera_Mouse_Look.enabled = false;
            Pausepannel.SetActive(true);
            PauseIcon.SetActive(false);
            Time.timeScale = 0f;
        }
    }
    
    private void LateUpdate() 
    {
        camera_Mouse_Look.MouseSensitivity = Sensitivityslider.value;
    }
     
    public void Resume()
    {
        Time.timeScale = 1f;
        StartCoroutine(CursorLock());
        Pausepannel.SetActive(false);
        PauseIcon.SetActive(true);
    }

    IEnumerator CursorLock()
    {
        yield return new WaitForSeconds(0.5f);
       Cursor.lockState = CursorLockMode.Locked;
       camera_Mouse_Look.enabled = true;
    }
    
}
