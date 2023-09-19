using Manager;
using UI.SubItem;
using UnityEngine;
using Util;

namespace UI.Scene
{
  public class UI_Inven : UI_Scene
  {
    public override void Init()
    {
      base.Init();
      var gridPanel = GetBinding("content");
      foreach (Transform child in gridPanel.transform)
        Destroy(child.gameObject);

      for (var i = 0; i < 8; i++)
      {
        var item = Managers.UI.MakeSubItem<UI_Inven_Item>("InventoryItem", gridPanel.transform);

        item.SetInfo($"집행검 {i}번");
      }
    }
  }
}