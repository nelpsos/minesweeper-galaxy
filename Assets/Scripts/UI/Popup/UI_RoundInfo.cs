using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_RoundInfo : UI_Popup
{
    public TextMeshProUGUI _title;

    enum GameObjects
    {
        UI_RoundInfo,
        Grid_Animal_Info
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        Get<GameObject>((int)GameObjects.UI_RoundInfo).BindEvent((PointerEventData) =>
        {
            Managers.UI.ClosePopupUI(this);
            Managers.GameManager.ChangeGameMode(Define.GameMode.Ready);
        });

        GameObject gridPanel = Get<GameObject>((int)GameObjects.Grid_Animal_Info);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);
        
        for (int i = 0; i < Define.MAX_ROUND_INFO; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_RoundInfo_Item>(gridPanel.transform).gameObject;
            UI_RoundInfo_Item uiItem = item.GetOrAddComponent<UI_RoundInfo_Item>();
            uiItem.SetRoundAnimalInfo(i);
        }

        _title.text = $"Round {Managers.GameManager.Round}";
    }

}
