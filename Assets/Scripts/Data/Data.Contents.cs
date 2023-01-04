using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Stage

[Serializable]
public class Stage
{
	public int level;
	public int monster;
	public int col;
	public int row;
	public int mine;
}

[Serializable]
public class StageData : ILoader<int, Stage>
{
	public List<Stage> stages = new List<Stage>();

	public Dictionary<int, Stage> MakeDict()
	{
		Dictionary<int, Stage> dict = new Dictionary<int, Stage>();
		foreach (Stage stage in stages)
			dict.Add(stage.level, stage);
		return dict;
	}
}

#endregion

#region Animal

[Serializable]
public class Animal
{
    public int index;
    public string name;
    public int effect;
    public string resouce;
    public string explanation;
}

[Serializable]
public class AnimalData : ILoader<int, Animal>
{
    public List<Animal> animals = new List<Animal>();

    public Dictionary<int, Animal> MakeDict()
    {
        Dictionary<int, Animal> dict = new Dictionary<int, Animal>();
        foreach (Animal animal in animals)
            dict.Add(animal.index, animal);
        return dict;
    }
}

#endregion