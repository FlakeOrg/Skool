using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehavior
{
  [Header("references")]
  public Transform playerObj;
  public Transform camera;
  [Header("settings and stuff")]
  public float rotSpeed = 3f;
  void Start()
  {
  // hide the cursor or something
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  void Update()
  {
    
  }

  void playerRotation()
  {

    // in this part (the next 4 ish lines) i honestly just asked chatgpt how to detect it wasd, it said to do this. im suspicious of it but ill do it.
    
    float horizontal = Input.GetAxisRaw("Horizontal"); //left and right, A and D
    float vertical = Input.GetAxisRaw("Vertical"); //forward and backward, W and S
    
    Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

    if (inputDirection >= 0.1f)
    {
      Vector3 cameraForward = camera.forward;
      cameraForward.y = 0f //this is to prevent my model from going crazy and tilting weirdly when i look up or down
      cameraForward.Normalize();

      Vector3 moveDir = cameraForward * inputDirection.z + cameraTransform.right * inputDirection.x;
    }
  }


}
