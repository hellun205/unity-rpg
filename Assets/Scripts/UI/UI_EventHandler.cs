using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
  public class UI_EventHandler : MonoBehaviour, IDragHandler, IPointerClickHandler
  {
    public Action<PointerEventData> OnBeginDragHandler = null;
    public Action<PointerEventData> OnDragHandler = null;

    public Action<PointerEventData> OnClickHandler = null;

    public void OnDrag(PointerEventData eventData)
    {
      if (OnDragHandler != null)
        OnDragHandler.Invoke(eventData);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
      if (OnClickHandler != null)
        OnClickHandler.Invoke(eventData);
    }
  }
}