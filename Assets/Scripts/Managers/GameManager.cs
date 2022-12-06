using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager
{

    [SerializeField]
    int _mineCount = 0;  //남은 지뢰 개수

    [SerializeField]
    float _remainTime = 0;    //남은 시간

    [SerializeField]
    int _level = 1;

    [SerializeField]
    Stage _stageData;

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

    public void StageClear()
    {
        _level++;
    }

    public void ChangeGameMode(Define.GameMode gameMode) 
    { 
        _gameMode = gameMode;

        switch (gameMode)
        {
            case Define.GameMode.Ready:
                {
                    _stageData = Managers.Data.StageDict[_level];
                    _mineCount = _stageData.mine;
                    _remainTime = 100f;
                }
                break;
            case Define.GameMode.Play:
                {
                    
                }
                break;
            case Define.GameMode.Pause:
                break;
            case Define.GameMode.GameOver:
                break;
            default:
                break;
        }

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

    public Stage GetStageData()
    {
        return _stageData;
    }
}
