using System;
using Manager;
using UI.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

namespace Scenes
{
  public class LoginScene : BaseScene
  {
    public override Define.Scene sceneType => Define.Scene.Login;

    public override void Clear()
    {
      Debug.Log("login scene clear");
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Q))
      {
        Managers.Scene.Load(Define.Scene.Game);
      }
    }
  }
}