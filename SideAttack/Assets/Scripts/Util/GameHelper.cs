using System;
using UnityEngine;

public class GameHelper
{
    private static float speedOffset = 7;
    private static int levelLoop = 5;
    private static int levelLoopForSpeed = 3;
    private static int enemyStartCount = 4;
    private static int addedEnemyCount = 2;

    public static float GetSpeed(int wave)
    {
        return speedOffset + ((float)wave / levelLoopForSpeed);
    }

    public static int GetEnemyCount(int wave)
    {
        int level = wave / levelLoop;
        Debug.Log("Level = " + level + " wave" + wave);
        int enemyCount = enemyStartCount + (level * addedEnemyCount);
        return enemyCount;
    }

    public int old(int wave)
    {
        int enemyCount = 0;
        switch (wave)
        {
            case int n when (n > 0 && n <= 5):
                enemyCount = 4;
                break;
            case int n when (n > 5 && n <= 10):
                enemyCount = 6;
                break;
            case int n when (n > 10 && n <= 15):
                enemyCount = 8;
                break;

        }

        return enemyCount;
    }
}
