using System;
using Manager;
using UnityEngine;

namespace Extend
{
  public abstract class ExtendMonoBehaviour : MonoBehaviour, IUseKey
  {
    private KeyCode[] useKeys;

    protected virtual void Awake()
    {
      Managers.Input.KeyDownEvent += OnKeyDown;
      Managers.Input.KeyPressEvent += OnKeyPress;
      Managers.Input.KeyUpEvent += OnKeyUp;
    }

    protected virtual void OnDestroy()
    {
      Managers.Input.KeyDownEvent -= OnKeyDown;
      Managers.Input.KeyPressEvent -= OnKeyPress;
      Managers.Input.KeyUpEvent -= OnKeyUp;
      useKeys.ForEach(value => Managers.Input.UseKeys.Remove(value));
    }

    protected void UseKeys(KeyCode[] keys)
    {
      Managers.Input.UseKeys.AddRange(keys);
      useKeys = keys;
    }

    protected virtual void OnKeyDown(KeyCode key)
    {
    }

    protected virtual void OnKeyPress(KeyCode key)
    {
    }

    protected virtual void OnKeyUp(KeyCode key)
    {
    }
  }
}