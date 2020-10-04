using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeBox : MonoBehaviour
{
    public GameObject helpBox;

    public void boxClose()
    {
        helpBox.gameObject.SetActive(false);
    }
}
