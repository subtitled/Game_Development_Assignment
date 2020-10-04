using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class giveUp : MonoBehaviour
{
    public GameObject giveUpBox;
    public GameObject lossUI;

    public void boxOpen()
    {
        giveUpBox.gameObject.SetActive(true);
        
    }
    public void giveUpNow()
    {
        giveUpBox.gameObject.SetActive(false);
        lossUI.gameObject.SetActive(true);
    }
}
