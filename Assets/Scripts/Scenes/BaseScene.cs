using System;
using Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using Util;

namespace Scenes
{
  public abstract class BaseScene : MonoBehaviour
  {
    public abstract Define.Scene sceneType { get; }

    protected virtual void Init()
    {
      if (FindObjectOfType<EventSystem>() == null)
      {
        Managers.Resource.Instantiate("UI/EventSystem");
      }
    }

    public abstract void Clear();

    protected virtual void Awake()
    {
      Init();
    }
  }
}