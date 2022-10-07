using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeDisplayBTValues : MonoBehaviour
{
    public GameObject draggableNodeNumber;
    void Start() 
    {
        //(Scripting API n.d.)
        this.gameObject.GetComponent<TextMeshPro>().SetText(draggableNodeNumber.GetComponent<RNGForBinaryTree>().value.ToString());
    }
}
