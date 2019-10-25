using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject game;
    public GameObject tapStartScreen;
    GameObject g;


    public void StartGame()
    {
        game.SetActive(true);
        tapStartScreen.SetActive(false);
    }

    public void EndGame()
    {
        tapStartScreen.SetActive(true);
    }
}
