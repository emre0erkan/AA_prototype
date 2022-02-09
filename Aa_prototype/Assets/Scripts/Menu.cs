using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void PlayGame()
    {
        int levelNumber = PlayerPrefs.GetInt("save");

        if (levelNumber == 1)
            SceneManager.LoadScene(levelNumber + 1);
        else if (levelNumber == 0)
            SceneManager.LoadScene(levelNumber + 2);
        else if (levelNumber > 4) 
        { 
            levelNumber = 0;
            SceneManager.LoadScene(levelNumber);
        }
        else
            SceneManager.LoadScene(levelNumber);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void ResetLevel()
    {
        PlayerPrefs.DeleteAll();
    }
}
