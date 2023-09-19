using System;
using System.Collections.Generic;
using Manager;
using UI;
using UI.Scene;
using UnityEngine;
using Util;

namespace Controller
{
  public enum PlayerState
  {
    Die,
    Moving,
    Idle
  }

  public class PlayerController : MonoBehaviour
  {
    public float moveSpeed = 1f;
    private bool move;

    private Vector3 _destPos;
    private Animator anim;

    private PlayerState state = PlayerState.Idle;

    private Dictionary<PlayerState, Action> stateAction;

    private void Start()
    {
      anim = GetComponent<Animator>();
      stateAction = new()
      {
        { PlayerState.Die, UpdateDie },
        { PlayerState.Idle, UpdateIdle },
        { PlayerState.Moving, UpdateMoving }
      };
      Managers.Init();
      Managers.Input.MouseAction += MouseAction;


    }

    private void UpdateMoving()
    {
      var dir = _destPos - transform.position;
      if (dir.magnitude < 0.00001f)
      {
        state = PlayerState.Idle;
        return;
      }

      var moveDist = Math.Clamp(moveSpeed * Time.deltaTime, 0, dir.magnitude);
      transform.position += dir.normalized * moveDist;
      if (dir.magnitude > 0.01f)
      {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir),
          10 * Time.deltaTime);
      }

      anim.SetBool("run", true);
    }

    private void UpdateIdle()
    {
      anim.SetBool("run", false);
    }

    private void UpdateDie()
    {
      Debug.Log("Player die!!!!!");
    }

    private void Update()
    {
      stateAction[state].Invoke();
    }

    private void MouseAction(Define.MouseEvent obj)
    {
      if (state == PlayerState.Die)
        return;

      var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

      if (Physics.Raycast(ray, out var hit, 100, LayerMask.GetMask("Wall")))
      {
        _destPos = hit.point;
        state = PlayerState.Moving;
      }
    }
  }
}