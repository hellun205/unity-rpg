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

    public T Instantiate<T>(string path) where T : Object
      => Object.Instantiate(Load<T>(path));
    
    public T Instantiate<T>(string path, Transform parent) where T : Object
      => Object.Instantiate(Load<T>(path), parent);
    
    public T Instantiate<T>(string path, Transform parent, bool instantiateInWorldSpace) where T : Object
      => Object.Instantiate(Load<T>(path), parent, instantiateInWorldSpace);
    
    public T Instantiate<T>(string path, Vector3 position, Quaternion rotation) where T : Object
      => Object.Instantiate(Load<T>(path), position, rotation);
    
    public T Instantiate<T>(string path, Vector3 position, Quaternion rotation, Transform parent) where T : Object
      => Object.Instantiate(Load<T>(path), position, rotation, parent);
  }
}