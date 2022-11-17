using System;
using System.Collections;
using System.Collections.Generic;
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

    enum Texts
    {
        PointText,
        ScoreText,
    }

    //public enum Images
    //{
    //    ItemIcon,
    //}

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

		Bind<Button>(typeof(Buttons));
        //Bind<Text>(typeof(Texts));
        //Bind<Image>(typeof(Images));

        GetButton((int)Buttons.GameStart).gameObject.BindEvent(OnButtonGameStart);
        GetButton((int)Buttons.CameraZoomUp).gameObject.BindEvent(OnButtonCameraZoomUp);
        GetButton((int)Buttons.CameraZoomDown).gameObject.BindEvent(OnButtonCameraZoomDown);

        //GetButton((int)Buttons.GameStart).gameObject.BindEvent(OnButtonClicked);

        //GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        //BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
    }

    public void OnButtonGameStart(PointerEventData data)
    {
        Debug.Log("Test Click");
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
