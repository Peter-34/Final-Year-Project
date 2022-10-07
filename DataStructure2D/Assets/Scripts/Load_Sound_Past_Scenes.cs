using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Sound_Past_Scenes : MonoBehaviour
{
    void Awake()
    {
        //Prevents the audio source from being destroyed during scene transition
        //Used for BGM
        DontDestroyOnLoad(this.gameObject);
    }
}
