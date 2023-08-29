using Manager;
using UnityEngine;

namespace Player
{
  public class PlayerController : MonoBehaviour
  {
    public float moveSpeed = 1f;
    private Vector3 _yAngle = Vector3.forward;
    private bool move;

    private bool _moveToDest = false;
    private Vector3 _destPos;

    private void Start()
    {
      Managers.Init();
      Managers.Input.KeyAction += OnKey;
      Managers.Input.MouseAction += MouseAction;
    }
    
    private void Update()
    {
      if (_moveToDest)
      {
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.0001f)
        {
          _moveToDest = false;
        }
        else
        {
          transform.position += dir.normalized * moveSpeed * Time.deltaTime;
          transform.LookAt(_destPos);
        }
      }
    }

    private void MouseAction(Define.MouseEvent obj)
    {
      if (obj != Define.MouseEvent.Click) return;
      Debug.Log("OnMouseClicked !");

      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

      RaycastHit hit;
      if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Wall")))
      {
        _destPos = hit.point;
        _moveToDest = true;
      }
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
  }
}