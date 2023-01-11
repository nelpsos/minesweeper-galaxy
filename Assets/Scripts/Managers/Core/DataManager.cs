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
    public Dictionary<int, Round> RoundDict { get; private set; } = new Dictionary<int, Round>();
    public Dictionary<int, Animal> AnimalDict { get; private set; } = new Dictionary<int, Animal>();
    public Dictionary<string, RepairTool> RepairItemDict { get; private set; } = new Dictionary<string, RepairTool>();
    public Dictionary<string, Spacesuit> SpacesuitDict { get; private set; } = new Dictionary<string, Spacesuit>();

    public void Init()
    {
        RoundDict = LoadJson<RoundData, int, Round>("Rounds").MakeDict();
        AnimalDict = LoadJson<AnimalData, int, Animal>("AnimalData").MakeDict();
        RepairItemDict = LoadJson<RepairToolData, string, RepairTool>("RepairTools").MakeDict();
        SpacesuitDict = LoadJson<SpacesuitData, string, Spacesuit>("Spacesuits").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
