using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Animal_Item : UI_Base
{
 
    enum GameObjects
    {
        Animal_Item_Icon,
    }

    string _name;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        Get<GameObject>((int)GameObjects.Animal_Item_Icon).BindEvent(OnMouseOver);
    }

    public void SetInfo(string name)
    {
        _name = name;
    }

    public void OnMouseOver(PointerEventData data)
    {
        UI_Tooltips tooltips =  Managers.UI.ShowPopupUI<UI_Tooltips>("UI_Tooltips");
        //tooltips.SetText();
    }
}
