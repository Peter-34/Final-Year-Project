using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GraphAdjListScript : MonoBehaviour
{
    private bool isDragging;

    private Vector3 resetSpritePosition;

    private double snapRadius = 0.5f;

    public GameObject failPanelWrongSlot, failPanelPrevNodeNotInPlace, failPanelOccupied;

    private Color correctColor;

    public List<GameObject> dragPoints = new List<GameObject>();

    void Start() 
    {
        resetSpritePosition = this.gameObject.transform.localPosition;
        correctColor = this.gameObject.GetComponent<SpriteRenderer>().color;
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
    
    //Incorrect dragpoints are the correct drag points for 0 and correct dragpoints is the incorrect dragpoint for 0
    //This code is done like this to avoid using another script albiet may be a bit confusing. 
    private void OnMouseUp() 
    {
        isDragging = false;
        //(French 2021b), (Scripting API n.d.)
        if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[0].transform.localPosition) <= snapRadius)
        {
            //Imposes restriction for subsequent elements such that there needs to be an element in place before it so it can be placed into its slot.
            if(dragPoints[0].GetComponent<SpriteRenderer>().color != Color.black)
            {
                failPanelOccupied.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(this.gameObject.name == "2")
            {
                if(dragPoints[3].GetComponentInChildren<TextMeshPro>().enabled == false)
                {
                    failPanelPrevNodeNotInPlace.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    dragPoints[0].GetComponent<SpriteRenderer>().color = correctColor;
                    dragPoints[0].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value = GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
            else if(this.gameObject.name == "4")
            {
                if(dragPoints[3].GetComponentInChildren<TextMeshPro>().enabled == false)
                {
                    failPanelPrevNodeNotInPlace.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    dragPoints[0].GetComponent<SpriteRenderer>().color = correctColor;
                    dragPoints[0].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value = GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                this.gameObject.transform.localPosition = resetSpritePosition;
                dragPoints[0].GetComponent<SpriteRenderer>().color = correctColor;
                dragPoints[0].GetComponentInChildren<TextMeshPro>().enabled = true;
                GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value = GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[1].transform.localPosition) <= snapRadius)
        {
            if(dragPoints[1].GetComponent<SpriteRenderer>().color != Color.black)
            {
                failPanelOccupied.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(this.gameObject.name == "4")
            {
                if(dragPoints[4].GetComponentInChildren<TextMeshPro>().enabled == false)
                {
                    failPanelPrevNodeNotInPlace.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    dragPoints[1].GetComponent<SpriteRenderer>().color = correctColor;
                    dragPoints[1].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value = GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                this.gameObject.transform.localPosition = resetSpritePosition;
                dragPoints[1].GetComponent<SpriteRenderer>().color = correctColor;
                dragPoints[1].GetComponentInChildren<TextMeshPro>().enabled = true;
                GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value = GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[2].transform.localPosition) <= snapRadius)
        {
            if(dragPoints[2].GetComponent<SpriteRenderer>().color != Color.black)
            {
                failPanelOccupied.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(this.gameObject.name == "3")
            {
                if(dragPoints[3].GetComponentInChildren<TextMeshPro>().enabled == false)
                {
                    failPanelPrevNodeNotInPlace.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    dragPoints[2].GetComponent<SpriteRenderer>().color = correctColor;
                    dragPoints[2].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value = GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                this.gameObject.transform.localPosition = resetSpritePosition;
                dragPoints[2].GetComponent<SpriteRenderer>().color = correctColor;
                dragPoints[2].GetComponentInChildren<TextMeshPro>().enabled = true;
                GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value = GameObject.Find("Node 1").GetComponent<WinScriptEdgeList>().value + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
            } 
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[3].transform.localPosition) <= snapRadius)
        {
            if(dragPoints[3].GetComponent<SpriteRenderer>().color != Color.black)
            {
                failPanelOccupied.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                failPanelWrongSlot.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[4].transform.localPosition) <= snapRadius)
        {
            if(dragPoints[4].GetComponent<SpriteRenderer>().color != Color.black)
            {
                failPanelOccupied.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                failPanelWrongSlot.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[5].transform.localPosition) <= snapRadius)
        {
            if(dragPoints[5].GetComponent<SpriteRenderer>().color != Color.black)
            {
                failPanelOccupied.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                failPanelWrongSlot.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[6].transform.localPosition) <= snapRadius)
        {
            if(dragPoints[6].GetComponent<SpriteRenderer>().color != Color.black)
            {
                failPanelOccupied.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                failPanelWrongSlot.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[7].transform.localPosition) <= snapRadius)
        {
            if(dragPoints[7].GetComponent<SpriteRenderer>().color != Color.black)
            {
                failPanelOccupied.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                failPanelWrongSlot.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[8].transform.localPosition) <= snapRadius)
        {
            if(dragPoints[8].GetComponent<SpriteRenderer>().color != Color.black)
            {
                failPanelOccupied.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                failPanelWrongSlot.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[9].transform.localPosition) <= snapRadius)
        {
            if(dragPoints[9].GetComponent<SpriteRenderer>().color != Color.black)
            {
                failPanelOccupied.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                failPanelWrongSlot.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            this.gameObject.transform.localPosition = resetSpritePosition;
        }

    }
}
