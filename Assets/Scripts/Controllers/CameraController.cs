using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Start()
    {
        Managers.GameManager.GameModeAction -= OnCameraReciveGameMode;
        Managers.GameManager.GameModeAction += OnCameraReciveGameMode;

        InitCameraResolution();
    }

    void LateUpdate()
    { 

    }

    private void OnPreCull() => GL.Clear(true, true, Color.black);

    private void InitCameraResolution()
    {
        //Camera camera = GetComponent<Camera>();
        //Rect rect = camera.rect;

        //float scaleHeight = ((float)Screen.width / Screen.height) / ((float)9 / 16);    //(가로 /세로)
        //float scaleWidth = 1f / scaleHeight;

        //if (scaleHeight < 1f)
        //{
        //    rect.height = scaleHeight;
        //    rect.y = (1f - scaleHeight) * 2f;
        //}
        //else
        //{
        //    rect.width = scaleWidth;
        //    rect.x = (1f - scaleWidth) * 2f;
        //}

        //camera.rect = rect;
    }
    

    void OnCameraReciveGameMode(Define.GameMode gameMode)
    {
        switch (gameMode)
        {
            case Define.GameMode.RoundInfo:
                Camera.main.orthographicSize = 5;
                Camera.main.transform.position = new Vector3(0, 1, -10);
                break;
            case Define.GameMode.Ready:
                Camera.main.orthographicSize = Managers.GameManager.CameraSize();
                Camera.main.transform.position = new Vector3(0, Managers.GameManager.CaemraPosition(), -10);
                break;
            case Define.GameMode.Play:
                break;
            case Define.GameMode.Pause:
                break;
            case Define.GameMode.GameOver:
                break;
            default:
                break;
        }
    }
}
