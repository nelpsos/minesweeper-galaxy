using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    [SerializeField]
    int _mineCount = 0;  //남은 지뢰 개수

    [SerializeField]
    float _remainTime = 0;    //남은 시간

    public Define.GameMode _gameMode;
    public Define.GameMode GameMode
    {
        get { return _gameMode; }
        set { _gameMode = value; }
    }
    
    public Action<Define.GameMode> GameModeAction = null;

    public void Init()
    {
    }

    public void GameStart(int mineCount, int row, int col)
    {
        MapController mapController = GameObject.FindWithTag("Map").GetComponent<MapController>();
        mapController.Init(mineCount, row, col);

        _mineCount = mineCount;
        _remainTime = 100f;

        ChangeGameMode(Define.GameMode.Play);
    }

    public void ChangeGameMode(Define.GameMode gameMode) 
    { 
        _gameMode = gameMode;

        if(GameModeAction != null) 
            GameModeAction.Invoke(_gameMode);
    }

    public void OnUpdate()
    {
        //시간 체크
        _remainTime -= Time.deltaTime;

        if(_remainTime < 0)
        {
            //ChangeGameMode(Define.GameMode.GameOver);
        }
    }
}
