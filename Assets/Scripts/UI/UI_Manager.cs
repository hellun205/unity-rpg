using System.Collections.Generic;
using Manager;
using UI.Popup;
using UI.Scene;
using UI.SubItem;
using Unity.VisualScripting;
using UnityEngine;

namespace UI
{
  public class UI_Manager : MonoBehaviour
  {
    private int _order = 0;
    private Stack<UI_Popup> _popupStack = new();

    public GameObject root
    {
      get
      {
        var r = GameObject.Find("@ui_root");
        if (r == null)
          r = new GameObject("@ui_root");
        return r;
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

    public UI_Popup ShowPopupUI(string prefabName )
    {
      var popup = Instantiate<UI_Popup>("UI/Popup", prefabName);
      _popupStack.Push(popup);

      popup.transform.SetParent(root.transform);
      return popup;
    }

    public T ShowPopupUI<T>(string prefabName ) where T : Component
      => ShowPopupUI(prefabName).GetOrAddComponent<T>();

    public UI_Scene ShowSceneUI(string prefabName)
    {
      var sceneUI = Instantiate<UI_Scene>("UI/Scene", prefabName);

      sceneUI.transform.SetParent(root.transform);
      return sceneUI;
    }

    public T ShowSceneUI<T>(string prefabName) where T : Component
      => ShowSceneUI(prefabName).GetOrAddComponent<T>();
    
    public UI_SubItem MakeSubItem(string prefabName, Transform parent = null)
    {
      var subItem = Instantiate<UI_SubItem>("UI/SubItem", prefabName);
      subItem.transform.SetParent(parent != null ? parent : root.transform);
      return subItem;
    }

    public T MakeSubItem<T>(string prefabName, Transform parent = null) where T : Component
      => MakeSubItem(prefabName, parent).GetOrAddComponent<T>();
    
    public UI_Base MakeWorldSpaceUI(string prefabName, Transform parent = null)
    {
      var go = Instantiate<UI_Base>("UI/WorldSpace", prefabName);
      go.transform.SetParent(parent != null ? parent : root.transform);

      var canvas = go.GetOrAddComponent<Canvas>();
      canvas.renderMode = RenderMode.WorldSpace;
      canvas.worldCamera = Camera.main;
      
      return go;
    }

    public T MakeWorldSpaceUI<T>(string prefabName, Transform parent = null) where T : Component
      => MakeWorldSpaceUI(prefabName, parent).GetOrAddComponent<T>();


    private T Instantiate<T>(string path, string prefabName) where T : Component
      => Managers.Resource.Instantiate($"{path}/{prefabName}").GetOrAddComponent<T>();
    
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