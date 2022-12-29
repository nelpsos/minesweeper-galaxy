using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Animal : UI_Scene
{
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

        for (int i = 0; i < 8; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Animal_Item>(gridPanel.transform).gameObject;
            UI_Animal_Item animalItem = item.GetOrAddComponent<UI_Animal_Item>();
            //invenItem.SetInfo($"집행검{i}번");
        }
    }

}
