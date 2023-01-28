using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

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
                    _cellController[y, x] = gameObject.GetComponent<CellController>();
                    gameObject.name = "Cell" + "_" + x.ToString() + "_" + y.ToString();
                    gameObject.transform.position = new Vector3(x - col / 2,y - row / 2, 0);
                    _cellController[y, x].Init(x, y, this);
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
        for (int y = 0; y < row; y++)
        {
            for (int x = 0; x < col; x++)
            {
                //지뢰가 아닌 경우 주변 검사 체크 
                if (_cellController[y, x].HaveMine == false)
                {
                    int adjacentMineCount = 0;
                    for (int k = 0; k < Define.xIndex.Length; ++k)
                    {
                        int xx = x + Define.xIndex[k];
                        int yy = y + Define.yIndex[k];

                        if (xx < 0 || xx >= _row)
                            continue;

                        if (yy < 0 || yy >= _col)
                            continue;

                        if (_cellController[yy, xx].HaveMine)
                            adjacentMineCount++;

                    }
                   _cellController[y, x].AdjacentMineCount = adjacentMineCount;
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

    public void recursionSerach(int x, int y)
    {
        for (int i = 0; i < Define.xIndex.Length; ++i)
        {
            int xx = x + Define.xIndex[i];
            int yy = y + Define.yIndex[i];

            if (xx < 0 || xx >= _row)
                continue;

            if (yy < 0 || yy >= _col)
                continue;

            if (xx == x && yy == y)
                continue;

            // 지뢰가 없는 경우
            // 플레그인 경우
            CellController cell = _cellController[yy, xx];
            if (cell.CellState == Define.CellState.HIDDEN
                && cell.HaveMine == false
                && cell .IsFlag == false)
            {
                _cellController[yy, xx].OnMouseLClick();
            }
        }
    }

    public bool OpenCell(int x, int y)
    {
        if (_cellController[y, x].HaveMine)
            return false;

        _cellController[y, x].OpenCell();

        return true;
    }
}
