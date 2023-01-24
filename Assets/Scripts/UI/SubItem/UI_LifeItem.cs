using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifeItem : UI_Base
{
    public Image _icon;
    public Image _bg;


    void Start()
    {
        Init();
    }

    public override void Init()
    {
    }

    public void SetActivate(bool activate)
    {
        _icon.gameObject.SetActive(activate);
    }

}
