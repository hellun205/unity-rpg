using Manager;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
  private void Start()
  {
    var tank = Managers.Resource.Instantiate("Tank");
    Destroy(tank, 3.0f);
  }
}