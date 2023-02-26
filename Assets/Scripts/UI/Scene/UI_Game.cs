using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Game : UI_Popup
{

    enum GameObjects
    {
        Grid_Bag,
        Grid_Life,
    }

    public TextMeshProUGUI _mineText;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init()
    {
        base.Init();
    }

    public void SetupGame()
    {
        Bind<GameObject>(typeof(GameObjects));

        InitBag();

        InitLife();

        InitMine();
    }

    #region Bag

    UI_BagItem[] m_bagItemList = new UI_BagItem[Define.MAX_BAG];
    private void InitBag()
    {
        GameObject gridPanel = Get<GameObject>((int)GameObjects.Grid_Bag);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        // 실제 인벤토리 정보를 참고해서
        for (int i = 0; i < Define.MAX_BAG; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_BagItem>(gridPanel.transform).gameObject;
            m_bagItemList[i] = item.GetOrAddComponent<UI_BagItem>();

            item.gameObject.SetActive(false);
        }
    }

    public void SetBagItemInfo(int index, int tableIndex, int count)
    {
        m_bagItemList[index].gameObject.SetActive(true);
        m_bagItemList[index].SetBagItemTable(Managers.Data.RepairItemDict[tableIndex]);
        m_bagItemList[index].SetItemCount(count);
    }

    #endregion

    #region Life
    UI_LifeItem[] m_lifeItemList = new UI_LifeItem[Define.MAX_LIFE];

    private void InitLife()
    {
        GameObject gridPanel = Get<GameObject>((int)GameObjects.Grid_Life);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        for (int i = 0; i < Define.MAX_LIFE; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_LifeItem>(gridPanel.transform).gameObject;
            m_lifeItemList[i] = item.GetOrAddComponent<UI_LifeItem>();
        }

        SetLife(Managers.GameManager.GetLife());
    }

    public void SetLife(int life)
    {
        foreach (var item in m_lifeItemList)
        {
            item.SetActivate(false);
        }

        for(int i = 0; i < life; ++i)
        {
            m_lifeItemList[i].SetActivate(true);
        }
    }
    #endregion


    #region Mine

    private void InitMine()
    {
    }
    public void SetMine(int mine)
    {
        _mineText.text = mine.ToString();
    }

    #endregion
}
