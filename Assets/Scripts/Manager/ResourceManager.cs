using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Manager
{
  public class ResourceManager
  {
    public T Load<T>(string path) where T : Object
    {
      return Resources.Load<T>($"Prefabs/{path}") ?? throw new Exception("Failed to load resource path: " + path);
    }

    public GameObject Instantiate(string path)
    {
      var obj = Object.Instantiate(Load<GameObject>(path));
      obj.name = obj.name.Replace("(Clone)", "");
      return obj;
    }
  }
}