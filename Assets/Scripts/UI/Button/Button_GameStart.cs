using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_GameStart : MonoBehaviour
{
    Button button_Start;

    // Start is called before the first frame update
    void Start()
    {
        button_Start = GetComponent<Button>();
        button_Start.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }
}
