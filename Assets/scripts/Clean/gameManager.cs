using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject gameOverUI;
    public GameObject GameWin;


    //private
    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded)
            return;

        if(PlayerStat.RoundsSurvived >= 30)
        {
            WinScreen();
            Time.timeScale = 0;
        }
        if(PlayerStat.lives <= 0)
        {
            EndGame();
            Time.timeScale = 0;
        }

    }
    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }

    void WinScreen()
    {
        gameEnded = true;
        GameWin.SetActive(true);
    }
}
