using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button_Roadmap_Stage : MonoBehaviour, IPointerClickHandler
{
    int level = 0;
    public Image _lockImage;

    // Start is called before the first frame update
    void Start()
    {
        string number = gameObject.name.Substring(gameObject.name.Length-1, 1);
        level = int.Parse(number);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {  
        if(level == Managers.GameManager.Round)
        {
            Managers.Scene.LoadScene(Define.Scene.Game);
        }
    }
}
