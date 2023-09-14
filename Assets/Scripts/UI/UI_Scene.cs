using Manager;
using UnityEngine;

namespace UI
{
  public class UI_Scene : UI_Base
  {
    public virtual void Init()
    {
      Managers.UI.SetCanvas(gameObject, false);
    }
  }
}