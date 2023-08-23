using Manager;
using UnityEngine;

namespace Player
{
  public class PlayerController : MonoBehaviour
  {
    public float moveSpeed = 1f;
    private Vector3 _yAngle = Vector3.forward;
    private bool move;

    private void Awake()
    {
      Managers.Init();
      Managers.Input.KeyAction += OnKey;
    }

    private void OnKey()
    {
      if (Input.GetKey(KeyCode.W))
      {
        _yAngle = Vector3.forward;
        move = true;
      }
      else if (Input.GetKey(KeyCode.A))
      {
        _yAngle = Vector3.left;
        move = true;
      }
      else if (Input.GetKey(KeyCode.S))
      {
        _yAngle = Vector3.back;
        move = true;
      }
      else if (Input.GetKey(KeyCode.D))
      {
        _yAngle = Vector3.right;
        move = true;
      }
      else move = false;

      transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_yAngle), Time.deltaTime * 15f);
      transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * (move ? 1 : 0));
    }

    private void Update()
    {
    }
  }
}