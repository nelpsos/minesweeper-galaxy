using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Life_Item : UI_Base
{
    enum GameObjects
    {
        Life_Item_Icon,
    }

    string _name;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        Get<GameObject>((int)GameObjects.Life_Item_Icon).BindEvent((PointerEventData) => { Debug.Log($"아이템 클릭! {_name}"); });
    }

    public void SetInfo(string name)
    {
        _name = name;
    }
}
