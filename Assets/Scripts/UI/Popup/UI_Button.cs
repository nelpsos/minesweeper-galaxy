using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    enum Buttons
    {
        GameStart,
        CameraZoomUp,
        CameraZoomDown
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

		Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.GameStart).gameObject.BindEvent(OnButtonGameStart);
        GetButton((int)Buttons.CameraZoomUp).gameObject.BindEvent(OnButtonCameraZoomUp);
        GetButton((int)Buttons.CameraZoomDown).gameObject.BindEvent(OnButtonCameraZoomDown);

        

        //Bind<Image>(typeof(Images));

        //GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        //BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
    }

    public void OnButtonGameStart(PointerEventData data)
    {
        Managers.GameManager.ChangeGameMode(Define.GameMode.RoundInfo);
    }

    public void OnButtonCameraZoomUp(PointerEventData data)
    {
        Camera.main.orthographicSize++;
        if (Camera.main.orthographicSize > 20)
            Camera.main.orthographicSize = 20;
    }

    public void OnButtonCameraZoomDown(PointerEventData data)
    {
        Camera.main.orthographicSize--;
        if (Camera.main.orthographicSize < 5)
            Camera.main.orthographicSize = 5;
    }
}
