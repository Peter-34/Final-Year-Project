using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddMaxHeapScript : MonoBehaviour
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
        if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[5].transform.localPosition) <= snapRadius)
        {
            //prevents user from dragging the latest node back to a previous position.
            if(resetSpritePosition == dragPoints[2].transform.localPosition)
            {
                failPanelCheckAgain.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(resetSpritePosition == dragPoints[5].transform.localPosition)
            {
                this.gameObject.transform.localPosition = resetSpritePosition;
            }
            else
            {
                this.gameObject.transform.localPosition = dragPoints[5].transform.localPosition;
                resetSpritePosition = dragPoints[5].transform.localPosition;
                nodes[0].transform.localPosition = dragPoints[7].transform.localPosition;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[2].transform.localPosition) <= snapRadius)
        {
            if(resetSpritePosition == dragPoints[2].transform.localPosition)
            {
                //prevents error message from showing up if user clicks on the spot.
                this.gameObject.transform.localPosition = resetSpritePosition;
            }
            else if(resetSpritePosition == dragPoints[2].transform.localPosition)
            {
                this.gameObject.transform.localPosition = resetSpritePosition;
            }
            else if(resetSpritePosition != dragPoints[5].transform.localPosition)
            {
                failPanelIfSwappingWithChildOrParent.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                this.gameObject.transform.localPosition = dragPoints[2].transform.localPosition;
                resetSpritePosition = dragPoints[2].transform.localPosition;
                nodes[1].transform.localPosition = dragPoints[5].transform.localPosition;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[6].transform.localPosition) <= snapRadius)
        {
            if(resetSpritePosition == dragPoints[2].transform.localPosition)
            {
                failPanelCheckAgain.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                failPanelIfSwappingWithChildOrParent.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[0].transform.localPosition) <= snapRadius)
        {
            if(resetSpritePosition != dragPoints[2].transform.localPosition)
            {
                failPanelIfSwappingWithChildOrParent.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                this.gameObject.transform.localPosition = dragPoints[0].transform.localPosition;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                GameObject.Find("Audio Victory").GetComponent<AudioSource>().Play();
                this.gameObject.GetComponent<Rigidbody>().AddForce(12,12,12);
                winPanel.SetActive(true);
                nodes[3].transform.localPosition = dragPoints[2].transform.localPosition;
                Destroy(this.gameObject.GetComponent<AddMaxHeapScript>());
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[7].transform.localPosition) <= snapRadius)
        {
            if(resetSpritePosition == dragPoints[5].transform.localPosition || resetSpritePosition == dragPoints[2].transform.localPosition)
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
        else
        {
            this.gameObject.transform.localPosition = resetSpritePosition;
        }
    }
}
