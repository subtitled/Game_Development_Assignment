using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endGameScript : MonoBehaviour
{
    //sets up for storing exp values and total score
    private int unit1exp;
    private int unit2exp;
    private int unit3exp;
    private int unit4exp;
    private int unit5exp;
    private int totalScore;

    public int exp1 = 0;
    public int exp2 = 0;
    public int exp3 = 0;
    public int exp4 = 0;
    public int exp5 = 0;
    public int total = 0;

    //sets variables for the number next to the
    public Text u1Num;
    public Text u2Num;
    public Text u3Num;
    public Text u4Num;
    public Text u5Num;
    public Text tSNum;

    public int winOrLoss;

    public GameObject[] winLoss;


    // Start is called before the first frame update
    void Start()
    {
        unit1exp = PlayerPrefs.GetInt("U1XP");
        unit2exp = PlayerPrefs.GetInt("U2XP");
        unit3exp = PlayerPrefs.GetInt("U3XP");
        unit4exp = PlayerPrefs.GetInt("U4XP");
        unit5exp = PlayerPrefs.GetInt("U5XP");
        totalScore = PlayerPrefs.GetInt("TotalScore");
        winOrLoss = PlayerPrefs.GetInt("VorL");

        switch (winOrLoss)
        {
            case 0:
                winLoss[0].gameObject.SetActive(true);
                break;
            case 1:
                winLoss[1].gameObject.SetActive(true);
                break;
        }

    }

    //FixedUpdate is used to slow down the number increasing
    void FixedUpdate()
    {
        //increases the number values by 1 every update until it reaches the value imported from the game
        if (int.Parse(u1Num.text) < unit1exp)
        {
            u1Num.text = exp1.ToString();
            exp1 = exp1 + 1;
        }
        if (int.Parse(u2Num.text) < unit2exp)
        {
            u2Num.text = exp2.ToString();
            exp2 = exp2 + 1;
        }
        if (int.Parse(u3Num.text) < unit3exp)
        {
            u3Num.text = exp3.ToString();
            exp3 = exp3 + 1;
        }
        if (int.Parse(u4Num.text) < unit4exp)
        {
            u4Num.text = exp4.ToString();
            exp4 = exp4 + 1;
        }
        if (int.Parse(u5Num.text) < unit5exp)
        {
            u5Num.text = exp5.ToString();
            exp5 = exp5 + 1;
        }
        if (int.Parse(tSNum.text) < totalScore)
        {
            tSNum.text = total.ToString();
            total = total + 1;
        }
    }

  }
