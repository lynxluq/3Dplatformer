using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask InteractObjectLayer;
    [SerializeField] private GameObject openChestMessage;
    public event EventHandler OnInteract;
    private void Update(){
        RaycastHit rayhit;
        if(Physics.Raycast(transform.position,transform.forward,out rayhit,2f,InteractObjectLayer)){
            //Allow the player to interact
            openChestMessage.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
                openChestMessage.SetActive(false);
                OnInteract?.Invoke(this,EventArgs.Empty);
            }
            
        }
        else{
            openChestMessage.SetActive(false);
        }      
    }
}
