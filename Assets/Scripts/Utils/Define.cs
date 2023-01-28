using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        Unknown,
        Title,
        SelectAnimal,
        SelectSpaceSuit,
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
        Over,
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
        ZERO,
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
        Roadmap,
        RoundInfo,
        Ready,
        Play,
        Reward,
        Pause,
        Clear,
        GameOver,
    }


    public static int[] xIndex = { -1, 0, 1, -1, 0, 1, -1, 0, 1 };
    public static int[] yIndex = { -1, -1, -1, 0, 0, 0, 1, 1, 1 };

    public const int MAX_LIFE = 5;
    public const int MAX_ROUND_INFO = 3;
    public const int MAX_ANIMAL = 3;
    public const int MAX_BAG = 4;

}
