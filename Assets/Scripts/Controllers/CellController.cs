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
        //���� ���·� ����
        CellState = Define.CellState.OPEN;

        //���� ����
        _spriteRenderer.color = Color.black;
        
        if (HaveMine)
        {
            //���� ���� ���
            UnityEngine.Transform childTransform = this.transform.Find("MINE");
            childTransform.gameObject.SetActive(true);

            Managers.GameManager.OnReduceLife(1);
        }
        else
        {
            //������ ����
            string[] names = Enum.GetNames(typeof(Define.MineCount));

            //��� �ڽĳ�� ��Ȱ��ȭ
            foreach (UnityEngine.Transform child in this.transform)
                child.gameObject.SetActive(false);

            //�ֺ��� ������ �ִ°�쿡�� 
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
