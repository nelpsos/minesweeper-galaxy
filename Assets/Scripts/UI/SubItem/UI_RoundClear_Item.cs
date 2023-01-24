using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_RoundClear_Item : UI_Base
{
    public Image _icon;
    public TextMeshProUGUI _name;
    public TextMeshProUGUI _explanation;

    private UI_Tooltips _tooltips;

    enum GameObjects
    {
        UI_RoundClear_item,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        Get<GameObject>((int)GameObjects.UI_RoundClear_item).BindEvent((PointerEventData) =>
        {
            _tooltips = Managers.UI.ShowPopupUI<UI_Tooltips>("UI_Tooltips");
            _tooltips.SetText(_name.text, _explanation.text);
        });

    }

    public void SetRepairInfo(int repairIndex)
    {
        RepairTool repairData = Managers.Data.RepairItemDict[repairIndex];

        _icon.sprite = Resources.Load<Sprite>(repairData.resource) as Sprite;
        _name.text = repairData.name;
        _explanation.text = repairData.explain;
    }
}
