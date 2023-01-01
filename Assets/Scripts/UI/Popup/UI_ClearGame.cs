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
    [SerializeField]
    public float _visibleTime = 1;

    enum Buttons
    {
        NextStageButton,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        StartCoroutine("UIVisibleGameClear", _visibleTime);
    }

    IEnumerator UIVisibleGameClear(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Managers.UI.ClosePopupUI(this);

        Managers.GameManager.ChangeGameMode(Define.GameMode.Play);
    }
}
