using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UI_ZoomUp : UI_Button
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

        
    }

    public void OnButtonClicked(PointerEventData data)
    {
        Camera.main.orthographicSize++;
    }
}
