using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Roadmap : UI_Scene
{
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

    //    Bind<GameObject>(typeof(GameObjects));

    //    GameObject gridPanel = Get<GameObject>((int)GameObjects.Grid_Life);
    //    foreach (Transform child in gridPanel.transform)
    //        Managers.Resource.Destroy(child.gameObject);

    //    for (int i = 0; i < 8; i++)
    //    {
    //        GameObject item = Managers.UI.MakeSubItem<UI_Life_Item>(gridPanel.transform).gameObject;
    //        UI_Life_Item invenItem = item.GetOrAddComponent<UI_Life_Item>();
    //        //invenItem.SetInfo($"집행검{i}번");
    //    }
    }
}
