using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Util;

namespace Manager
{
  public class InputManager : IClearable
  {
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    private bool isPressed;
    private float pressedTime;

    public void OnUpdate()
    {
      if (EventSystem.current.IsPointerOverGameObject())
        return;

      if (Input.anyKey)
        KeyAction?.Invoke();


      if (Input.GetMouseButton(0))
      {
        if (!isPressed)
        {
          MouseAction?.Invoke(Define.MouseEvent.PointerDown);
          pressedTime = Time.time;
        }

        MouseAction?.Invoke(Define.MouseEvent.Press);
        isPressed = true;
      }
      else
      {
        if (isPressed)
        {
          if (Time.time - pressedTime < 0.2f)
            MouseAction?.Invoke(Define.MouseEvent.Click);
          MouseAction?.Invoke(Define.MouseEvent.PointerUp);
          
        }

        isPressed = false;
        pressedTime = 0;
      }
    }

    public void Clear()
    {
      KeyAction = null;
      MouseAction = null;
    }
  }
}