using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_InGame_Animal : UI_Scene
{
    const int MAX_ANIMAL_ITEM = 3;

    UI_InGame_Animal_Item[] m_animalItemList = new UI_InGame_Animal_Item[MAX_ANIMAL_ITEM];

    enum GameObjects
    {
        Grid_Animal
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
	{
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.Grid_Animal);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        for (int i = 0; i < MAX_ANIMAL_ITEM; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_InGame_Animal_Item>(gridPanel.transform).gameObject;
            m_animalItemList[i] = item.GetOrAddComponent<UI_InGame_Animal_Item>();
        }
    }

    public void SetAnimalItemInfo(int index, int tableIndex)
    {
        Animal animalData =  Managers.Data.AnimalDict[tableIndex];

        m_animalItemList[index].SetAniamlIcon(animalData.resouce);
    }
}
