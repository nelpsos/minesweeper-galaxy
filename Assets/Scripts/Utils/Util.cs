using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
		if (component == null)
            component = go.AddComponent<T>();
        return component;
	}

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
            return null;

        return transform.gameObject;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
		}
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }

    public static Color GetCellStateColor(Define.CellState state)
    {
        switch (state)
        {
            case Define.CellState.ONE:
                return Color.red;
            case Define.CellState.TWO:
                return Color.blue;
            case Define.CellState.THREE:
                return Color.green;
            case Define.CellState.FOUR:
                return Color.cyan;
            case Define.CellState.FIVE:
                return Color.magenta;
            case Define.CellState.SIX:
            case Define.CellState.SEVEN:
            case Define.CellState.EIGHT:
            case Define.CellState.NINE:
                return Color.yellow;
            case Define.CellState.FLAG:
                break;
            case Define.CellState.OPEN:
                return Color.gray;
            case Define.CellState.CLOSE:
                return Color.white;
            case Define.CellState.MINE:
                return Color.black;
        }

        return Color.clear ;
    }
}
