using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Animal_Info_Item : UI_Base
{
    public Image _icon;
    public TextMeshProUGUI _name;
    public TextMeshProUGUI _explanation;

    enum GameObjects
    {
        UI_Animal_Info_Item,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        //Bind<GameObject>(typeof(GameObjects));

        //Get<GameObject>((int)GameObjects.UI_Animal_Info_Item).BindEvent((PointerEventData) => { Debug.Log($"아이템 클릭! {_name}"); });

        //_icon = GetComponentInChildren<Image>();
        //_name = GetComponentInChildren<TextMeshProUGUI>();
        //_explanation = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetInfo(int animalIndex)
    {
        Animal animalData = Managers.Data.AnimalDict[animalIndex];

        _icon.sprite = Resources.Load<Sprite>(animalData.resouce) as Sprite;
        _name.text = animalData.name;
        _explanation.text = animalData.explanation;
    }
}
