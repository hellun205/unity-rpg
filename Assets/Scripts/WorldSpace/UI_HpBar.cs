using UI;
using UnityEngine;

namespace WorldSpace
{
  public class UI_HpBar : UI_Base
  {
    public override void Init()
    {
    }

    private void Update()
    {
      var parent = transform.parent;
      transform.position = parent.position + Vector3.up * (parent.GetComponent<Collider>().bounds.size.y);
      transform.rotation = Camera.main!.transform.rotation;
    }
  }
}