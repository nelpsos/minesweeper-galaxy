using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ESC : UI_Popup
{
    enum Buttons
    {
        Setting,
        Exit,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

		Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.Setting).gameObject.BindEvent(OnButtonSetting);
        GetButton((int)Buttons.Exit).gameObject.BindEvent(OnButtonExit);
    }

    public void OnButtonSetting(PointerEventData data)
    {
        Managers.GameManager.GameStart(5,5,5);
    }

    public void OnButtonExit(PointerEventData data)
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
