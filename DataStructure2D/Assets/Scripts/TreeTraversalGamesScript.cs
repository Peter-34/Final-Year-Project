using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TreeTraversalGamesScript : MonoBehaviour
{
    public List<GameObject> dragPoints = new List<GameObject>();

    public GameObject failPanelNotCorrectOrder, previousDragPoint, correspondingNodeDisplay, winPanel, finalDragPoint;

    private Vector3 resetSpritePosition;
    private bool isDragging, playCorrectSound;

    private double snapRadius = 0.5f;

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
                //Prevents game object from moving once it is in position
                if(this.gameObject.transform.localPosition == dragPoints[0].transform.localPosition)
                {
                    isDragging = false;
                    playCorrectSound = false;
                }
                else
                {
                    isDragging = true;
                    playCorrectSound = true;
                }
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
        if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[0].transform.localPosition) <= snapRadius)
        {
            //prevents other nodes from being dragged to place if it is not in the correct order.
            //Node 1 has restrictions lifted using an empty gameobject.
            if(previousDragPoint.activeSelf == true)
            {
                failPanelNotCorrectOrder.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else
            {
                this.gameObject.transform.localPosition = dragPoints[0].transform.localPosition;
                //Changes the node color in the tree itself to reflect traversal order.
                correspondingNodeDisplay.transform.GetComponent<SpriteRenderer>().color = Color.green;
                dragPoints[0].SetActive(false);
                Destroy(this.gameObject.GetComponent<Color_Swap>());

                if(playCorrectSound == true)
                {
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
                
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[1].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[2].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[3].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[4].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[5].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[6].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[7].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[8].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[9].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[10].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[11].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[12].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[13].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[14].transform.localPosition) <= snapRadius)
        {
            failPanelNotCorrectOrder.SetActive(true);
            this.gameObject.transform.localPosition = resetSpritePosition;
            GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
        }
        else
        {
            this.gameObject.transform.localPosition = resetSpritePosition;
        }

        if(finalDragPoint.activeSelf == false)
        {
            winPanel.SetActive(true);
            GameObject.Find("Audio Victory").GetComponent<AudioSource>().Play();
        }
    }
}
