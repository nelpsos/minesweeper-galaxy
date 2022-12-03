using System;
using UnityEngine;
using static Define;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CellController : MonoBehaviour
{
    public int AdjacentMineCount { get; set; }

    public Define.CellState CellState { get; set; }

    public bool HaveMine { get; set; }
    public bool IsFlag { get; set; }

    private int _x;
    private int _y;

    private MapController _mapController;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(int x, int y, MapController mapController)
    {
        _x = x;
        _y = y;

        _mapController = mapController;

        gameObject.name = "Cell" + "_" + y.ToString() + "_" + x.ToString();
        gameObject.transform.position = new Vector3(y, x, 0);
    }

    public void OpenCell()
    {
        //오픈 상태로 변경
        CellState = Define.CellState.OPEN;

        //색상 변경
        _spriteRenderer.color = Color.black;
        
        if (HaveMine)
        {
            //마인 셀인 경우
            UnityEngine.Transform childTransform = this.transform.Find("MINE");
            childTransform.gameObject.SetActive(true);

            Managers.GameManager.OnReduceLife(1);
        }
        else
        {
            //정상적 오픈
            string[] names = Enum.GetNames(typeof(Define.MineCount));

            //모든 자식노드 비활성화
            foreach (UnityEngine.Transform child in this.transform)
                child.gameObject.SetActive(false);

            //주변에 마인이 있는경우에만 
            if (AdjacentMineCount > 0)
            {
                UnityEngine.Transform childTransform = this.transform.Find(names[AdjacentMineCount]);
                childTransform.gameObject.SetActive(true);
            }
        }
    }

    public void SetFlag()
    {
        IsFlag = !IsFlag;

        UnityEngine.Transform childTransform = this.transform.Find("FLAG");
        if (IsFlag)
            childTransform.gameObject.SetActive(true);
        else
            childTransform.gameObject.SetActive(false);

        Managers.GameManager.OnSetFlag(IsFlag);
    }

    public void OnMouseLClick()
    {
        _mapController.OpenCell(_x,_y);
    }

    public void OnMouseRClick()
    {
        SetFlag();
    }
}
