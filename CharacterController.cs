using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
  [Header("Refs")]
  public Transform cameraTransform;
  public Rigidbody rb;
  [Header("Speed and other stuff")]
  public float jumpForce = 3f;
  public float speed = 10f;
  private bool isMovingForward;

  void Start()
  {
    isMovingForward = (Input.GetKey(KeyCode.W));
  }

  void FixedUpdate()
  {
    if isMovingForward
    {
      Vector3 cameraForward = cameraTransform.forward;
      cameraForward.y = 0f; // to prevent players from walking on air
      cameraForward.Normalize();

      // i am not joking this will literally turn your player into a ROCKET. the only reason why im leaving this in here is because its just funny. we will change this later.
      rb.AddForce(cameraForward * speed, ForceMode.VelocityChange);
    }
  }
}
