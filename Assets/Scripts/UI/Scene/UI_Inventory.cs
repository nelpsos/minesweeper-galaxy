using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : UI_Scene
{

    enum GameObjects
    {
        Grid_Inventory
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.Grid_Inventory);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        // 실제 인벤토리 정보를 참고해서
        for (int i = 0; i < 8; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Inventory_Item>(gridPanel.transform).gameObject;
            UI_Inventory_Item invenItem = item.GetOrAddComponent<UI_Inventory_Item>();
            //invenItem.SetInfo($"집행검{i}번");
        }
    }

    
}
