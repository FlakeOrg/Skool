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
  private bool isMovingBackward;
  private bool isMovingRight;
  private bool isMovingLeft;
  private bool isDown;

  void Start()
  {
    rb.freezeRotation = true;
  }

  void FixedUpdate()
  {
    float playerSpeed = rb.velocity.magnitude;
    isMovingForward = (Input.GetKey(KeyCode.W));
    isMovingBackward = (Input.GetKey(KeyCode.S));
    isMovingRight = (Input.GetKey(KeyCode.D));
    isMovingLeft = (Input.GetKey(KeyCode.A));
    if (isMovingForward)
    {
      Vector3 cameraForward = cameraTransform.forward;
      cameraForward.y = 0f; // to prevent players from walking on air
      cameraForward.Normalize();
      
      Vector3 playerForward = player.forward;
      
      if (playerSpeed <= speed)
      {
        rb.AddForce(cameraForward * (speed - playerSpeed), ForceMode.VelocityChange);
      }
      else
      {
        if (playerSpeed >= 25 && isDown !false)
        {
          isDown = true;
          rb.freezeRotation = false; // for trying to break the laws of physics
          speed = 0;
          Debug.Log("lil bro fell skill issue");
          Invoke("getUp", 5.0f);
        }
      }
      Debug.DrawRay (player.position, cameraForward * (2f * playerSpeed), Color.green, 1f);
    
    }

    if (isMovingBackward)
    {
      Vector3 cameraBack = -cameraTransform.forward;
      cameraBack.y = 0f;
      cameraBack.Normalize();
      if (playerSpeed <= speed)
      {
        rb.AddForce(cameraBack * (speed - playerSpeed), ForceMode.VelocityChange);
      }
    }

    if(isMovingLeft)
    {
      Vector3 cameraLeft = -cameraTransform.right;
      cameraLeft.y = 0f;
      cameraBack.Normalize();
      if (playerSpeed <= speed)
      {
        rb.AddForce(cameraLeft * (speed - playerSpeed), ForceMode.VelocityChange);
      }
    }

    if(isMovingRight)
    {
      Vector3 cameraRight = cameraTransform.right;
      cameraRight.y = 0f;
      cameraRight.Normalize();
      if (playerSpeed <= speed)
      {
        rb.AddForce(cameraRight * (speed - playerSpeed), ForceMode.VelocityChange);
      }
    }
  }
  void getUp()
  {
    Debug.Log("gettin up now.");
    speed = 5;
  }
}
