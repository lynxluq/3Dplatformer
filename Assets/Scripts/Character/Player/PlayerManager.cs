using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public PlayerInteraction playerInteraction;
    public PlayerMovement playerMovement;
    public PlayerInventory playerInventory;

    
    void Awake()
    {
        playerInteraction = GetComponent<PlayerInteraction>();
        playerMovement = GetComponent<PlayerMovement>();
        playerInventory = GetComponent<PlayerInventory>();
        if(instance==null){
            instance= this;
        }
        else{
            Destroy(gameObject);
        }
    }    
    }

