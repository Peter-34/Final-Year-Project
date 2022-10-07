using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateMaxHeapScript : MonoBehaviour
{
    private bool isDragging;
    public List<GameObject> dragPoints = new List<GameObject>();
    private Vector3 resetSpritePosition;

    public GameObject failPanelTwoPreviousNode, failPanelNodeInPlace, failPanelNoOtherOptions;
    //Public instead of private so random number can be assigned to each node from MaxHeapRNGScript
    public int value; 

    private int[] values = new int[6];

    private double snapRadius = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        resetSpritePosition = this.gameObject.transform.localPosition;
        //Stores the random values from MaxHeapRNGScript to values. 
        for(int i = 0; i < values.Length; i++)
        {
            //Stores from largest to smallest
            values[i] = GameObject.Find("Node 1").GetComponent<MaxHeapRNGScript>().values[i];
        }
    }

    private void OnMouseDown() 
    {   
        //Checks if there is a menu open over the gameobject, if yes, no interaction with gameobject allowed.
        //(Unity Documentation 2018)
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            //Left Mouse Click, change 0 to 1 for right click and 2 for middle click
            if(Input.GetMouseButtonDown(0))
            {
                isDragging = true;
            }
        }
    }

    private void OnMouseDrag() 
    {
        if(isDragging == true)
        {
            //(French 2021a)
            Vector3 mousePosition;
            //sets the value of mousePos to the cursor location on screen
            mousePosition = Input.mousePosition;
            //converts screen point of mouse to world point of mouse through the camera
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //Updates the current gameobject position to whatever position the mouse is in. 
            this.gameObject.transform.localPosition = new Vector3(mousePosition.x, mousePosition.y, 1);
        }
    }

    private void OnMouseUp() 
    {
        isDragging = false;
        //Left child of main root/Root 1
        //Compares the gameobject being held by mousepointer and the dragPoints static position. If within a certain radius, snap to it upon mouseUp
        //(French 2021b)
        if(Vector2.Distance(dragPoints[0].transform.localPosition, this.gameObject.transform.localPosition) <= snapRadius)
        {
            if(dragPoints[0].activeSelf == false)
            {
                failPanelNodeInPlace.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(value == values[0] || value == values[1])
            {
                this.gameObject.transform.localPosition = dragPoints[0].transform.localPosition;
                dragPoints[0].GetComponent<HeapDragPointValues>().value = value;
                dragPoints[0].SetActive(false);
                GameObject.Find("Node 1").GetComponent<MaxHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MaxHeapRNGScript>().winValue + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                //Prevents anymore movement for objects in place by destroying script.
                Destroy(this.gameObject.GetComponent<CreateMaxHeapScript>());
                Destroy(this.gameObject.GetComponent<Color_Swap>());
            }
            else
            {
                failPanelNoOtherOptions.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        //Right Child of main root/Root 2
        else if(Vector2.Distance(dragPoints[1].transform.localPosition, this.gameObject.transform.localPosition) <= snapRadius)
        {
            if(dragPoints[1].activeSelf == false)
            {
                failPanelNodeInPlace.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(value == values[0] || value == values[1])
            {
                this.gameObject.transform.localPosition = dragPoints[1].transform.localPosition;
                dragPoints[1].GetComponent<HeapDragPointValues>().value = value;
                dragPoints[1].SetActive(false);
                GameObject.Find("Node 1").GetComponent<MaxHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MaxHeapRNGScript>().winValue + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                //Prevents anymore movement for objects in place by destroying script.
                Destroy(this.gameObject.GetComponent<CreateMaxHeapScript>());
                Destroy(this.gameObject.GetComponent<Color_Swap>());
            }
            else
            {
                failPanelNoOtherOptions.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        //Left Child of Root 1
        else if(Vector2.Distance(dragPoints[2].transform.localPosition, this.gameObject.transform.localPosition) <= snapRadius)
        {
            if(dragPoints[0].activeSelf == true)
            {
                failPanelTwoPreviousNode.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(dragPoints[2].activeSelf == false)
            {
                failPanelNodeInPlace.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(value == values[0] || value == values[1])
            {
                failPanelNoOtherOptions.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                this.gameObject.transform.localPosition = dragPoints[2].transform.localPosition;
                dragPoints[2].SetActive(false);
                GameObject.Find("Node 1").GetComponent<MaxHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MaxHeapRNGScript>().winValue + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                //Prevents anymore movement for objects in place by destroying script.
                Destroy(this.gameObject.GetComponent<CreateMaxHeapScript>());
                Destroy(this.gameObject.GetComponent<Color_Swap>());
            }
        }
        //Right Child of Root 1
        else if(Vector2.Distance(dragPoints[3].transform.localPosition, this.gameObject.transform.localPosition) <= snapRadius)
        {
            if(dragPoints[0].activeSelf == true)
            {
                failPanelTwoPreviousNode.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(dragPoints[3].activeSelf == false)
            {
                failPanelNodeInPlace.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(value == values[0] || value == values[1])
            {
                failPanelNoOtherOptions.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                this.gameObject.transform.localPosition = dragPoints[3].transform.localPosition;
                dragPoints[3].SetActive(false);
                GameObject.Find("Node 1").GetComponent<MaxHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MaxHeapRNGScript>().winValue + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                //Prevents anymore movement for objects in place by destroying script.
                Destroy(this.gameObject.GetComponent<CreateMaxHeapScript>());
                Destroy(this.gameObject.GetComponent<Color_Swap>());
            }
        }
        //Left Child of Root 2
        else if(Vector2.Distance(dragPoints[4].transform.localPosition, this.gameObject.transform.localPosition) <= snapRadius)
        {
            if(dragPoints[1].activeSelf == true)
            {
                failPanelTwoPreviousNode.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(dragPoints[4].activeSelf == false)
            {
                failPanelNodeInPlace.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(value == values[0] || value == values[1])
            {
                failPanelNoOtherOptions.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                this.gameObject.transform.localPosition = dragPoints[4].transform.localPosition;
                dragPoints[4].SetActive(false);
                GameObject.Find("Node 1").GetComponent<MaxHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MaxHeapRNGScript>().winValue + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                //Prevents anymore movement for objects in place by destroying script.
                Destroy(this.gameObject.GetComponent<CreateMaxHeapScript>());
                Destroy(this.gameObject.GetComponent<Color_Swap>());
            }
        }
        //Right Child of Root 2
        else if(Vector2.Distance(dragPoints[5].transform.localPosition, this.gameObject.transform.localPosition) <= snapRadius)
        {
            if(dragPoints[1].activeSelf == true)
            {
                failPanelTwoPreviousNode.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(dragPoints[5].activeSelf == false)
            {
                failPanelNodeInPlace.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(value == values[0] || value == values[1])
            {
                failPanelNoOtherOptions.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                this.gameObject.transform.localPosition = dragPoints[5].transform.localPosition;
                dragPoints[5].SetActive(false);
                GameObject.Find("Node 1").GetComponent<MaxHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MaxHeapRNGScript>().winValue + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                //Prevents anymore movement for objects in place by destroying script.
                Destroy(this.gameObject.GetComponent<CreateMaxHeapScript>());
                Destroy(this.gameObject.GetComponent<Color_Swap>());
            }
        }
        else 
        {
            this.gameObject.transform.localPosition = resetSpritePosition;
        }
    }
}
