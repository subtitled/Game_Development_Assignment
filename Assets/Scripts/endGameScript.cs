using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endGameScript : MonoBehaviour
{
    private int unit1exp;
    private int unit2exp;
    private int unit3exp;
    private int unit4exp;
    private int unit5exp;
    private int totalScore;

    public Text u1Num;
    public Text u2Num;
    public Text u3Num;
    public Text u4Num;
    public Text u5Num;
    public Text tSNum;

    public float duration = 0.5f;
    private int test = 100;
    private int exp1 = 0;
    private int exp2 = 0;
    private int exp3 = 0;
    private int exp4 = 0;
    private int exp5 = 0;
    private int total = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (int.Parse(u1Num.text) < test)
        {
            u1Num.text = exp1.ToString();
            exp1 = exp1 + 1;
        }
        if (int.Parse(u2Num.text) < test)
        {
            u2Num.text = exp2.ToString();
            exp2 = exp2 + 1;
        }
        if (int.Parse(u3Num.text) < test)
        {
            u3Num.text = exp3.ToString();
            exp3 = exp3 + 1;
        }
        if (int.Parse(u4Num.text) < test)
        {
            u4Num.text = exp4.ToString();
            exp4 = exp4 + 1;
        }
        if (int.Parse(u5Num.text) < test)
        {
            u5Num.text = exp5.ToString();
            exp5 = exp5 + 1;
        }
        if (int.Parse(tSNum.text) < test)
        {
            tSNum.text = total.ToString();
            total = total + 1;
        }
    }

  }
