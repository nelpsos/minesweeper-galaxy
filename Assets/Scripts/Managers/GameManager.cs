using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public struct AnimalInfo
{
    public int animalIndex;
    public GameObject animalObject;
}

public struct BagInfo
{
    public int bagIndex;
    public int count;
}

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

    //Animal Index List
    List<AnimalInfo> _animalList = new List<AnimalInfo>();    

    //Bag Info
    List<BagInfo> _bagsList = new List<BagInfo>();

    MapController _mapController;
    PlayerController _playerControllr = new PlayerController();

    UI_Game _uiGame;

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
        _uiGame = Managers.UI.ShowPopupUI<UI_Game>("UI_Game");
        _uiGame.SetupGame();
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

                    int index = _round - 1;
                    //left
                    {
                        Vector3 position = new Vector3 { x = -Define.position[index], y = Managers.GameManager.GetYMax() + 1, z = 0.0f };
                        Vector3 scale = new Vector3 { x = Define.scale[index], y = Define.scale[index], z = Define.scale[index] };

                        _animalList[0].animalObject.transform.position = position;
                        _animalList[0].animalObject.transform.localScale = scale;
                    }
                    //center
                    {
                        Vector3 position = new Vector3 { x = 0, y = Managers.GameManager.GetYMax() + 1, z = 0.0f };
                        Vector3 scale = new Vector3 { x = Define.scale[index], y = Define.scale[index], z = Define.scale[index] };

                        _animalList[1].animalObject.transform.position = position;
                        _animalList[1].animalObject.transform.localScale = scale;
                    }
                    //Right
                    {
                        Vector3 position = new Vector3 { x = Define.position[index], y = Managers.GameManager.GetYMax() + 1, z = 0.0f };
                        Vector3 scale = new Vector3 { x = Define.scale[index], y = Define.scale[index], z = Define.scale[index] };

                        _animalList[2].animalObject.transform.position = position;
                        _animalList[2].animalObject.transform.localScale = scale;
                    }

                    AddBag(0, 3);
                    //아이템 셋팅
                    for (int i = 0; i < _bagsList.Count; ++i)
                    {
                        _uiGame.SetBagItemInfo(i, _bagsList[i].bagIndex, _bagsList[i].count);
                    }
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

                    //Delete
                    for (int i = 0; i < Define.MAX_ANIMAL; ++i)
                    {
                        Managers.Resource.Destroy(_animalList[i].animalObject);
                    }
                    _animalList.Clear();

                    Managers.UI.ClosePopupUI(_uiGame);
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
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ChangeGameMode(Define.GameMode.Clear);
        }
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
            //ChangeGameMode(Define.GameMode.GameOver);
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

    public int CameraSize()
    {
        return _roundData.square_column + 2;
    }

    public float CaemraPosition()
    {
        return _roundData.square_column / 4;
    }

    public void AddRepairTool(RepairTool tool)
    {
        _playerControllr.AddRepairTool(tool);
    }

    public void AddSpacesuit(Spacesuit spacesuit)
    {
        _playerControllr.AddSpacesuit(spacesuit);
    }

    
    public void SetAnimalInfo(AnimalInfo  animalInfo)
    {
        _animalList.Add(animalInfo);
    }

    public AnimalInfo GetAnimalInfo(int index)
    {
        return _animalList[index];
    }

    public void AddBag(int index, int count)
    {
        BagInfo bagInfo = new BagInfo();

        bagInfo.bagIndex = index;
        bagInfo.count = count;

        _bagsList.Add(bagInfo);
    }
    public int GetYMax()
    {
        Round round = Managers.Data.RoundDict[_round];
        return round.square_row - round.square_row / 2;
    }

    public int GetLife()
    {
        return _life;
    }
}
