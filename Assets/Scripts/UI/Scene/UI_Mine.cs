using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Mine : UI_Scene
{
    enum TextMeshProUGUIs
    {
        Text_Mine
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
	{
        base.Init();

        Bind<TextMeshProUGUI>(typeof(TextMeshProUGUIs));
    }
    public void SetMineText(int mine)
    {
        GetText((int)TextMeshProUGUIs.Text_Mine).text = $"{mine}";
    }
}
