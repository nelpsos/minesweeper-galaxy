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
        LifeText,
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


    public void SetMineText(int mineCount)
    {
        GetText((int)TextMeshProUGUIs.MineText).text = $"Mine : {mineCount}";
    }

    public void SetLifeText(int life)
    {
        GetText((int)TextMeshProUGUIs.LifeText).text = $"Life : {life}";
    }

    public void SetTimeText(int time)
    {
        GetText((int)TextMeshProUGUIs.TimeText).text = $"Time : {time}";
    }
}
