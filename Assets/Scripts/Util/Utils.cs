using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Util
{
  public static class Utils
  {
    public static void ForEach<T>(this T[] obj, Action<T, int, T[]> fn)
    {
      for (var i = 0; i < obj.Length; i++)
      {
        fn.Invoke(obj[i], i, obj);
      }
    }

    public static void ForEach<T>(this T[] obj, Action<T, int> fn)
    {
      for (var i = 0; i < obj.Length; i++)
      {
        fn.Invoke(obj[i], i);
      }
    }

    public static void ForEach<T>(this IEnumerable<T> obj, Action<T> fn)
    {
      foreach (var item in obj)
      {
        fn.Invoke(item);
      }
    }

    public static void Destroy(this Object obj, float t = 0f)
      => Object.Destroy(obj, t);

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
      Transform transform = FindChild<Transform>(go, name, recursive);
      if (transform == null)
        return null;
      return transform.gameObject;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
      if (go == null)
        return null;

      if (recursive == false)
      {
        for (int i = 0; i < go.transform.childCount; i++)
        {
          Transform transform = go.transform.GetChild(i);
          if (string.IsNullOrEmpty(name) || transform.name == name)
          {
            T component = transform.GetComponent<T>();
            if (component != null)
            {
              return component;
            }
          }
        }
      }
      else
      {
        foreach (T component in go.GetComponentsInChildren<T>())
        {
          if (string.IsNullOrEmpty(name) || component.name == name)
            return component;
        }
      }

      return null;
    }
  
    public static T GetOrAddComponent<T>(GameObject go) where T : Component
    {
      T component = go.GetComponent<T>();
      if (component == null)
        component = go.AddComponent<T>();

      return component;
    }
  }
}