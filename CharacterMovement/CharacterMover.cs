using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
  [Header("Refs")]
  public Transform cameraTransform;
  public Rigidbody rb;
  [Header("Speed and other stuff")]
  public float speed = 2f;
  private bool isMovingForward;
  private float playerSpeed
  void Start()
  {

  }
  void Update()
  {
    isMovingForward = (Input.GetKey(KeyCode.W));
    playerSpeed = rb.velocity.magnitude;
  }
  void FixedUpdate()
  {
    if (isMovingForward)
    {
      Vector3 cameraForward = cameraTransform.forward;
      cameraForward.y = 0f; // to prevent players from walking on air
      cameraForward.Normalize();

      // i am not joking this will literally turn your player into a ROCKET. the only reason why im leaving this in here is because its just funny. we will change this later.
      rb.AddForce(cameraForward * (speed * playerSpeed + 2), ForceMode.VelocityChange);
    }
  }
}
