using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static GameManager;

public class UI_RoundInfo_Item : UI_Base
{
    public RectTransform _animalRect;
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

    public void SetRoundAnimalInfo(int index)
    {
        Animal animalData = Managers.Data.AnimalDict[index];

        GameObject go = Managers.Resource.Instantiate(animalData.resource);

        go.transform.position = Define.GetAnimalPosition(index);
        go.transform.rotation = Quaternion.Euler(new Vector3(15f, -90f, 15f));
        go.transform.localScale = Define.GetAnimalScaleInfo();

        _name.text = animalData.name;
        _explanation.text = animalData.explain;

        AnimalInfo info; 
        info.animalIndex = index;
        info.animalObject = go;

        Managers.GameManager.SetAnimalInfo(info);
    }
}
