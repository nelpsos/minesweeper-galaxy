using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager
{

    [SerializeField]
    int _mineCount = 0;  //남은 지뢰 개수

    [SerializeField]
    int _life = 3;    // 목숨

    [SerializeField]
    int _level = 0;

    [SerializeField]
    Stage _stageData;

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
        Managers.Input.KeyAction -= OnKeyDown;
        Managers.Input.KeyAction += OnKeyDown;

        Managers.UI.ShowSceneUI<UI_Inventory>("UI_Inventory");
        Managers.UI.ShowSceneUI<UI_Animal>("UI_Animal");
        Managers.UI.ShowSceneUI<UI_Life>("UI_Life");
        Managers.UI.ShowSceneUI<UI_Mine>("UI_Mine");

        Managers.UI.ShowPopupUI<UI_Button>("UI_Button");

        GameObject go = Managers.Resource.Instantiate($"Map");
        _mapController = go.GetOrAddComponent<MapController>();

    }

    public void StageClear()
    {
        _level++;
    }


    private void InitGame()
    {
        _stageData = Managers.Data.StageDict[_level];
        _mineCount = _stageData.mine;
 
        _mapController.Init(_stageData.mine, _stageData.row, _stageData.col);
    }

    public void ChangeGameMode(Define.GameMode gameMode) 
    {
        GameMode = gameMode;

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
            GameModeAction.Invoke(GameMode);
    }

    public void OnUpdate()
    {
        //시간 체크
        //_remainTime -= Time.deltaTime;
        //_uiScene.SetTimeText(_remainTime);

        //if(_remainTime < 0)
        //{
        //    ChangeGameMode(Define.GameMode.GameOver);
        //}
    }

    public void OnClickMine()
    {
        _life--;

        //_uiScene.SetLifeText(_life);

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

    }


    public void OnKeyDown()
    {
        if(Input.GetKeyDown(KeyCode.F2))
        {
            Managers.UI.ShowPopupUI<UI_RoundInfo>("UI_RoundInfo");
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            Managers.UI.CloseAllPopupUI();
        }
    }
}
