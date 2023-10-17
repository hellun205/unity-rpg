using System;
using Manager;
using UnityEngine;
using Util;

namespace Test
{
  public class TestSound : MonoBehaviour
  {
    private void OnTriggerEnter(Collider other)
    {
      Managers.Sound.Play("UnityChan/univ0005", Define.Sound.Sfx);
      Managers.Sound.Play("UnityChan/univ0012", Define.Sound.Sfx);
    }
  }
}