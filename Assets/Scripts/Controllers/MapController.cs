using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private CellController[,] _cellController;
    private int _row;
    private int _col;

    // Start is called before the first frame update
    void Start()
    {
        Managers.GameManager.GameModeAction -= OnMapReceiveGameMode;
        Managers.GameManager.GameModeAction += OnMapReceiveGameMode;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int maxMine, int row, int col)
    {
        // 컨트롤러 생성
        _cellController = new CellController[row, col];
        _row = row;
        _col = col;

        //프리팹 생성
        for (int y = 0; y < row; y++)
        {
            for (int x = 0; x < col; x++)
            {
                GameObject gameObject = Managers.Resource.Instantiate("Cell", transform);
                if (gameObject != null)
                {
                    _cellController[i, j] = gameObject.GetComponent<CellController>();
                    gameObject.name = "Cell" + "_" + i.ToString() + "_" + j.ToString();
                    gameObject.transform.position = new Vector3(i - row / 2, j - col / 2, 0);

                }
            }
        }

        //Setup Mine
        while (maxMine > 0)
        {
            int mineRow = Random.Range(0, row);
            int mineCol = Random.Range(0, col);

            CellController cell = _cellController[mineRow, mineCol];
            cell.HaveMine = true;
            maxMine--;
        }

        //블록 셀 설정
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                //지뢰가 아닌 경우 주변 검사 체크 
                if (_cellController[i, j].HaveMine == false)
                {
                    int adjacentMineCount = 0;
                    for (int k = 0; k < Define.xIndex.Length; ++k)
                    {
                        int x = i + Define.xIndex[k];
                        int y = j + Define.yIndex[k];

                        if (x < 0 || x >= _row)
                            continue;

                        if (y < 0 || y >= _col)
                            continue;

                        if (_cellController[x, y].HaveMine)
                            adjacentMineCount++;

                    }
                   _cellController[i, j].AdjacentMineCount = adjacentMineCount;
                }
            }
        }
    }

    public void Clear()
    {
        //프리팹 생성
        for (int x = 0; x < _row; x++)
        {
            for (int y = 0; y < _col; y++)
            {
                Managers.Resource.Destroy(_cellController[y, x].gameObject);
            }
        }
    }

    public void OnMapReceiveGameMode(Define.GameMode gameMode)
    {
        switch (gameMode)
        {
            case Define.GameMode.Ready:
                {
                    gameObject.SetActive(false);
                }
                break;
            case Define.GameMode.Play:
                {
                    gameObject.SetActive(true);
                }
                break;
            case Define.GameMode.Pause:
                break;
            case Define.GameMode.GameOver:
                break;
            case Define.GameMode.Clear:
                {
                    Managers.UI.ShowPopupUI<UI_ClearGame>("UI_ClearGame");
                }
                break;
            default:
                break;
        }
    }

    public int GetCorrectFind()
    {
        int findMine = 0;

        for (int y = 0; y < _row; y++)
        {
            for (int x = 0; x < _col; x++)
            {
                if (_cellController[y, x].HaveMine && _cellController[y, x].IsFlag)
                    findMine++;
            }
        }

        return findMine;
    }
}
