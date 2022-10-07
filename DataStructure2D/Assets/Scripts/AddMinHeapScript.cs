using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddMinHeapScript : MonoBehaviour
{
    private bool isDragging;

    private Vector3 resetSpritePosition;

    private double snapRadius = 0.5f;

    public List<GameObject> dragPoints, nodes = new List<GameObject>();

    public GameObject winPanel, failPanelCheckAgain, failPanelIfSwappingWithChildOrParent;

    void Start() 
    {
        resetSpritePosition = this.gameObject.transform.localPosition;
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
        //(French 2021b)
        if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[7].transform.localPosition) <= snapRadius)
        {
            //Fail condition if the user drags the added node back to the starting node.
            if(nodes[0].transform.localPosition == dragPoints[7].transform.localPosition)
            {
                failPanelCheckAgain.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                this.gameObject.transform.localPosition = resetSpritePosition;
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[3].transform.localPosition) <= snapRadius)
        {
            //Fail condition if the user drags the added node back to the 2nd swapped node.
            if(nodes[1].transform.localPosition == dragPoints[3].transform.localPosition)
            {
                failPanelCheckAgain.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(resetSpritePosition == dragPoints[3].transform.localPosition)
            {
                //Prevents correct sound from playing multiple times
                this.gameObject.transform.localPosition = resetSpritePosition;
            }
            else
            {
                this.gameObject.transform.localPosition = dragPoints[3].transform.localPosition;
                nodes[0].transform.localPosition = dragPoints[7].transform.localPosition;
                resetSpritePosition = dragPoints[3].transform.localPosition;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[1].transform.localPosition) <= snapRadius)
        {
            if(resetSpritePosition == dragPoints[1].transform.localPosition)
            {
                this.gameObject.transform.localPosition = resetSpritePosition;
            }
            else if(resetSpritePosition != dragPoints[3].transform.localPosition)
            {
                failPanelIfSwappingWithChildOrParent.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                this.gameObject.transform.localPosition = dragPoints[1].transform.localPosition;
                nodes[1].transform.localPosition = dragPoints[3].transform.localPosition;
                resetSpritePosition = dragPoints[1].transform.localPosition;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[0].transform.localPosition) <= snapRadius)
        {
            if(resetSpritePosition != dragPoints[1].transform.localPosition)
            {
                failPanelIfSwappingWithChildOrParent.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                this.gameObject.transform.localPosition = dragPoints[0].transform.localPosition;
                winPanel.SetActive(true);
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                GameObject.Find("Audio Victory").GetComponent<AudioSource>().Play();
                nodes[2].transform.localPosition = dragPoints[1].transform.localPosition;
                Destroy(this.gameObject.GetComponent<AddMinHeapScript>());
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[4].transform.localPosition) <= snapRadius)
        {
            if(resetSpritePosition != dragPoints[1].transform.localPosition)
            {
                failPanelIfSwappingWithChildOrParent.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                //Fail condition if the user tries to swap with one of the node that is not of smallest value. 
                failPanelCheckAgain.SetActive(true);
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
