using Manager;
using TMPro;
using UnityEngine.EventSystems;

namespace UI
{
  public class UI_Button : UI_Popup
  {
    protected override void Awake()
    {
      base.Awake();
      GetBindingEventHandler("point_button").onClick += OnButtonClicked;
    }

    private void OnButtonClicked(PointerEventData eventdata)
    {
      Managers.UI.ClosePopup(this);
      _score++;
      GetBinding<TextMeshProUGUI>("score_text").text = $"score: {_score}";
    }


    private int _score = 0;
  }
}