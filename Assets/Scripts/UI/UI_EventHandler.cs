using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
  public class UI_EventHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
  {
    public Action<PointerEventData> OnBeginDragHandler = null;
    public Action<PointerEventData> OnDragHandler = null;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
      if (OnBeginDragHandler != null)
        OnBeginDragHandler.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
      if (OnDragHandler != null)
        OnDragHandler.Invoke(eventData);
    }
  }
}