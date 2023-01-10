using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GameOver : UI_Popup
{
    [SerializeField]
    public float _visibleTime = 1;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        StartCoroutine("UIVisibleGameOver", _visibleTime);
    }

    IEnumerator UIVisibleGameOver(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Managers.UI.ClosePopupUI(this);

        Managers.GameManager.ChangeGameMode(Define.GameMode.Ready);
    }
}
