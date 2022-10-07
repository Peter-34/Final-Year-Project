using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Fail_Windows : MonoBehaviour
{
    public GameObject failPanel;

    public void closeFailPanel()
    {
        failPanel.gameObject.SetActive(false);
    }
}
