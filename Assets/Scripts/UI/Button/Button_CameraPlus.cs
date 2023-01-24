using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_CameraPlus : MonoBehaviour
{
    Button _button;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        Camera.main.orthographicSize--;
        if (Camera.main.orthographicSize < 5)
            Camera.main.orthographicSize = 5;
    }
}
