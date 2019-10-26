using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreConfig : MonoBehaviour
{
    public int scoreInGame = 0;
    GameController contr;

    void Start()
    {
        contr = GetComponent<PlayerController>().contr;
        contr.score.text = "Current Score: " + scoreInGame;
    }

    public void ShowScoreToPlayer()
    {
        contr.score.text = "Current Score: " + scoreInGame;
    }

    public void UploadScoreToController()
    {
            contr.currentScore = scoreInGame;
            contr.UploadScore();
        
    }
}
