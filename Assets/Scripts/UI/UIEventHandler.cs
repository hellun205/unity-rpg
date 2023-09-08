using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
  public class UIEventHandler : MonoBehaviour, IDragHandler, IPointerClickHandler, IBeginDragHandler, IPointerUpHandler,
    IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler, IEndDragHandler, IDropHandler
  {
    public delegate void PointerEventListener(PointerEventData eventData);

    public event PointerEventListener onClick;
    public event PointerEventListener onDrag;
    public event PointerEventListener onBeginDrag;
    public event PointerEventListener onMouseDown;
    public event PointerEventListener onMouseUp;
    public event PointerEventListener onMouseEnter;
    public event PointerEventListener onMouseExit;
    public event PointerEventListener onMouseMove;
    public event PointerEventListener onEndDrag;
    public event PointerEventListener onDrop;

    public void OnDrag(PointerEventData eventData) => onDrag?.Invoke(eventData);
    public void OnPointerClick(PointerEventData eventData) => onClick?.Invoke(eventData);
    public void OnBeginDrag(PointerEventData eventData) => onBeginDrag?.Invoke(eventData);
    public void OnPointerUp(PointerEventData eventData) => onMouseUp?.Invoke(eventData);
    public void OnPointerDown(PointerEventData eventData) => onMouseDown?.Invoke(eventData);
    public void OnPointerEnter(PointerEventData eventData) => onMouseEnter?.Invoke(eventData);
    public void OnPointerExit(PointerEventData eventData) => onMouseExit?.Invoke(eventData);
    public void OnPointerMove(PointerEventData eventData) => onMouseMove?.Invoke(eventData);
    public void OnEndDrag(PointerEventData eventData)=> onEndDrag?.Invoke(eventData);
    public void OnDrop(PointerEventData eventData)=> onDrop?.Invoke(eventData);
  }
}