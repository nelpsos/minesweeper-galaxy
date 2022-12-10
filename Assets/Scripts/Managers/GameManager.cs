using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager
{

    [SerializeField]
    int _mineCount = 0;  //남은 지뢰 개수

    [SerializeField]
    float _remainTime = 0;    //남은 시간

    [SerializeField]
    int _life = 3;    //남은 시간

    [SerializeField]
    int _level = 0;

    [SerializeField]
    Stage _stageData;

    UI_Scene _uiScene;
    MapController _mapController;

    public Define.GameMode _gameMode;
    public Define.GameMode GameMode
    {
        get { return _gameMode; }
        set { _gameMode = value; }
    }
    
    public Action<Define.GameMode> GameModeAction = null;

    public void Init()
    {   
        Managers.UI.ShowSceneUI<UI_Scene>("UI_Scene");
        Managers.UI.ShowPopupUI<UI_Button>("UI_Button");

        GameObject go = Managers.Resource.Instantiate($"Map");
        _mapController = go.GetOrAddComponent<MapController>();

        _uiScene = Managers.UI.GetUIScene();
    }

    public void StageClear()
    {
        _level++;
    }

    private void InitGame()
    {
        _stageData = Managers.Data.StageDict[_level];
        _mineCount = _stageData.mine;
        _remainTime = 100f;

        _mapController.Init(_stageData.mine, _stageData.row, _stageData.col);

        _uiScene.SetMineText(_mineCount);
        _uiScene.SetLifeText(_life);
    }

    public void ChangeGameMode(Define.GameMode gameMode) 
    { 
        _gameMode = gameMode;

        switch (gameMode)
        {
            case Define.GameMode.Ready:
                {
                    Managers.UI.ShowPopupUI<UI_ReadyGame>("UI_ReadyGame");

                    InitGame();
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
            case Define.GameMode.Clear:
                _mapController.Clear();
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
        _uiScene.SetTimeText(_remainTime);

        //if(_remainTime < 0)
        //{
        //    ChangeGameMode(Define.GameMode.GameOver);
        //}
    }

    public void OnClickMine()
    {
        _life--;

        _uiScene.SetLifeText(_life);

        if(_life<=0)
        {
            ChangeGameMode(Define.GameMode.GameOver);
        }
    }

    public void OnFindMine()
    {
        _mineCount--;

        if(_mineCount <= 0 )
        {
            int findMine = _mapController.GetCorrectFind();
            if(findMine == _stageData.mine)
            {
                ChangeGameMode(Define.GameMode.Clear);
            }
        }
    } 

    public void OnCancelFindMine()
    {
        _mineCount++;
    }

    public void OnNextStage()
    {
        _level++;

    }

    public Stage GetStageData()
    {
        return _stageData;
    }
}
