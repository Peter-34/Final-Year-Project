using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RNGForBinaryTree : MonoBehaviour
{
    public int value;
    void Awake() 
    {
        value = Random.Range(10,99);
        //(Scripting API n.d.)
        this.gameObject.GetComponentInChildren<TextMeshPro>().SetText(value.ToString());
    }
}
