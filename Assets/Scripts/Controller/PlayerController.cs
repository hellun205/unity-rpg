using System;
using System.Collections.Generic;
using Contents;
using Manager;
using UI;
using UI.Scene;
using UnityEngine;
using UnityEngine.AI;
using Util;
using WorldSpace;

namespace Controller
{
  public class PlayerController : MonoBehaviour
  {
    public enum PlayerState
    {
      Die,
      Moving,
      Idle,
      Skill
    }


    // public float moveSpeed = 1f;
    public PlayerStat status { get; private set; }
    private bool move;

    private Vector3 _destPos;
    private Animator anim;

    private PlayerState _state = PlayerState.Idle;

    private PlayerState state
    {
      get => _state;
      set
      {
        _state = value;
        switch (_state)
        {
          case PlayerState.Idle:
            anim.CrossFade("WAIT", 0.1f);
            stopSkill = false;
            break;
          case PlayerState.Moving:
            anim.CrossFade("RUN", 0.1f);
            stopSkill = false;
            break;
          case PlayerState.Skill:
            anim.CrossFade("ATTACK", 0.1f, -1, 0);
            break;
        }
      }
    }

    private Dictionary<PlayerState, Action> stateAction;

    private GameObject lockTarget;

    private void Start()
    {
      status = GetComponent<PlayerStat>();
      anim = GetComponent<Animator>();
      stateAction = new()
      {
        { PlayerState.Die, UpdateDie },
        { PlayerState.Idle, UpdateIdle },
        { PlayerState.Moving, UpdateMoving },
        { PlayerState.Skill, UpdateSkill }
      };
      Managers.Init();
      Managers.Input.MouseAction += OnMouseEvent;
      Managers.UI.MakeWorldSpaceUI<UI_HpBar>("UI_HpBar", transform);
    }

    private void UpdateSkill()
    {
      if (lockTarget != null)
      {
        var dir = lockTarget.transform.position - transform.position;
        var quat = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
      }
    }

    private void OnHitEvent()
    {
      if (lockTarget == null || stopSkill)
        state = PlayerState.Idle;
    }

    private void UpdateMoving()
    {
      if (lockTarget != null)
      {
        if ((_destPos - transform.position).magnitude <= 1)
        {
          state = PlayerState.Skill;
          return;
        }
      }

      var dir = _destPos - transform.position;
      if (dir.magnitude < 0.1f)
      {
        state = PlayerState.Idle;
        return;
      }

      var moveDist = Math.Clamp(status.moveSpeed * Time.deltaTime, 0, dir.magnitude);

      var nav = GetComponent<NavMeshAgent>();
      nav.Move(dir.normalized * moveDist);

      // transform.position += dir.normalized * moveDist;

      if (Physics.Raycast(transform.position + Vector3.up * 0.5f, dir.normalized, 1.0f, Define.Layer.Block.GetMask()))
      {
        if (!Input.GetMouseButton(0))
          state = PlayerState.Idle;
        return;
      }

      if (dir.magnitude > 0.01f)
      {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir),
          10 * Time.deltaTime);
      }
    }

    private void UpdateIdle()
    {
    }

    private void UpdateDie()
    {
      Debug.Log("Player die!!!!!");
    }

    private void Update()
    {
      stateAction[state].Invoke();
    }

    public bool stopSkill;

    private void OnMouseEvent(Define.MouseEvent eventType)
    {
      if (state == PlayerState.Die)
        return;

      switch (state)
      {
        case PlayerState.Idle:
        case PlayerState.Moving:
          OnMouseEvent_IdleRun(eventType);
          break;
        case PlayerState.Skill:
          if (eventType == Define.MouseEvent.PointerUp)
            stopSkill = true;
          break;
      }
    }

    private void OnMouseEvent_IdleRun(Define.MouseEvent eventType)
    {
      var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      var isRaycast = Physics.Raycast(ray, out var hit, 100,
        Define.Layer.Ground.GetMask() | Define.Layer.Monster.GetMask());

      switch (eventType)
      {
        case Define.MouseEvent.PointerDown:
          if (isRaycast)
          {
            _destPos = hit.point;
            state = PlayerState.Moving;

            if (hit.collider.gameObject.layer == Define.Layer.Monster.GetLayer())
              lockTarget = hit.collider.gameObject;
            else
              lockTarget = null;
          }

          break;

        case Define.MouseEvent.Press:
          if (lockTarget == null && isRaycast)
            _destPos = hit.point;
          break;
        case Define.MouseEvent.PointerUp:
          stopSkill = true;
          break;
      }
    }
  }
}