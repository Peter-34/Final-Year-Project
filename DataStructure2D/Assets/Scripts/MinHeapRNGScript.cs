using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinHeapRNGScript : MonoBehaviour
{
    public GameObject upperMostRootText, winpanel;

    public List<GameObject> dragPoints = new List<GameObject>();
    public int upperMostRootvalue;

    public int[] values = new int[6];

    private int randomValue;

    public int winValue;

    void Awake() 
    {
        upperMostRootvalue = Random.Range(1,5);
        randomValue = Random.Range(6,9);
        //(Scripting API n.d.)
        upperMostRootText.GetComponent<TextMeshPro>().SetText(upperMostRootvalue.ToString());
        GameObject.Find("DragPoint 1").GetComponent<HeapDragPointValues>().value = upperMostRootvalue;
        GameObject.Find("DragPoint 2").GetComponent<HeapDragPointValues>().value = upperMostRootvalue;

        GameObject.Find("Node 2").GetComponent<CreateMinHeapScript>().value = randomValue;
        GameObject.Find("Node 2").GetComponentInChildren<TextMeshPro>().SetText(randomValue.ToString());
        values[0] = randomValue;
        randomValue = Random.Range(10,13);
        
        GameObject.Find("Node 3").GetComponent<CreateMinHeapScript>().value = randomValue;
        GameObject.Find("Node 3").GetComponentInChildren<TextMeshPro>().SetText(randomValue.ToString());
        values[1] = randomValue;
        randomValue = Random.Range(14,17);

        GameObject.Find("Node 4").GetComponent<CreateMinHeapScript>().value = randomValue;
        GameObject.Find("Node 4").GetComponentInChildren<TextMeshPro>().SetText(randomValue.ToString());
        values[2] = randomValue;
        randomValue = Random.Range(18,21);
        
        GameObject.Find("Node 5").GetComponent<CreateMinHeapScript>().value = randomValue;
        GameObject.Find("Node 5").GetComponentInChildren<TextMeshPro>().SetText(randomValue.ToString());
        values[3] = randomValue;
        randomValue = Random.Range(22,25);

        GameObject.Find("Node 6").GetComponent<CreateMinHeapScript>().value = randomValue;
        GameObject.Find("Node 6").GetComponentInChildren<TextMeshPro>().SetText(randomValue.ToString());
        values[4] = randomValue;
        randomValue = Random.Range(26,29);
        
        GameObject.Find("Node 7").GetComponent<CreateMinHeapScript>().value = randomValue;
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
