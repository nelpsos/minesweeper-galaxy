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
        // 牧飘费矾 积己
        cellController = new CellController[row, col];

        //橇府普 积己
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
    }
}
