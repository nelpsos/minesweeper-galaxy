using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ClearGame : UI_Popup
{
    enum Buttons
    {
        NextStageButton,
    }

    private void Start()
    {
        Init();

        //Managers.GameManager.GameModeAction -= OnGameReadyReceiveGameMode;
        //Managers.GameManager.GameModeAction += OnGameReadyReceiveGameMode;
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.NextStageButton).gameObject.BindEvent(OnNextStageButton);
    }

    public void OnNextStageButton(PointerEventData data)
    {
        Managers.UI.ClosePopupUI(this);
        Managers.GameManager.OnNextStage();
        Managers.GameManager.ChangeGameMode(Define.GameMode.Ready);
    }
}
