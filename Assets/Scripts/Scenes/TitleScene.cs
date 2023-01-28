using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Title;

        Managers.UI.ShowSceneUI<UI_Title>("UI_Title");
    }

    private void Update()
    {
    }

    public override void Clear()
    {
        Managers.UI.Clear();
    }
}
