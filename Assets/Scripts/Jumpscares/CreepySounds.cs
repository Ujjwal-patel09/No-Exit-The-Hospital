using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CreepySounds : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private BoxCollider boxCollider; 
    
    private void Awake() 
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            audioSource.enabled = true;
            boxCollider.enabled = false;
            StartCoroutine(DeactivateObject());
        }
        
    }

    IEnumerator DeactivateObject()
    {
        yield return new WaitForSeconds(10f);

        audioSource.enabled = false;
        gameObject.SetActive(false);
    }
}
