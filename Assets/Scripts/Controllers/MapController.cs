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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int maxMine, int row, int col)
    {
        // ��Ʈ�ѷ� ����
        _cellController = new CellController[row, col];
        _row = row;
        _col = col;

        //������ ����
        for (int y = 0; y < row; y++)
        {
            for (int x = 0; x < col; x++)
            {
                GameObject gameObject = Managers.Resource.Instantiate("Cell", transform);
                if (gameObject != null)
                {
                    _cellController[y, x] = gameObject.GetComponent<CellController>();
                    _cellController[y, x].Init(y, x, this);
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

        //��� �� ����
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                //���ڰ� �ƴ� ��� �ֺ� �˻� üũ 
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


    public void OpenCell(int x, int y)
    {
        _cellController[x, y].OpenCell();

        //OpenAdjacentCell(x, y);
    }

    public void OpenAdjacentCell(int pivotX, int pivotY)
    {
        for (int i = 0; i < Define.xIndex.Length; ++i)
        {
            int x = pivotX + Define.xIndex[i];
            int y = pivotY + Define.yIndex[i];

            if (x < 0 || x >= _row)
                continue;

            if (y < 0 || y >= _col)
                continue;


            //������ �ƴѰ�� ����
            if (_cellController[x, y].HaveMine == false)
            {
                _cellController[x, y].OpenCell();

                //�ֺ� ���ڰ� ���°�� ��� Ž��
                if(_cellController[x, y].AdjacentMineCount == 0)
                    OpenAdjacentCell(x, y);
            }
        }
    }
}
