using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public static int Money;
    public int StartMoney = 100;
    public Text texteMoney;
    public static int lives;
    public int startingLifes;
    public Text livesText;

    public static int RoundsSurvived;

    void Start()
    {
        Money = StartMoney;
        lives = startingLifes;

        RoundsSurvived = 0;
    }

    void Update()
    {
        texteMoney.text = Money + " $";

        if (lives < 2)
            livesText.text = "Live : " + lives;
        else
            livesText.text = "Lives : " + lives;
    }
}
