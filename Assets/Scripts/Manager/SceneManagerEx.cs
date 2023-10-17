using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

namespace Manager
{
  public class SceneManagerEx : IClearable
  {
    public BaseScene CurrentScene => Object.FindObjectOfType<BaseScene>();

    public void Load(Define.Scene scene)
    {
      Managers.Instance.Clear();
      SceneManager.LoadScene(scene.ToString());
    }

    public void Clear()
    {
      CurrentScene.Clear();
    }
  }
}