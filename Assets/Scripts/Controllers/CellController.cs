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

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void OnMouseLClick()
    {
        //���� ���·� ����
        CellState = Define.CellState.OPEN;

        //���ڸ� ������ �ִ� ���̶��
        if (HaveMine)
        {
            //���� ����
            UnityEngine.Transform childTransform = this.transform.Find("MINE");
            childTransform.gameObject.SetActive(true);

            Managers.GameManager.OnClickMine();
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

        if (CellState == Define.CellState.OPEN)
            _spriteRenderer.color = Color.black;
        else
            _spriteRenderer.color = Color.white;


    }

    public void OnMouseRClick()
    {
        // Flag ������ ���� ����
        if(IsFlag == false)
        {
            IsFlag = true;

            if (HaveMine)
            {
                Managers.GameManager.OnFindMine();
            }
        }
        else
        {
            // Flag ����

            if (HaveMine)
            {
                Managers.GameManager.OnFindMine();
            }
        }

        //�����ڤ� ����
        UnityEngine.Transform childTransform = this.transform.Find("FLAG");
        childTransform.gameObject.SetActive(IsFlag);

    }
}
