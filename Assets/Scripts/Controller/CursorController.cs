using System;
using Manager;
using UnityEngine;
using Util;

namespace Controller
{
  public class CursorController : MonoBehaviour
  {
    public enum CursorType
    {
      None,
      Attack,
      Hand
    }

    private CursorType cursorType = CursorType.None;
    
    private Texture2D attackIcon;
    private Texture2D handIcon;
    
    private void Start()
    {
      attackIcon = Managers.Resource.Load<Texture2D>("Textures/Cursor/Attack");
      handIcon = Managers.Resource.Load<Texture2D>("Textures/Cursor/Hand");
    }

    private void Update()
    {
      if (Input.GetMouseButton(0))
        return;
      
      var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(ray, out var hit, 100))
      {
        
        if (hit.collider.gameObject.layer == Define.Layer.Monster.GetLayer())
        {
          if (cursorType != CursorType.Attack)
          {
            cursorType = CursorType.Attack;
            Cursor.SetCursor(attackIcon, new Vector2(attackIcon.width / 5, 0),CursorMode.Auto);
          }
        }
        else
        {
          if (cursorType != CursorType.Hand)
          {
            cursorType = CursorType.Hand;
            Cursor.SetCursor(handIcon, new Vector2(attackIcon.width / 3, 0),CursorMode.Auto);
          }
        }
      }
    }

    private void OnDestroy()
    {
      Cursor.SetCursor(null,Vector2.zero, CursorMode.ForceSoftware);
    }
  }
}