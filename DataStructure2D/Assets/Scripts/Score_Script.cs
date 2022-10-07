using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Script : MonoBehaviour
{
    public GameObject star1, star2, star3, instructionPanel, winPanel;
    private float startTime;
    public Text timer;

    public string levelName;

    void Start()
    {
        //startTime only affected when specific scene is loaded.
        startTime = Time.timeSinceLevelLoad;
        //0.00 sets how many decimal place I want.
        timer.text = startTime.ToString("00");
    }

    void Update()
    {
        startTime = Time.timeSinceLevelLoad;
        timer.text = startTime.ToString("00");
        starTracker();
        timeTracker();
        pausePopUp();
    }

    private void starTracker()
    {
        if(winPanel.activeSelf == true)
        {
            //Three Stars
            if(0.00f <= startTime)
            {
                PlayerPrefs.SetInt(levelName, 1);
            }

            //Two star
            if(25.00f <= startTime) 
            {
                PlayerPrefs.SetInt(levelName, 2);
            }

            //One Star
            if(35.00f <= startTime) 
            {
                PlayerPrefs.SetInt(levelName, 3);
            }
            
            //No Star
            if(45.00f <= startTime) 
            {
                PlayerPrefs.SetInt(levelName, 4);
            }
        }
    }

    private void timeTracker()
    {
        //Two Star
        if(25.00f <= startTime) 
        {
            star3.gameObject.SetActive(false);
        }

        //One Star
        if(35.00f <= startTime) 
        {
            star2.gameObject.SetActive(false);
        }

        //No Star
        if(45.00f <= startTime) 
        {
            star1.gameObject.SetActive(false);
        }
    }

    private void pausePopUp()
    {
        if((instructionPanel.activeSelf || winPanel.activeSelf) == true )
        {
            pauseGame();
        }
    }
        
    //(French, 2020)
    public void resumeGame()
    {
        Time.timeScale = 1;
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }
}

