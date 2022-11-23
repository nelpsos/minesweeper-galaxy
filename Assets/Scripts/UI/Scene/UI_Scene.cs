using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Scene : UI_Base
{
    enum TextMeshProUGUIs
    {
        MineText,
        TimeText,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
	{
        Bind<TextMeshProUGUI>(typeof(TextMeshProUGUIs));

        Managers.UI.SetCanvas(gameObject, false);
	}


    public void SetMineText(string text)
    {
        GetText((int)TextMeshProUGUIs.MineText).text = text;
    }
}
