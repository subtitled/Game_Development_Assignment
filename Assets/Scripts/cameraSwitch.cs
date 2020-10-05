using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraSwitch : MonoBehaviour
{
    public Camera[] cameras;
    public void Start()
    {
        cameras[0].enabled = true;
        cameras[1].enabled = false;
        cameras[2].enabled = false;
        cameras[3].enabled = false;
    }

    public void switchLeftCamera()
    {
        cameras[0].enabled = false;
        cameras[1].enabled = true;
        cameras[2].enabled = false;
        cameras[3].enabled = false;
    }

    public void switchFrontCamera() 
    {
        cameras[0].enabled = true;
        cameras[1].enabled = false;
        cameras[2].enabled = false;
        cameras[3].enabled = false;
    }

    public void switchBackCamera()
    {
        cameras[0].enabled = false;
        cameras[1].enabled = false;
        cameras[2].enabled = true;
        cameras[3].enabled = false;
    }

    public void switchRightCamera()
    {
        cameras[0].enabled = false;
        cameras[1].enabled = false;
        cameras[2].enabled = false;
        cameras[3].enabled = true;
    }
}
