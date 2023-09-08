using System;
using UnityEngine;
using Util;

namespace Controller
{
  public class CameraController : MonoBehaviour
  {
    public Vector3 delta;
    public GameObject player;
    public Define.CameraView view = Define.CameraView.QuaterView;

    private void LateUpdate()
    {
      if (Physics.Raycast(player.transform.position, delta, out var hit, delta.magnitude, LayerMask.GetMask("Wall")))
      {
        float dist = (hit.point - player.transform.position).magnitude * 0.8f;
        transform.position = player.transform.position + delta.normalized * dist;
      }
      else
      {
        transform.position = player.transform.position + delta;
        transform.LookAt(player.transform);
      }
    }

    private void SetQuaterView(Vector3 delta)
    {
      view = Define.CameraView.QuaterView;
      this.delta = delta;
    }
  }
}