using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadmapScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Title;

        Managers.UI.ShowSceneUI<UI_Roadmap>("UI_Roadmap");
    }

    private void Update()
    {
    }

    public override void Clear()
    {
        Managers.UI.Clear();
    }
}
