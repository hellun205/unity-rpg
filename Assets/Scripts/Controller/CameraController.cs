using System;
using UnityEngine;

namespace Controller
{
  public class CameraController : MonoBehaviour
  {
    public Vector3 delta;
    public GameObject player;
    public Define.CameraView view = Define.CameraView.QuaterView;

    private void LateUpdate()
    {
      transform.position = player.transform.position + delta;

    }

    private void SetQuaterView(Vector3 delta)
    {
      view = Define.CameraView.QuaterView;
      this.delta = delta;
    }
  }
}