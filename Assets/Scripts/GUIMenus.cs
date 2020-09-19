using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIMenus : MonoBehaviour
{
    public void NextScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

}
