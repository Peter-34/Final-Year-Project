using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScriptGraphMatrix : MonoBehaviour
{
    public int value;

    public GameObject winPanel;

    
    void Update()
    {
        if(winPanel.activeSelf == true)
        {
            //Do nothing, prevents victory sound from playing nonstop.
        }
        else if(value == 14)
        {
            winPanel.SetActive(true);
            GameObject.Find("Audio Victory").GetComponent<AudioSource>().Play();
        }
    }
}
