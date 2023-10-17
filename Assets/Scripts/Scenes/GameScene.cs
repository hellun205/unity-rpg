using Controller;
using Manager;
using UI.Scene;
using Util;

namespace Scenes
{
  public class GameScene : BaseScene
  {
    public override Define.Scene sceneType => Define.Scene.Game;

    public override void Clear()
    {
      
    }

    protected override void Init()
    {
      base.Init();
      gameObject.GetOrAddComponent<CursorController>();
      // Managers.UI.ShowSceneUI<UI_Inven>("UI_Inven");
    }
  }
}