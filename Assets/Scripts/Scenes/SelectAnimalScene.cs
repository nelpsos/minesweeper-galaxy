using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectAnimalScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.SelectAnimal;

        Managers.UI.ShowSceneUI<UI_SelectAnimal>("UI_SelectAnimal");
    }

    private void Update()
    {
    }

    public override void Clear()
    {
        Managers.UI.Clear();
    }
}
