using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Managers : MonoBehaviour
{
  private static Managers Instance;

  public static Managers GetInstance()
  {
    Init();
    return Instance;
  }

  public void Start()
  {
    Init();
  }

  private static void Init()
  {
    if (Instance is not null) return;
    
    var go = GameObject.Find("@Managers");
    if (go is  null)
    {
      go = new GameObject { name = "@Managers" };
      go.AddComponent<Managers>();
    }

    DontDestroyOnLoad(go);
    Instance = go.GetComponent<Managers>();
  }
}