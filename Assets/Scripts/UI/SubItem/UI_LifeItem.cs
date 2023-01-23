using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifeItem : UI_Base
{
    public Image _icon;
    public Image _bg;

    enum GameObjects
    {
        Life_Item_Icon,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

    }

    public void SetActivate(bool activate)
    {
        _icon.gameObject.SetActive(activate);
    }

}
