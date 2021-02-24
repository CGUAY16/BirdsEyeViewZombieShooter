using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePointValues : MonoBehaviour
{
    ScoreSystem scoreSystem;

    void Start()
    {
        scoreSystem = GetComponent<ScoreSystem>();
    }

    public void UpdatePoints()
    {  
    }

    public void UpdatePoints(int points)
    {
        ScoreSystem.totalScore += points;
        //scoreSystem.UpdateScore();
    }


}
