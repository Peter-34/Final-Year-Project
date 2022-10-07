using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxHeapRNGScript : MonoBehaviour
{
    public GameObject upperMostRootText, winpanel;

    public List<GameObject> dragPoints = new List<GameObject>();
    public int upperMostRootvalue;

    public int[] values = new int[6];

    private int randomValue;

    public int winValue;

    void Awake() 
    {
        upperMostRootvalue = Random.Range(85, 90);
        randomValue = Random.Range(81, 84);
        //(Scripting API n.d.)
        upperMostRootText.GetComponent<TextMeshPro>().SetText(upperMostRootvalue.ToString());
        GameObject.Find("DragPoint 1").GetComponent<HeapDragPointValues>().value = upperMostRootvalue;
        GameObject.Find("DragPoint 2").GetComponent<HeapDragPointValues>().value = upperMostRootvalue;

        GameObject.Find("Node 2").GetComponent<CreateMaxHeapScript>().value = randomValue;
        GameObject.Find("Node 2").GetComponentInChildren<TextMeshPro>().SetText(randomValue.ToString());
        values[0] = randomValue;
        randomValue = Random.Range(77,80);
        
        GameObject.Find("Node 3").GetComponent<CreateMaxHeapScript>().value = randomValue;
        GameObject.Find("Node 3").GetComponentInChildren<TextMeshPro>().SetText(randomValue.ToString());
        values[1] = randomValue;
        randomValue = Random.Range(73,76);

        GameObject.Find("Node 4").GetComponent<CreateMaxHeapScript>().value = randomValue;
        GameObject.Find("Node 4").GetComponentInChildren<TextMeshPro>().SetText(randomValue.ToString());
        values[2] = randomValue;
        randomValue = Random.Range(69,72);
        
        GameObject.Find("Node 5").GetComponent<CreateMaxHeapScript>().value = randomValue;
        GameObject.Find("Node 5").GetComponentInChildren<TextMeshPro>().SetText(randomValue.ToString());
        values[3] = randomValue;
        randomValue = Random.Range(65,68);

        GameObject.Find("Node 6").GetComponent<CreateMaxHeapScript>().value = randomValue;
        GameObject.Find("Node 6").GetComponentInChildren<TextMeshPro>().SetText(randomValue.ToString());
        values[4] = randomValue;
        randomValue = Random.Range(61,64);
        
        GameObject.Find("Node 7").GetComponent<CreateMaxHeapScript>().value = randomValue;
        GameObject.Find("Node 7").GetComponentInChildren<TextMeshPro>().SetText(randomValue.ToString());
        values[5] = randomValue;
    }

    void Update() 
    {
        if(winpanel.activeSelf == true)
        {
            //Do nothing
        }
        else if(winValue == 6)
        {
            winpanel.SetActive(true);
            GameObject.Find("Audio Victory").GetComponent<AudioSource>().Play();
        }
    }
}
