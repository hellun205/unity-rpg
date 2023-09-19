using System;
using Manager;
using UnityEngine;
using Util;

namespace UI
{
  public abstract class UI_Base : MonoBehaviour
  {
    protected virtual char bindingCheck => '*';
    protected Bind bind;

    protected virtual void Awake()
    {
      bind = new Bind(this, bindingCheck);
    }

    protected T GetBinding<T>(string _name) where T : Component
      => bind.Get<T>(_name);

    protected GameObject GetBinding(string _name)
      => bind.Get(_name);

    protected UIEventHandler GetBindingEventHandler(string _name)
      => GetBinding(_name).GetEventHandler();

    protected UIEventHandler GetEventHandler()
      => gameObject.GetEventHandler();

    public abstract void Init();
    
    private void Start()
    {
      Init();
    }
  }
}