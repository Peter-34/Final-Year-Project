using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Load_Next_Scene : MonoBehaviour
{
    public string nextScene;
    
    public void loadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
