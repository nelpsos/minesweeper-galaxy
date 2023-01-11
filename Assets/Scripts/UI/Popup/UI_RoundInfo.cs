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
    const int MAX_ROUND_INFO = 3;

    enum GameObjects
    {
        Grid_Animal_Info
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        Get<GameObject>((int)GameObjects.Grid_Animal_Info).BindEvent((PointerEventData) =>
        {
            Managers.UI.ClosePopupUI(this);
            Managers.GameManager.ChangeGameMode(Define.GameMode.Ready);
        });
    }

    public void SetRoundInfo(int round)
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.Grid_Animal_Info);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);


        for (int i = 0; i < MAX_ROUND_INFO; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Round_Animal_Info_Item>(gridPanel.transform).gameObject;
            UI_Round_Animal_Info_Item uiItem = item.GetOrAddComponent<UI_Round_Animal_Info_Item>();

            uiItem.SetRoundAnimalInfo(i);
        }
    }

  
}
