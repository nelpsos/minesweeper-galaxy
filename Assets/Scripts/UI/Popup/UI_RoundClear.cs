using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_RoundClear : UI_Popup
{
    public TextMeshProUGUI _title;

    enum GameObjects
    {
        UI_RoundClear,
        Grid_RepairItem_Info,
        Grid_Life,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        //
        Get<GameObject>((int)GameObjects.UI_RoundClear).BindEvent((PointerEventData) =>
        {
            Managers.UI.ClosePopupUI(this);
            Managers.GameManager.ChangeGameMode(Define.GameMode.Roadmap);
        });

        //Repair Item
        {
            GameObject gridPanel = Get<GameObject>((int)GameObjects.Grid_RepairItem_Info);
            foreach (Transform child in gridPanel.transform)
                Managers.Resource.Destroy(child.gameObject);

            for (int i = 0; i < Define.MAX_ROUND_INFO; i++)
            {
                GameObject item = Managers.UI.MakeSubItem<UI_RoundClear_Item>(gridPanel.transform).gameObject;
                UI_RoundClear_Item uiItem = item.GetOrAddComponent<UI_RoundClear_Item>();
                uiItem.SetRepairInfo(i);
            }
        }

        //Life Setting
        {
            GameObject gridPanel = Get<GameObject>((int)GameObjects.Grid_Life);
            foreach (Transform child in gridPanel.transform)
                Managers.Resource.Destroy(child.gameObject);

            for (int i = 0; i < Define.MAX_LIFE; i++)
            {
                GameObject item = Managers.UI.MakeSubItem<UI_LifeItem>(gridPanel.transform).gameObject;
                UI_LifeItem uiItem = item.GetOrAddComponent<UI_LifeItem>();

                uiItem.SetActivate(false);

                if (Managers.GameManager.Life > i)
                    uiItem.SetActivate(true);
                
            }
        }

        _title.text = $"Round {Managers.GameManager.Round}";
    }

}
