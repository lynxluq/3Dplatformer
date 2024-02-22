using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float verticalInput; 
    public float horizontalInput;
    public float moveAmount;
    [Header("Movement settings")]
   private Vector3 moveDir;
   private Vector3 targetRotationDirection;
   [SerializeField] private float walkingSpeed=2;
   [SerializeField] private float runningSpeed=5;
   [SerializeField] private float SprintingSpeed=7;
   [SerializeField] private float rotationSpeed = 15;
   [SerializeField] private int sprintingStaminaCost = 2;
   [SerializeField] private GameObject camera;

   CharacterController characterController;

   private void Update(){
    HandleMovement();
   }

   public void HandleMovement(){
      HandleGroundMovement();
      HandleRotation();
    
   }
   private void Awake(){
    characterController = GetComponent<CharacterController>();
   }
   private void GetMovementvalues(){
      verticalInput = PlayerInputManager.instance.verticalInput;
      horizontalInput = PlayerInputManager.instance.horizontalInput;
      moveAmount = PlayerInputManager.instance.movementAmount;
   }
   private void HandleGroundMovement(){
        GetMovementvalues();
        moveDir = camera.transform.forward * verticalInput;
        moveDir = moveDir + camera.transform.right * horizontalInput;
        moveDir.Normalize();
        moveDir.y =0; 
        characterController.Move(moveDir*runningSpeed*Time.deltaTime);



   }
   private void HandleRotation(){
      targetRotationDirection= Vector3.zero;
      targetRotationDirection= camera.transform.forward * verticalInput;
      targetRotationDirection= targetRotationDirection+ camera.transform.right * horizontalInput;
      targetRotationDirection.Normalize();
      targetRotationDirection.y=0;
      
      if(targetRotationDirection== Vector3.zero){
         targetRotationDirection = transform.forward;
      }
      Quaternion newRotation = Quaternion.LookRotation(targetRotationDirection);
      Quaternion targetRotation = Quaternion.Slerp(transform.rotation, newRotation , rotationSpeed * Time.deltaTime);

      transform.rotation = targetRotation;
   }

}
