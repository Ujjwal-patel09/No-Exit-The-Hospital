using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    [SerializeField]private GameObject JumpscareObject;
    [SerializeField]private GameObject[] GhostObjects;
    [SerializeField]private Transform GhostSpawnTransform;
    [SerializeField]private BoxCollider boxCollider;

    private int RandomIndex;
    
    private void Awake() 
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            RandomIndex = Random.Range(0,GhostObjects.Length);
            boxCollider.enabled = false;
            GhostObjects[RandomIndex].transform.position = GhostSpawnTransform.position;
            GhostObjects[RandomIndex].SetActive(true);
            StartCoroutine(DeactivateObject());
        }
        
    }

    IEnumerator DeactivateObject()
    {
        yield return new WaitForSeconds(1.2f);
        GhostObjects[RandomIndex].SetActive(false);
        JumpscareObject.gameObject.SetActive(false);
    }
}
