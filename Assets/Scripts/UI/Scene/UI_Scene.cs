﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Scene : UI_Base
{
    private void Start()
    {
        Init();
    }

    public override void Init()
	{
        Managers.UI.SetCanvas(gameObject, false);
    }
}
