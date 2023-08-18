using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

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
}