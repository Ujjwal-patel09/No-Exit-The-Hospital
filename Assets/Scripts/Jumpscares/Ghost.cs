using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField]private GameObject Player;

    private void Update() 
    {
        transform.LookAt(Player.transform);
        
    }
}
