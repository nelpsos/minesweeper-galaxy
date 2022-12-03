using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager
{
    [SerializeField]
    int _mineCount = 0;  //남은 지뢰 개수

    [SerializeField]
    float _remainTime = 0;    //남은 시간

    [SerializeField]
    float _time = 0;    //게임 진행 시간 

    [SerializeField]
    int _life = 3;

    public Define.GameMode GameMode { get; set; }

    public Action<Define.GameMode> GameModeAction = null;

    public void Init()
    {
    }

    public void GameStart(int mineCount, int row, int col)
    {
        MapController mapController = GameObject.FindWithTag("Map").GetComponent<MapController>();
        mapController.Init(mineCount, row, col);

        _mineCount = mineCount;
        _life = 3;

        Managers.UI.GetUIScene().SetLifeText(_life);
        Managers.UI.GetUIScene().SetMineText(_mineCount);

        ChangeGameMode(Define.GameMode.Play);
    }

    public void ChangeGameMode(Define.GameMode gameMode) 
    {
        GameMode = gameMode;

        if(GameModeAction != null) 
            GameModeAction.Invoke(GameMode);
    }

    public void OnUpdate()
    {
        //시간 체크
        _remainTime -= Time.deltaTime;
        _time += Time.deltaTime;

        Managers.UI.GetUIScene().SetTimeText((int)_time);

        if (_remainTime < 0)
        {
            //ChangeGameMode(Define.GameMode.GameOver);
        }
    }

    public void OnReduceLife(int reduceValue)
    {
        _life -= reduceValue;

        if(_life <= 0 )
        {
            _life = 0;
            ChangeGameMode(Define.GameMode.GameOver);
        }
    }

    public void OnSetFlag(bool flag)
    {
        if (flag)
            _mineCount--;
        else
            _mineCount++;
        
        if(_mineCount <= 0)
        {
            ChangeGameMode(Define.GameMode.Clear);
        }

        Managers.UI.GetUIScene().SetMineText(_mineCount);
    }
}
