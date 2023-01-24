using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Game : UI_Scene
{
    Canvas _canvas;
    enum GameObjects
    {
        Grid_Animal,
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

        Bind<GameObject>(typeof(GameObjects));

        InitBag();

        InitAnimal();

        InitLife();

        InitMine();

        _canvas = GetComponent<Canvas>();
        _canvas.renderMode = RenderMode.ScreenSpaceCamera;
        _canvas.worldCamera = Camera.main;
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
        }
    }

    public void SetBagItemInfo(int index, int tableIndex)
    {
        RepairTool repairToolData = Managers.Data.RepairItemDict[tableIndex];

       m_bagItemList[index].SetBagItemIcon(repairToolData.resource);
    }

    #endregion


    #region Aniaml

    UI_AnimalItem[] m_animalItemList = new UI_AnimalItem[Define.MAX_ANIMAL];

    private void InitAnimal()
    {
        GameObject gridPanel = Get<GameObject>((int)GameObjects.Grid_Animal);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        for (int i = 0; i < Define.MAX_ANIMAL; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_AnimalItem>(gridPanel.transform).gameObject;
            m_animalItemList[i] = item.GetOrAddComponent<UI_AnimalItem>();
        }
    }

    public void SetAnimalItemInfo(int index, int tableIndex)
    {
        Animal animalData = Managers.Data.AnimalDict[tableIndex];

        m_animalItemList[index].SetAniamlIcon(animalData.resource);
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
