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
    public Image _go;
    public Image _ready;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        StartCoroutine("GameStartAfterSecond", 2f);
    }

    IEnumerator GameStartAfterSecond(float seconds)
    {
        _ready.gameObject.SetActive(true);

        yield return new WaitForSeconds(seconds);

        _ready.gameObject.SetActive(false);
        _go.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        Managers.UI.ClosePopupUI(this);

        Managers.GameManager.ChangeGameMode(Define.GameMode.Play);

        _ready.gameObject.SetActive(false);
        _go.gameObject.SetActive(false);
    }

}
