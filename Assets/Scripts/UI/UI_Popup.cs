using System;
using Manager;
using UnityEngine;

namespace UI
{
  public class UI_Popup : UI_Base
  {
    public virtual void Init()
    {
      Managers.UI.SetCanvas(gameObject, true);
    }

    protected virtual void Start()
    {
      Init();
    }

    public virtual void ClosePopup()
    {
      Managers.UI.ClosePopup(this);
    }
  }
}