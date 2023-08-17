using System;
using UnityEngine;

namespace DefaultNamespace
{
  public class Player : MonoBehaviour
  {
    private void Start()
    {
      var mg = Managers.GetInstance();
    }
  }
}