using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_RoundInfo_Item : UI_Base
{
    public Image _icon;
    public TextMeshProUGUI _name;
    public TextMeshProUGUI _explanation;
    public TextMeshProUGUI _garlicNumber;

    private UI_Tooltips _tooltips;

    enum GameObjects
    {
        UI_RoundInfo_Item,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        Get<GameObject>((int)GameObjects.UI_RoundInfo_Item).BindEvent((PointerEventData) =>
        {
            _tooltips = Managers.UI.ShowPopupUI<UI_Tooltips>("UI_Tooltips");
            _tooltips.SetText(_name.text, _explanation.text);
        });

    }

    public void SetRoundAnimalInfo(int animalIndex)
    {
        Animal animalData = Managers.Data.AnimalDict[animalIndex];

        _icon.sprite = Resources.Load<Sprite>(animalData.resource) as Sprite;
        _name.text = animalData.name;
        _explanation.text = animalData.explain;
    }
}
