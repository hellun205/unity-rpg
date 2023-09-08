using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

      //Get<TextMeshProUGUI>((int)Texts.ScoreText).text = "Bind test";
      GetTextMeshProUGUI((int)Texts.ScoreText).text = "Bind Test2";

      GameObject go = GetImage((int)Images.ItemIcon).gameObject;
      UI_EventHandler ent = go.GetComponent<UI_EventHandler>();
      ent.OnDragHandler += data => { go.transform.position = data.position; };
    }


    private int _score = 0;

    public void OnButtonClicked()
    {
      _score++;
      //_text.text = $"점수 : {_score}";
    }
  }
}