using System.Collections.Generic;
using Manager;
using UnityEngine;

namespace UI
{
  public class UI_Manager : MonoBehaviour
  {
    private int _order = 0;
    private Stack<UI_Popup> _popupStack = new();

    public UI_Popup ShowPopupUI(string prefabName = "UIButton")
    {
      var popup = Managers.Resource.Instantiate($"UI/Popup/{prefabName}").GetComponent<UI_Popup>();
      _popupStack.Push(popup);
      return popup;
    }

    public T ShowPopupUI<T>(string prefabName = "UIButton") where T : Component
      => ShowPopupUI(prefabName).GetComponent<T>();

    public void ClosePopup(UI_Popup popup)
    {
      if (_popupStack.Peek() == popup)
      {
        ClosePopup();
      }
      else
        Debug.Log("close failed");
    }

    public void ClosePopup()
    {
      if (!_popupStack.TryPop(out var p)) return;
      Destroy(p.gameObject);
    }

    public void CloseAllPopup()
    {
      while (_popupStack.Count > 0)
      {
        _popupStack.Pop();
      }
    }
  }
}