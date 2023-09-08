using UnityEngine;
using Util;

namespace UI
{
  public class UI_Base : MonoBehaviour
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
  }
}