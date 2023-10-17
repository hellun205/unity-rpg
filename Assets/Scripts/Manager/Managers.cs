using System;
using System.Linq;
using System.Reflection;
using UI;
using UnityEngine;

namespace Manager
{
  public class Managers : MonoBehaviour
  {
    private static Managers s_Instance;
    private static InputManager s_input = new();
    private static ResourceManager s_resource = new();
    private static SceneManagerEx s_scene = new();
    private static SoundManager s_sound = new();
    private static PoolManager s_pool = new();
    private static DataManager s_data = new();

    public static Managers Instance
    {
      get
      {
        Init();
        return s_Instance;
      }
    }

    public static InputManager Input => s_input;
    public static ResourceManager Resource => s_resource;
    public static SceneManagerEx Scene => s_scene;
    public static UI_Manager UI { get; private set; }
    public static SoundManager Sound => s_sound;
    public static PoolManager Pool => s_pool;
    public static DataManager Data => s_data;

    public IClearable[] clearables;
    public IInitialable[] initialables;

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

    private void Start()
    {
      var fields = typeof(Managers).GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
      clearables = fields.Select(f => f.GetValue(Instance)).OfType<IClearable>().ToArray();
      initialables = fields.Select(f => f.GetValue(Instance)).OfType<IInitialable>().ToArray();

      foreach (var initialable in initialables)
        initialable.Init();
    }

    public void Clear()
    {
      foreach (var manager in clearables)
      {
        manager.Clear();
      }
    }
  }
}