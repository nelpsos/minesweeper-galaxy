using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ReadyGame : UI_Popup
{
    TextMeshProUGUI _text;

    private void Start()
    {
        Init();

        //Managers.GameManager.GameModeAction -= OnGameReadyReceiveGameMode;
        //Managers.GameManager.GameModeAction += OnGameReadyReceiveGameMode;
    }

    public override void Init()
    {
        base.Init();

        _text = GetComponentInChildren<TextMeshProUGUI>();

        StartCoroutine("GameStartAfterSecond", 3);
    }

    IEnumerator GameStartAfterSecond(float seconds)
    {
        for (float i = seconds; i > 0; i--)
        {
            _text.text = i.ToString();
            yield return new WaitForSeconds(1);
            _text.text = "Start";
        }
        yield return new WaitForSeconds(0.5f);

        Managers.UI.ClosePopupUI(this);

        Managers.GameManager.ChangeGameMode(Define.GameMode.Play);
    }

}
