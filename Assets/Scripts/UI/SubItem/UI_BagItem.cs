using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_BagItem : UI_Base
{
    public Image _icon;
    public TextMeshProUGUI _count;

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

        //Get<GameObject>((int)GameObjects.Inventory_Item_Icon).BindEvent((PointerEventData) => { Debug.Log($"아이템 클릭! {_name}"); });
    }

    public void SetBagItemIcon(string icon)
    {
        _icon.sprite = Resources.Load<Sprite>(icon) as Sprite;
    }

    public void SetItemCount(int count)
    {
        _count.text = count.ToString();
    }

}
