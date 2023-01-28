using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager
{

    [SerializeField]
    int _mineCount = 0;  //남은 지뢰 개수
    public int MineCount
    {
        get { return _mineCount; }
    }

    [SerializeField]
    int _life = 3;    // 목숨
    public int Life
    {
        get { return _life; }
    }

    [SerializeField]
    int _round = 1;
    public int Round
    {
        get { return _round; }
    }

    [SerializeField]
    int _maxRound = 1;
    public int MaxRound
    {
        get { return _maxRound; }
    }

    [SerializeField]
    int _opendMine = 0; //



    [SerializeField]
    Round _roundData;

    MapController _mapController;
    PlayerController _playerControllr = new PlayerController();

    public Define.GameMode _gameMode;
    public Define.GameMode GameMode
    {
        get { return _gameMode; }
        set { _gameMode = value; }
    }

    public Action<Define.GameMode> GameModeAction = null;


    UI_Game _uiGame = null;

    public void Init()
    {
        //Managers.Input.KeyAction -= OnKeyDown;
        //Managers.Input.KeyAction += OnKeyDown;
    }

    public void StageClear()
    {
        _round++;
    }


    private void InitGame()
    {
  
        _roundData = Managers.Data.RoundDict[_round];
        _mineCount = _roundData.square_mine;

        if (_mapController == null)
        {
            GameObject go = Managers.Resource.Instantiate($"Map"); 
            _mapController = go.GetOrAddComponent<MapController>();
        }
        
        //Mine 셋업
        _mapController.Init(_roundData.square_mine, _roundData.square_row, _roundData.square_column);

        //Animal Settup
        _uiGame = Managers.UI.GetUIScene<UI_Game>();
        _uiGame.SetAnimalItemInfo(0, 0);
        _uiGame.SetAnimalItemInfo(1, 1);
        _uiGame.SetAnimalItemInfo(2, 2);

        //Bag Settup
        _uiGame.SetBagItemInfo(0, 0);

        // Life Setup
        _uiGame.SetLife(_life);

        //Mine Setup
        _uiGame.SetMine(_mineCount);

    }

    public void ChangeGameMode(Define.GameMode gameMode) 
    {
        GameMode = gameMode;

        switch (gameMode)
        {
            case Define.GameMode.Roadmap:
                {
                    UI_Roadmap roadmap = Managers.UI.ShowPopupUI<UI_Roadmap>("UI_Roadmap");
                }
                break;
            case Define.GameMode.RoundInfo:
                {
                    UI_RoundInfo roundInfo = Managers.UI.ShowPopupUI<UI_RoundInfo>("UI_RoundInfo");
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
                    int x = UnityEngine.Random.Range(0, _roundData.square_row);
                    int y = UnityEngine.Random.Range(0, _roundData.square_column);

                    while (_mapController.OpenCell(x, y) == false)
                    {
                        x = UnityEngine.Random.Range(0, _roundData.square_row);
                        y = UnityEngine.Random.Range(0, _roundData.square_column);
                    }
                }
                break;
            case Define.GameMode.Pause:
                break;
            case Define.GameMode.GameOver:
                break;
            case Define.GameMode.Clear:
                {
                    _mapController.Clear();

                    UI_RoundClear roundClear = Managers.UI.ShowPopupUI<UI_RoundClear>("UI_RoundClear");

                    OnNextRound();
                }
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

    public void OnNextRound()
    {
        if(_maxRound == _round)
            _maxRound++;
    }

    public void OnClickMine()
    {
        _life--;
        _uiGame.SetLife(_life);

        _opendMine++;

        _mineCount--;
        _uiGame.SetMine(_mineCount);

        if (_life<=0)
        {
            ChangeGameMode(Define.GameMode.GameOver);
        }

        if (IsGameClear())
        {
            ChangeGameMode(Define.GameMode.Clear);
        }
    }

    public void OnCheckMine()
    {
        _mineCount--;
        _uiGame.SetMine(_mineCount);

        if(IsGameClear())
        {
            ChangeGameMode(Define.GameMode.Clear);
        }
    } 

    public void OnUnCheckMine()
    {
        _mineCount++;
        _uiGame.SetMine(_mineCount);
    }

    public bool IsGameClear()
    {
        if (_mineCount <= 0)
        {
            int findMine = _mapController.GetCorrectFind();
            if (findMine + _opendMine == _roundData.square_mine)
            {
                
                return true;
            }
        }

        return false;
    }

 
    public void SetRound(int round)
    {
        _round = round;
    }

    public Round GetRoundData()
    {
        return _roundData;
    }

    public void AddRepairTool(RepairTool tool)
    {
        _playerControllr.AddRepairTool(tool);
    }

    public void AddSpacesuit(Spacesuit spacesuit)
    {
        _playerControllr.AddSpacesuit(spacesuit);
    }
}
