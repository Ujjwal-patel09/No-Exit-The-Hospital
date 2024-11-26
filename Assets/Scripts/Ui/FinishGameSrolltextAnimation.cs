using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameSrolltextAnimation : MonoBehaviour
{
    [SerializeField] private GameObject storytext;
    [SerializeField] private GameObject Menu_Name;

    private void Start() 
    {
       StartCoroutine(deactivateobjects());
        
    }

    IEnumerator deactivateobjects()
    {
        yield return new WaitForSeconds(23);
        storytext.SetActive(false);
        Menu_Name.SetActive(true);
    }
}
