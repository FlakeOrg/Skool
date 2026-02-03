using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
  [Header("Refs")]
  public Transform cameraTransform;
  public Rigidbody rb;
  public Transform player;
  [Header("Speed and other stuff")]
  public float jumpForce = 3f;
  public float speed = 10f;
  private bool isMovingForward;

  void Start()
  {
    rb.freezeRotation = true;
  }

  void FixedUpdate()
  {
    isMovingForward = (Input.GetKey(KeyCode.W));
    if (isMovingForward)
    {
      Vector3 cameraForward = cameraTransform.forward;
      cameraForward.y = 0f; // to prevent players from walking on air
      cameraForward.Normalize();
      
      Vector3 playerForward = player.forward;
      float playerSpeed = rb.velocity.magnitude;
      
      if (playerSpeed <= speed)
      {
        rb.AddForce(cameraForward * (speed - playerSpeed), ForceMode.VelocityChange);
      }
      else
      {
        if (playerSpeed >= 25)
        {
          rb.freezeRotation = false; // for trying to break the laws of physics
          speed = 0;
          Debug.Log("lil bro fell skill issue");
          Invoke("getUp", 5.0f);
        }
      }
      Debug.DrawRay (player.position, playerForward * (2f * playerSpeed), Color.green, 1f);
    
    }
  }
  void getUp()
  {
    
  }
}
