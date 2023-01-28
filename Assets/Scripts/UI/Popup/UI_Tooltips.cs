using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Tooltips : UI_Popup
{
    enum GameObjects
    {
        Panel_Tooltips
    }

    public TextMeshProUGUI _title;
    public TextMeshProUGUI _content;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        Get<GameObject>((int)GameObjects.Panel_Tooltips).BindEvent(
             (PointerEventData) =>
             {
                 Managers.UI.ClosePopupUI(this);
             });

    }

    public void SetText(string title, string content)
    {
        _title.text = title;
        _content.text = content;
    }

}
