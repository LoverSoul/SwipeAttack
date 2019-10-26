using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Canvas pos;
    public GameObject game;
    public GameObject tapStartScreen;
    GameObject g;
    [Header("Score")]
    public Text score;
    public int highscore = 0;
    public int currentScore = 0;

    void Start()
    {
        UploadScore();
    }

    public void StartGame()
    {
       GameObject g = Instantiate(game, pos.transform);
        g.GetComponent<PlayerController>().contr = this;
        g.GetComponent<PlayerController>().startGameWindow = tapStartScreen;
       tapStartScreen.SetActive(false);
    }

    public void UploadScore()
    {
        if (currentScore > highscore)
        {
            score.text = "Score: " + currentScore;
            highscore = currentScore;
        }
        else
            score.text = "Score: " + highscore;
    }
}
