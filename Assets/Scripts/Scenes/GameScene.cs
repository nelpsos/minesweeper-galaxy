using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;


        Managers.UI.ShowSceneUI<UI_Scene>("UI_Scene");
        Managers.UI.ShowPopupUI<UI_Button>("UI_Button");

        //Dictionary<int, Stat> dict = Managers.Data.StatDict;
    }

    public override void Clear()
    {
        
    }
}
