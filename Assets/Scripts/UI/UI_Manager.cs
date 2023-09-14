using System.Collections.Generic;
using Manager;
using UnityEngine;

namespace UI
{
  public class UI_Manager : MonoBehaviour
  {
    private int _order = 0;
    private Stack<UI_Popup> _popupStack = new();

    public Transform root
    {
      get
      {
        var root = GameObject.Find("@ui_root");
        if (root == null)
          root = new GameObject("@ui_root");
        return root.transform;
      }
    }
    
    public void SetCanvas(GameObject go, bool sort = true)
    {
      var canvas = go.GetComponent<Canvas>();
      canvas.renderMode = RenderMode.ScreenSpaceOverlay;
      canvas.overrideSorting = true;

      if (sort)
      {
        canvas.sortingOrder = _order;
        _order++;
      }
      else
      {
        canvas.sortingOrder = 0;
      }
      
    }

    public UI_Popup ShowPopupUI(string prefabName = "UIButton")
    {
      var popup = Managers.Resource.Instantiate($"UI/Popup/{prefabName}").GetComponent<UI_Popup>();
      _popupStack.Push(popup);

      popup.transform.SetParent(root);
      return popup;
    }

    public T ShowPopupUI<T>(string prefabName = "UIButton") where T : Component
      => ShowPopupUI(prefabName).GetComponent<T>();

    public void ClosePopup(UI_Popup popup)
    {
      if (_popupStack.Peek() == popup)
      {
        ClosePopup();
        _order--;
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
        // _popupStack.Pop();
        ClosePopup();
      }
    }
  }
}