using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Manager
{
  public enum InputType
  {
    KeyDown,
    KeyUp,
    Press
  }

  public class InputManager
  {
    public delegate void KeyEventListener(KeyCode key);
    
    public event KeyEventListener KeyDownEvent;
    public event KeyEventListener KeyUpEvent;
    public event KeyEventListener KeyPressEvent;

    public List<KeyCode> UseKeys = new();

    private static Func<KeyCode, bool> GetCheckKeyFn(InputType type) => type switch
    {
      InputType.KeyDown => Input.GetKeyDown,
      InputType.KeyUp => Input.GetKeyUp,
      InputType.Press => Input.GetKey,
      _ => throw new NotImplementedException()
    };

    public static T Choose<T>(Dictionary<KeyCode, T> list, InputType type = InputType.KeyDown, T defValue = default)
    {
      if (!Input.anyKey) return defValue;

      foreach (var (key, value) in list)
      {
        if (GetCheckKeyFn(type).Invoke(key))
          return value;
      }

      return defValue;
    }

    public static void Invoke(Dictionary<KeyCode, Action<KeyCode>> fnList, InputType type = InputType.KeyDown,
      Action nothingFn = null, Action<KeyCode> globalFn = null)
    {
      if (!Input.anyKey)
      {
        nothingFn?.Invoke();
        return;
      }

      foreach (var (key, fn) in fnList)
      {
        if (!GetCheckKeyFn(type).Invoke(key)) continue;
        fn?.Invoke(key);
        globalFn?.Invoke(key);
        return;
      }

      nothingFn?.Invoke();
    }

    public void OnUpdate()
    {
      if (!Input.anyKey) return;

      foreach (var key in UseKeys.Distinct())
      {
        if (Input.GetKeyDown(key)) KeyDownEvent?.Invoke(key);
        if (Input.GetKeyUp(key)) KeyUpEvent?.Invoke(key);
        if (Input.GetKey(key)) KeyPressEvent?.Invoke(key);
      }
    }
  }
}