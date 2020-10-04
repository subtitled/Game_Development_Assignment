using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpButton : MonoBehaviour
{
    public GameObject helpBox;
    public GameObject[] wepAbilChoices;
    public GameObject model;
    public int wep1;
    public int abil1;

    void Start()
    {
        wep1 = model.GetComponent<classScript>().wep_1;
        abil1 = model.GetComponent<classScript>().abil_1;
    }

    public void boxOpen()
    {
        helpBox.gameObject.SetActive(true);
        switch (wep1) 
        {
            case 0:
                wepAbilChoices[0].gameObject.SetActive(true);
                break;
            case 1:
                wepAbilChoices[1].gameObject.SetActive(true);
                break;
        }
        switch (abil1)
        {
            case 0:
                wepAbilChoices[2].gameObject.SetActive(true);
                break;
            case 1:
                wepAbilChoices[3].gameObject.SetActive(true);
                break;
        }
    }
}
