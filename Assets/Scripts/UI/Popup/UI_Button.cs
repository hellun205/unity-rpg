using TMPro;
using UnityEngine.EventSystems;

namespace UI.Popup
{
  public class UI_Button : UI_Popup
  {
    public override void Init()
    {
      base.Init();
            
      GetBindingEventHandler("point_button").onClick += OnButtonClicked;
      GetBindingEventHandler("close_button").onClick += _ => ClosePopup();
    }

    private void OnButtonClicked(PointerEventData eventData)
    {
      _score++;
      GetBinding<TextMeshProUGUI>("score_text").text = $"score: {_score}";
    }
    
    private int _score = 0;
  }
}