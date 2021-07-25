using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{

    public Text roundsText;

    void Start()
    {
        roundsText.text = PlayerStat.RoundsSurvived.ToString();

    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MenuScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
