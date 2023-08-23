using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Manager
{
  public class ResourceManager
  {
    public T Load<T>(string path) where T : Object
    {
      return Resources.Load<T>(path) ?? throw new Exception("Failed to load resource path: " + path);
    }

    public GameObject Instantiate(string path)
      => Object.Instantiate(Load<GameObject>(path));
  }
}