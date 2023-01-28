using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        //UI
        UI_Game uiGame = Managers.UI.ShowSceneUI<UI_Game>("UI_Game");

        Managers.GameManager.ChangeGameMode(Define.GameMode.Roadmap);
    }

    public override void Clear()
    {
        
    }


}
