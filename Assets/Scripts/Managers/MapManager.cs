using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    CellController[,] cellController;

    // Start is called before the first frame update
    void Start()
    {
        Init(5, 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init(int maxMine, int row, int col)
    {
        // 컨트롤러 생성
        cellController = new CellController[row, col];

        //프리팹 생성
        for (int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                GameObject gameObject = Managers.Resource.Instantiate("Cell", transform);
                if(gameObject != null)
                {
                    cellController[i, j] = gameObject.GetComponent<CellController>();
                    gameObject.name = "Cell"  + "_" + i.ToString() + "_" + j.ToString();
                    gameObject.transform.position = new Vector3(i, j, 5);
                }
            }
        }

        //Setup Mine
        while (maxMine > 0)
        {
            int mineRow = Random.Range(0, row);
            int mineCol = Random.Range(0, col);

            CellController cell = cellController[mineRow, mineCol];
            cell.CellState = Define.CellState.MINE;
            maxMine--;
        }


        //블록 셀 설정
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
               if(cellController[i, j].CellState == Define.CellState.MINE)
                {

                }
            }
        }

}
