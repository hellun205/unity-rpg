using System;
using System.Collections.Generic;
using Extend;
using Manager;
using UnityEngine;

public class Player : ExtendMonoBehaviour
{
  public float moveSpeed = 1f;
  private Vector3 _yAngle;

  protected override void Awake()
  {
    base.Awake();
    UseKeys(new[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D });
  }

  protected override void OnKeyPress(KeyCode key)
  {
    _yAngle = key switch
    {
      KeyCode.W => Vector3.forward,
      KeyCode.A => Vector3.left,
      KeyCode.S => Vector3.back,
      KeyCode.D => Vector3.right,
      _ => _yAngle
    };
    
    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_yAngle), Time.deltaTime * 10f);
    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
  }

  private void Walk()
  {
    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
  }
}