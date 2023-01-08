using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Repair_Item : UI_Base
{
    public Image _icon;
    public TextMeshProUGUI _name;
    public TextMeshProUGUI _explanation;
    public TextMeshProUGUI _collect;

    enum GameObjects
    {
        UI_Repair_Item,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        //Get<GameObject>((int)GameObjects.UI_Animal_Info_Item).BindEvent((PointerEventData) => { Debug.Log($"아이템 클릭! {_name}"); });

    }

    public void SetRepairItemInfo(int index)
    {
        RepairItem repairItemData = Managers.Data.RepairItemDict[index];

        _icon.sprite = Resources.Load<Sprite>(repairItemData.resouce) as Sprite;
        _name.text = repairItemData.name;
        _explanation.text = repairItemData.explanation;
        _collect.text = "";
    }
}
