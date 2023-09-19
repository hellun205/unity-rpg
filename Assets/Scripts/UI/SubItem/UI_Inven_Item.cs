using TMPro;
using UnityEngine;

namespace UI.SubItem
{
  public class UI_Inven_Item : UI_Base
  {
    private string _name;
    
    public override void Init()
    {
      GetEventHandler().onClick += _ => Debug.Log($"아이템 클릭: {_name}");
    }

    public void SetInfo(string name)
    {
      _name = name;
      GetBinding<TextMeshProUGUI>("name").text = _name;
    }
  }
}