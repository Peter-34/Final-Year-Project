using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Buttons_Action : MonoBehaviour
{
    public string gameSelectScreen;
    
    public GameObject instructionPanel;

    public GameObject informationPanel;

    public GameObject exitCurrentGamePanel;

    public void informationButton()
    {
        informationPanel.SetActive(true);
    }

    public void instructionButton()
    {
        instructionPanel.SetActive(true);
    }

    public void backButton()
    {
        exitCurrentGamePanel.SetActive(true);
    }

    public void okayButton()
    {
        instructionPanel.SetActive(false);
        informationPanel.SetActive(false);
    }
    public void yesButton()
    {
        SceneManager.LoadScene(gameSelectScreen);
    }

    public void noButton()
    {
        exitCurrentGamePanel.SetActive(false);
    }
}
