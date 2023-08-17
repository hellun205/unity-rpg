using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
  private static Managers s_Instance;

  public static Managers Instance
  {
    get
    {
      Init();
      return s_Instance;
    }
  }

  public void Start()
  {
    Init();
  }

  private static void Init()
  {
    if (s_Instance is not null) return;
    
    var go = GameObject.Find("@Managers");
    if (go is  null)
    {
      go = new GameObject { name = "@Managers" };
      go.AddComponent<Managers>();
    }

    DontDestroyOnLoad(go);
    s_Instance = go.GetComponent<Managers>();
  }
}