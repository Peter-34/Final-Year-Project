using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectStarScript : MonoBehaviour
{
    public string levelName;

    public GameObject star1, star2, star3;
    // Start is called before the first frame update
    void Start()
    {
        //3 star
        if(PlayerPrefs.GetInt(levelName) == 1)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(true);
        }
        //2 star
        if(PlayerPrefs.GetInt(levelName) == 2)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(false);
        }
        //1 star
        if(PlayerPrefs.GetInt(levelName) == 3)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(false);
            star3.gameObject.SetActive(false);
        }
        //No star
        if(PlayerPrefs.GetInt(levelName) == 4)
        {
            star1.gameObject.SetActive(false);
            star2.gameObject.SetActive(false);
            star3.gameObject.SetActive(false);
        }
    }
}
