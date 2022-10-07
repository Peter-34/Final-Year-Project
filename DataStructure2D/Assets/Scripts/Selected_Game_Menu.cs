using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selected_Game_Menu : MonoBehaviour
{
    public string gameSelectScreen, selectedGameStart, levelSelect;
    
    public void returnToGameSelectScreen()
    {
        SceneManager.LoadScene(gameSelectScreen);
    }

    public void startSelectedGame()
    {
        SceneManager.LoadScene(selectedGameStart);
    }

    public void levelSelectScreen()
    {
        SceneManager.LoadScene(levelSelect);
    }
}
