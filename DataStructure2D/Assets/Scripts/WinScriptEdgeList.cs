using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScriptEdgeList : MonoBehaviour
{
    public int value;

    public GameObject winPanel;

    
    void Update()
    {
        
        if(winPanel.activeSelf == true)
        {
            //Do nothing, prevents victory sound from playing nonstop.
        }
        //Used in graph game part 3 since it needs the same value
        else if(value == 8)
        {
            winPanel.SetActive(true);
            GameObject.Find("Audio Victory").GetComponent<AudioSource>().Play();
        }
    }
}
