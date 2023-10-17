using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Manager
{
  public class ResourceManager
  {
    public T Load<T>(string path) where T : Object
    {
      if (typeof(T) == typeof(GameObject))
      {
        string name = path;
        int index = name.LastIndexOf('/');
        if (index >= 0)
          name = name.Substring(index + 1);

        GameObject go = Managers.Pool.GetOriginal(name);
        if (go != null)
          return go as T;
      }
      return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
      var original = Load<GameObject>($"Prefabs/{path}");
      if (original == null)
      {
        Debug.Log($"Failed to load prefab : {path}");
        return null;
      }

      if (original.GetComponent<Poolable>() != null)
      {
        return Managers.Pool.Pop(original, parent).gameObject;
      }
      else
      {
        var go = Object.Instantiate(original);
        go.name = original.name;
        return go;
      }
    }

    public void Destroy(GameObject go, float t = 0)
    {
      if (go == null)
        return;

      if (go.TryGetComponent<Poolable>(out var poolable))
        Managers.Pool.Push(poolable);
      else
        Object.Destroy(go, t);
    }
  }
}