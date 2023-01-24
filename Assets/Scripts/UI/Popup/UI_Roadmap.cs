using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Roadmap : UI_Popup
{
    enum GameObjects
    {
        UI_Stage_1,
        UI_Stage_2,
        UI_Stage_3,
        UI_Stage_4,
        UI_Stage_5,
        UI_Stage_6,
        UI_Stage_7,
        UI_Stage_8,
    }


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

        int maxRound = Managers.GameManager.MaxRound;

        for (int i = 0; i < maxRound; ++i)
        {
            GameObject button = Get<GameObject>(i);
            button.GetComponent<Button_Roadmap_Stage>().UnLockImage();
        }
    }
}
