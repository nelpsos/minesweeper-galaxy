using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }

    public enum MouseEvent
    {
        Press,
        Click,
        RPress,
        RClick,
    }

    public enum CellState
    {
        HIDDEN,
        OPEN,       //열림 상태   
    }

    public enum MineCount
    {
        NONE,
        ONE,        //주변 지뢰 개수
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
    }

    public enum GameMode
    {
        Ready,
        Play,
        Pause,
        Clear,
        GameOver,
    }

   

    public static int[] xIndex = { -1, 0, 1, -1, 0, 1, -1, 0, 1 };
    public static int[] yIndex = { -1, -1, -1, 0, 0, 0, 1, 1, 1 };

}
