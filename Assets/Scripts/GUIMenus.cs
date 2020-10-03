using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIMenus : MonoBehaviour
{
    //used for buttons to go to a new scene
    public void NextScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    //used for buttons to quit game
    public void QuitGame() 
    {
        Application.Quit();
    }

}
