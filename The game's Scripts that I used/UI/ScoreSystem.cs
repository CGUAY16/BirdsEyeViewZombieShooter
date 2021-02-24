using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TMP_Text totalScoreText;
    [SerializeField] TMP_Text killCountText;
    [SerializeField] TMP_Text lifeAmt;

    public static ScoreSystem instance;

    public static int totalScore;
    static int killCount;
    static int lifeTotal;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // if Level/Round 1, then set these to zero.

        totalScore = 0;
        killCount = 0;

        // this is for zombie kill count
        ZombieDefault.zombieDied += UpdateKillCount;
    }

    // Update is called once per frame
    public void UpdateScore(int newPoints)
    {
        MultiBarScript.multiBarInstance.UpdateCurrent(newPoints);
        totalScore += (newPoints * MultiBarScript.multiplierField);
        totalScoreText.SetText(totalScore.ToString() + "pts");
    }

    void UpdateKillCount()
    {
        killCount++;
        killCountText.SetText(killCount.ToString());
    }
}
