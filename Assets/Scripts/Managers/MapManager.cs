using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private CellController[,] _cellController;
    private int _row;
    private int _col;

    // Start is called before the first frame update
    void Start()
    {
        Init(5, 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init(int maxMine, int row, int col)
    {
        // 컨트롤러 생성
        _cellController = new CellController[row, col];
        _row = row;
        _col = col;

        //프리팹 생성
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                GameObject gameObject = Managers.Resource.Instantiate("Cell", transform);
                if (gameObject != null)
                {
                    _cellController[i, j] = gameObject.GetComponent<CellController>();
                    gameObject.name = "Cell" + "_" + i.ToString() + "_" + j.ToString();
                    gameObject.transform.position = new Vector3(i, j, 5);
                }
            }
        }

        //Setup Mine
        while (maxMine > 0)
        {
            int mineRow = Random.Range(0, row);
            int mineCol = Random.Range(0, col);

            CellController cell = _cellController[mineRow, mineCol];
            cell.SetCellState(Define.CellState.MINE);
            maxMine--;
        }


        //블록 셀 설정
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                //지뢰가 아닌 경우 주변 검사 체크 
                if (_cellController[i, j].CellState != Define.CellState.MINE)
                {
                    int mineCount = 0;
                    for (int k = 0; k < Define.xIndex.Length; ++k)
                    {
                        int x = i + Define.xIndex[k];
                        int y = j + Define.yIndex[k];

                        if (x < 0 || x >= _row)
                            continue;

                        if (y < 0 || y >= _col)
                            continue;

                        if (_cellController[x, y].CellState == Define.CellState.MINE)
                            mineCount++;

                    }
                   _cellController[i, j].SetCellState(mineCount);
                }
            }
        }

    }

}
