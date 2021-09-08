using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static int score { get; private set; }
    float lastEnemyKillTime;
    int streakCount;
    float streakExpityTime = 1.5f;
    
    private void Start()
    {
        score = 0;
        Enemy.OnDeathStatic += OnEnemyKilled;
        FindObjectOfType<Player>().OnDeath += OnPlayerDeath;
    }

    void OnEnemyKilled()
    {
        if (Time.time < lastEnemyKillTime + streakExpityTime)
        {
            streakCount++;
        }
        else
        {
            streakCount = 0;
        }
        lastEnemyKillTime = Time.time;
        score += 1 + (int)Mathf.Pow(streakCount, 2);
    }

    void OnPlayerDeath()
    {
        Enemy.OnDeathStatic -= OnEnemyKilled;
    }
}
