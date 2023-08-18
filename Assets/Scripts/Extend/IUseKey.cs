using System.Diagnostics.CodeAnalysis;
using Manager;
using UnityEngine;

namespace Extend
{
  public interface IUseKey
  {
    protected virtual void OnKeyDown(KeyCode key)
    {
    }

    protected virtual void OnKeyPress(KeyCode key)
    {
    }

    protected virtual void OnKeyUp(KeyCode key)
    {
    }

    protected virtual void UseKeys(KeyCode[] keys) => Managers.Input.UseKeys.AddRange(keys);
  }
}