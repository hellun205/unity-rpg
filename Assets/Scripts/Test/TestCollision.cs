using System;
using UnityEngine;

namespace Test
{
  public class TestCollision : MonoBehaviour
  {
    private void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

        var mask = LayerMask.GetMask("Monster", "Wall");

        if (Physics.Raycast(ray, out var hit, 100, mask))
        {
          Debug.Log($"Raycast camera @{hit.collider.gameObject.name}");
        }

      }
    }
  }
}