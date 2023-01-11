using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_RepairItemReward : UI_Popup
{
    const int MAX_REIPAIR_ITEM = 3;

    enum GameObjects
    {
        Grid_Life,
        Grid_Repair_Item
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        //
        GameObject gridPanel = Get<GameObject>((int)GameObjects.Grid_Repair_Item);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        // 실제 인벤토리 정보를 참고해서
        for (int i = 0; i < MAX_REIPAIR_ITEM; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Repair_Item>(gridPanel.transform).gameObject;
            UI_Repair_Item uiItem = item.GetOrAddComponent<UI_Repair_Item>();
            uiItem.SetRepairItemInfo("생명 그릇 조각");
        }

        //
        gridPanel = Get<GameObject>((int)GameObjects.Grid_Life);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        for (int i = 0; i < Define.MAX_LIFE; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Life_Item>(gridPanel.transform).gameObject;
            UI_Life_Item uiItem = item.GetOrAddComponent<UI_Life_Item>();
        }
    }

    public void SetAnimalData()
    {

    }

}
