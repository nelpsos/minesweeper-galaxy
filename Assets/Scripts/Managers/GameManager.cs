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
    int _round = 1;

    [SerializeField]
    Round _roundData;

    MapController _mapController;
    PlayerController _playerControllr;

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

        //SceneUI
        Managers.UI.ShowSceneUI<UI_Inventory>("UI_Inventory");
        Managers.UI.ShowSceneUI<UI_InGame_Animal>("UI_InGame_Animal");
        Managers.UI.ShowSceneUI<UI_Life>("UI_Life");
        Managers.UI.ShowSceneUI<UI_Mine>("UI_Mine");

        Managers.UI.ShowPopupUI<UI_Button>("UI_Button");

        GameObject go = Managers.Resource.Instantiate($"Map");
        _mapController = go.GetOrAddComponent<MapController>();

    }

    public void StageClear()
    {
        _round++;
    }


    private void InitGame()
    {
        _roundData = Managers.Data.RoundDict[_round];
        _mineCount = _roundData.square_mine;

        //Mine 셋업
        _mapController.Init(_roundData.square_mine, _roundData.square_row, _roundData.square_column);


        //Animal Settup
        UI_Inventory uiInventory = Managers.UI.GetUIScene<UI_Inventory>("UI_Inventory");


        //Item Setup
        UI_InGame_Animal uiAnimal = Managers.UI.GetUIScene<UI_InGame_Animal>("UI_InGame_Animal");
        uiAnimal.SetAnimalItemInfo(0, 0);
        uiAnimal.SetAnimalItemInfo(1, 1);
        uiAnimal.SetAnimalItemInfo(2, 2);

        // Life Setup
        UI_Life uiLife = Managers.UI.GetUIScene<UI_Life>("UI_Life");

        Managers.UI.ShowSceneUI();
    }

    public void ChangeGameMode(Define.GameMode gameMode) 
    {
        GameMode = gameMode;

        switch (gameMode)
        {
            case Define.GameMode.RoundInfo:
                {
                    //Managers.UI.HideSceneUI();
                    UI_RoundInfo roundInfo = Managers.UI.ShowPopupUI<UI_RoundInfo>("UI_RoundInfo");
                    roundInfo.SetRoundInfo(_round);
                }
                break;
            case Define.GameMode.Ready:
                {
                    InitGame();
                    Managers.UI.ShowPopupUI<UI_ReadyGame>("UI_ReadyGame");
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
            if(findMine == _roundData.square_mine)
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
        _round++;

    }

    public Round GetRoundData()
    {
        return _roundData;
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
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Managers.UI.CloseAllPopupUI();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            UI_RoundInfo info = Managers.UI.ShowPopupUI<UI_RoundInfo>("UI_RoundInfo");
        }

        if(Input.GetKeyDown(KeyCode.F3))
        {
            UI_RepairItemReward repairItem = Managers.UI.ShowPopupUI<UI_RepairItemReward>("UI_RepairItemReward");
        }
    }
}
