using System;
using UnityEngine;
using static Define;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CellController : MonoBehaviour
{
    [SerializeField]
    private int _adjacentMineCount = 0;
    public int AdjacentMineCount
    {
        get { return _adjacentMineCount;  }
        set { _adjacentMineCount = value;}
    }

    public Define.CellState CellState { get; set; }

    [SerializeField]
    private bool _bHaveMine = false;
    public bool HaveMine
    {
        get { return _bHaveMine; }
        set { _bHaveMine = value; }
    }
    [SerializeField]
    private bool _bIsFlag = false;
    public bool IsFlag
    {
        get { return _bIsFlag; }
    }

    private int _x;
    private int _y;
    private MapController _map;

    private SpriteRenderer _spriteRenderer;

    private Sprite _open;

    public void Init(int x, int y, MapController map)
    {
        _x = x;
        _y = y;
        _map = map;

        _spriteRenderer = GetComponent<SpriteRenderer>();

        _open = Resources.Load<Sprite>("Texture/Game/cell_normal") as Sprite; ;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnMouseLClick()
    {
        //오픈 상태로 변경
        CellState = Define.CellState.OPEN;
        {
            _spriteRenderer.sprite = _open;
        }

        if (HaveMine)
        {
            //마인 셀인 경우
            UnityEngine.Transform childTransform = this.transform.Find("MINE");
            childTransform.gameObject.SetActive(true);

            Managers.GameManager.OnClickMine();

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

        //열린 상태고
        //마인아 아니고
        //지뢰가 없는경우
        if(CellState == Define.CellState.OPEN
            && HaveMine == false 
            && AdjacentMineCount == 0)
        {
            _map.recursionSerach(_x, _y);
        }
    }

    public void OpenCell()
    {
        //오픈 상태로 변경
        CellState = Define.CellState.OPEN;
        {
            _spriteRenderer.sprite = _open;
        }

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
   
    public void OnMouseRClick()
    {
        if (Managers.GameManager.MineCount <= 0)
            return;

        // Flag 설정을 안한 상태
        if (IsFlag == false)
        {
            _bIsFlag = true;
            Managers.GameManager.OnCheckMine();
        }
        else
        {
            _bIsFlag = false;
            Managers.GameManager.OnUnCheckMine();
        }

        //아이콘 설정
        UnityEngine.Transform childTransform = this.transform.Find("FLAG");
        childTransform.gameObject.SetActive(IsFlag);
    }
}
