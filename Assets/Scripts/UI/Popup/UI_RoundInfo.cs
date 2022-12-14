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
    const int MAX_INFO = 3;

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
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.Grid_Animal_Info);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        // 실제 인벤토리 정보를 참고해서
        for (int i = 0; i < MAX_INFO; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Animal_Info_Item>(gridPanel.transform).gameObject;
            UI_Animal_Info_Item uiItem = item.GetOrAddComponent<UI_Animal_Info_Item>();
            uiItem.SetInfo(i);
        }

    }

    public void SetAnimalData()
    {

    }

}
