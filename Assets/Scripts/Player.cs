using System;
using Manager;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float moveSpeed = 1f;

  private void Update()
  {
    var h = Input.GetAxis("Horizontal");
    var v = Input.GetAxis("Vertical");

    transform.Translate(new Vector3(h , 0, v )  * Time.deltaTime * moveSpeed);
  }
}