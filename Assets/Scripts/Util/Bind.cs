using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Util
{
  public class Bind
  {
    public Dictionary<string, GameObject> objects;

    public Bind(MonoBehaviour mb, char findChr = '*')
    {
      objects = mb.transform
        .GetComponentsInChildren<Transform>()
        .Where(x => x.name.Contains(findChr))
        .ToDictionary(x => x.name.Replace(findChr.ToString(), ""), x => x.gameObject);
    }

    public T Get<T>(string name) where T : Component
    {
      return Get(name).GetComponent<T>();
    }

    public GameObject Get(string name)
    {
      if (!objects.ContainsKey(name))
        throw new Exception($"doesn't exist binding object name: {name}");

      return objects[name];
    }
  }
}