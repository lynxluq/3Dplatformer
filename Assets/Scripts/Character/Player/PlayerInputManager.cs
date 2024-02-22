using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance;

    public PlayerManager player;
    PlayerControls playerControls;
    [Header("PLAYER MOVEMENT INPUT")]
    [SerializeField] Vector2 movement;
    [SerializeField] public float horizontalInput;
    [SerializeField] public float verticalInput;
    [SerializeField] public float movementAmount;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
     private void OnApplicationFocus(bool focusStatus) {
        if(enabled){// to allow us to give input only for one window or application , its useful when used for debugging multiplayer so the input isnt given to both the clone and the master while testing multiplayer
            if(focusStatus){
                playerControls.Enable();
            }
            else{
                playerControls.Disable();
            }
        }
    }
    private void Start(){
        DontDestroyOnLoad(gameObject);
    }

    private void Update(){
        HandleMovementInput();
    }
    private void OnEnable(){
        
        if(playerControls == null){
            playerControls = new PlayerControls();
        }
         playerControls.PlayerMovement.Movement.performed += i => movement = i.ReadValue<Vector2>(); 
    }

     private void HandleMovementInput(){
        verticalInput = movement.y;
        horizontalInput = movement.x;
        movementAmount = Mathf.Clamp01(Mathf.Abs(verticalInput)+ Mathf.Abs(horizontalInput));
        if(movementAmount <=0.5 && movementAmount>0){
            movementAmount=0.5f;
        }else if(movementAmount>0.5 && movementAmount<=1){
            movementAmount=1;
        }
        if(player==null){
            return;
        }
    }

}


