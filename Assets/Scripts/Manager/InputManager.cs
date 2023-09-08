using System;
using UnityEngine;
using Util;

namespace Manager
{
  public class InputManager
  {
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    private bool isPressed;
    
    public void OnUpdate()
    {
      if (Input.anyKey != false)
        KeyAction?.Invoke();

      if (MouseAction != null)
      {
        if (Input.GetMouseButton(0))
        {
          MouseAction.Invoke(Define.MouseEvent.Press);
          isPressed = true;
        }
        else
        {
          if (isPressed)
          {
            MouseAction.Invoke(Define.MouseEvent.Click);
            isPressed = false;
          }
        }
      } else
      {
        
      }
    }
  }
}