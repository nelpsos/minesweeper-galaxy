using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[SerializeField]
    //Define.CameraMode _mode = Define.CameraMode.QuarterView;

    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);

    //[SerializeField]
    //GameObject _player = null;

    void Start()
    {
        InitCameraResolution();
    }

    void LateUpdate()
    { 
  //      if (_mode == Define.CameraMode.QuarterView)
  //      {
  //          RaycastHit hit;
  //          if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
  //          {
  //              float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
  //              transform.position = _player.transform.position + _delta.normalized * dist;
  //          }
  //          else
  //          {
		//		transform.position = _player.transform.position + _delta;
		//		transform.LookAt(_player.transform);
		//	}
		//}
    }

    private void OnPreCull() => GL.Clear(true, true, Color.black);

    private void InitCameraResolution()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;

        float scaleHeight = ((float)Screen.width / Screen.height) / ((float)9 / 16);    //(가로 /세로)
        float scaleWidth = 1f / scaleHeight;

        if (scaleHeight < 1f)
        {
            rect.height = scaleHeight;
            rect.y = (1f - scaleHeight) * 2f;
        }
        else
        {
            rect.width = scaleWidth;
            rect.x = (1f - scaleWidth) * 2f;
        }

        camera.rect = rect;
    }
    
}
