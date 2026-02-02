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

  void Start()
  {

  }

  void FixedUpdate()
  {
    if (Input.GetKey(KeyCode.W))
    {
      Vector3 cameraForward = cameraTransform.forward;
      cameraForward.y = 0f; // to prevent players from walking on air
      cameraForward.Normalize();

      rb.AddForce(cameraForward * speed, ForceMode.VelocityChange);
    }
  }
}
