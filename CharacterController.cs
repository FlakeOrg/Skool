using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehavior
{
  [Header("Refs")]
  public Transform cameraTransform;
  public Transform player;
  [Header("Speed and other stuff")]
  public float jumpForce = 10f;
  public float speedDecay = .5f;

  void Start()
  {

  }

  void Update()
  {
    if (Input.GetKey(KeyCode.W))
    {
      Vector3 cameraForward = camera.forward;
      cameraForward.y = 0f; // to prevent players from walking on air
      cameraForward.Normalize()
      
    }
  }
}
