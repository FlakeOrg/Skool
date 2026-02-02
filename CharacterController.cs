using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Monobehavior
{
  [Header("Refs")]
  public Transform cam;
  public Transform cam;
  [Header("Speed and other stuff")]
  public float jumpForce = 10f;

  void Start()
  {

  }

  void Update()
  {
    if (Input.GetKey(KeyCode.W))
    {
      
    }
  }
}
