using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_BagItem : UI_Base
{
    public Image _icon;
    public RepairTool _repairToolData;
    public TextMeshProUGUI _countText;
    
    private int _count;
    private UI_Tooltips _tooltips;

    enum GameObjects
    {
        Bag_Item_Icon
    }

    //string _name;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        Get<GameObject>((int)GameObjects.Bag_Item_Icon).BindEvent((PointerEventData) => 
        {
            _tooltips = Managers.UI.ShowPopupUI<UI_Tooltips>("UI_Tooltips");
            _tooltips.SetText(_repairToolData.name, _repairToolData.explain);
            _tooltips.SetUseButton(true);
        });
    }

    public void SetBagItemTable(RepairTool repairToolData)
    {
        _repairToolData = repairToolData;
        _icon.sprite = Resources.Load<Sprite>(_repairToolData.resource) as Sprite;

    }

    public void SetItemCount(int count)
    {
        _count = count;
        //_countText.text = count.ToString();
    }


}
