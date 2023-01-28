using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSpacesuitScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.SelectSpaceSuit;

        Managers.UI.ShowSceneUI<UI_SelectSpacesuit>("UI_SelectSpacesuit");
    }

    private void Update()
    {
    }

    public override void Clear()
    {
        Managers.UI.Clear();
    }
}
