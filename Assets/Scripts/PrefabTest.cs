using Manager;
using UnityEngine;

namespace DefaultNamespace
{
  public class PrefabTest : MonoBehaviour
  {
    private void Start()
    {
      var tank = Managers.Resource.Instantiate("Tank");
      Destroy(tank, 3.0f);
    }
  }
}