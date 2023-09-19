using System;
using UI;
using UnityEngine;

namespace Manager
{
  public class Managers : MonoBehaviour
  {
    private static Managers s_Instance;
    private static InputManager s_input;
    private static ResourceManager s_resource;

    public static Managers Instance
    {
      get
      {
        Init();
        return s_Instance;
      }
    }

    public static InputManager Input => s_input ??= new InputManager();
    public static ResourceManager Resource => s_resource ??= new ResourceManager();
    public static UI_Manager UI { get; private set; }

    public void Awake()
    {
      Init();
    }

    public static void Init()
    {
      if (s_Instance is not null) return;
      UI = FindObjectOfType<UI_Manager>();

      var go = GameObject.Find("@Managers");
      if (go is null)
      {
        go = new GameObject { name = "@Managers" };
        go.AddComponent<Managers>();
      }

      DontDestroyOnLoad(go);
      s_Instance = go.GetComponent<Managers>();
    }

    private void Update()
    {
      Input.OnUpdate();
    }
  }
}