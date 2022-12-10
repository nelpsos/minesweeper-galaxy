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