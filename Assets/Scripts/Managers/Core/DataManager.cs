using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, Stage> StageDict { get; private set; } = new Dictionary<int, Stage>();
    public Dictionary<int, Animal> AnimalDict { get; private set; } = new Dictionary<int, Animal>();
    public Dictionary<int, RepairItem> RepairItemDict { get; private set; } = new Dictionary<int, RepairItem>();

    public void Init()
    {
        StageDict = LoadJson<StageData, int, Stage>("StageData").MakeDict();
        AnimalDict = LoadJson<AnimalData, int, Animal>("AnimalData").MakeDict();
        RepairItemDict = LoadJson<RepairItemData, int, RepairItem>("RepairItemData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
