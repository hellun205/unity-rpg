using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Test
{
  public class UIButton : MonoBehaviour
  {
    private Bind bind;
    private void Awake()
    {
      bind = new Bind(this);
    }
  }
}