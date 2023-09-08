using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Util;

namespace UI
{
  public class UI_Button : UI_Base
  {
    enum Buttons
    {
      PointButton
    }

    enum Texts
    {
      PointText,
      ScoreText,
    }

    enum GameObjects
    {
      TestObject
    }

    enum Images
    {
      ItemIcon
    }

    private void Start()
    {
      Bind<Button>(typeof(Buttons));
      Bind<TextMeshProUGUI>(typeof(Texts));
      Bind<GameObject>(typeof(GameObjects));
      Bind<Image>(typeof(Images));
      GetTextMeshProUGUI((int)Texts.ScoreText).text = "Bind Test2";

      GameObject go = GetImage((int)Images.ItemIcon).gameObject;
      UI_EventHandler ent = go.GetComponent<UI_EventHandler>();
      ent.OnDragHandler += data => { go.transform.position = data.position; };
      AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);

      GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);
    }

    private void OnButtonClicked(PointerEventData obj)
    {
      _score++;
      GetTextMeshProUGUI((int)Texts.ScoreText).text = $"score : {_score}";
    }


    private int _score = 0;
  }
}