﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    public enum Buttons
    {
        GameStart,
        ZoomUp,
        ZoomDown
    }

    public enum Texts
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

		//GetButton((int)Buttons.GameStart).gameObject.BindEvent(OnButtonClicked);

		//GameObject go = GetImage((int)Images.ItemIcon).gameObject;
		//BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
	}
}
