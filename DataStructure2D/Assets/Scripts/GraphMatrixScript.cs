using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GraphMatrixScript : MonoBehaviour
{
    private bool isDragging;

    private Vector3 resetSpritePosition;

    private double snapRadius = 0.3f;

    private Color color0, color1;

    public GameObject failPanelWrongSlot, failPanelOccupied;

    public List<GameObject> dragPoints, incorrectDragPoints = new List<GameObject>();

    void Start() 
    {
        resetSpritePosition = this.gameObject.transform.localPosition;
        color0 = GameObject.Find("0").GetComponent<SpriteRenderer>().color;
        color1 = GameObject.Find("1").GetComponent<SpriteRenderer>().color;
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
    private void OnMouseUp() 
    {
        isDragging = false;
        //incorrectDragPoints are correct drag points for 0 but incorrect for 1.
        //(French 2021b), (Scripting API n.d.)
        if(Vector2.Distance(this.gameObject.transform.localPosition, incorrectDragPoints[0].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
            {
                //If dragpoint is not black, it is occupied by a number
                if(incorrectDragPoints[0].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    incorrectDragPoints[0].GetComponent<SpriteRenderer>().color = color0;
                    incorrectDragPoints[0].GetComponentInChildren<TextMeshPro>().enabled = true;
                    //External Count variable in another script to keep track as it bugs out if using internal count. Used for enabling win panel.
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                if(incorrectDragPoints[0].GetComponent<SpriteRenderer>().color != Color.black)
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
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, incorrectDragPoints[1].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
            {
                if(incorrectDragPoints[1].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    incorrectDragPoints[1].GetComponent<SpriteRenderer>().color = color0;
                    incorrectDragPoints[1].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                //Fail Panels for when dragging to same slot or wrong position
                if(incorrectDragPoints[1].GetComponent<SpriteRenderer>().color != Color.black)
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
        }
        if(Vector2.Distance(this.gameObject.transform.localPosition, incorrectDragPoints[2].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
            {
                if(incorrectDragPoints[2].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    incorrectDragPoints[2].GetComponent<SpriteRenderer>().color = color0;
                    incorrectDragPoints[2].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                if(incorrectDragPoints[2].GetComponent<SpriteRenderer>().color != Color.black)
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
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, incorrectDragPoints[3].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
            {
                if(incorrectDragPoints[3].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    incorrectDragPoints[3].GetComponent<SpriteRenderer>().color = color0;
                    incorrectDragPoints[3].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                if(incorrectDragPoints[3].GetComponent<SpriteRenderer>().color != Color.black)
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
        }
        if(Vector2.Distance(this.gameObject.transform.localPosition, incorrectDragPoints[4].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
            {
                if(incorrectDragPoints[4].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    incorrectDragPoints[4].GetComponent<SpriteRenderer>().color = color0;
                    incorrectDragPoints[4].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                if(incorrectDragPoints[4].GetComponent<SpriteRenderer>().color != Color.black)
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
        }

        //dragPoints are correct for 1, incorrect for 0
        if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[0].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
            {
                if(dragPoints[0].GetComponent<SpriteRenderer>().color != Color.black)
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
                if(dragPoints[0].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    dragPoints[0].GetComponent<SpriteRenderer>().color = color1;
                    dragPoints[0].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[1].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
            {
                if(dragPoints[1].GetComponent<SpriteRenderer>().color != Color.black)
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
                if(dragPoints[1].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    dragPoints[1].GetComponent<SpriteRenderer>().color = color1;
                    dragPoints[1].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[2].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
            {
                if(dragPoints[2].GetComponent<SpriteRenderer>().color != Color.black)
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
                if(dragPoints[2].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    dragPoints[2].GetComponent<SpriteRenderer>().color = color1;
                    dragPoints[2].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[3].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
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
            else
            {
                if(dragPoints[3].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    dragPoints[3].GetComponent<SpriteRenderer>().color = color1;
                    dragPoints[3].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[4].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
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
            else
            {
                if(dragPoints[4].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    dragPoints[4].GetComponent<SpriteRenderer>().color = color1;
                    dragPoints[4].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[5].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
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
            else
            {
                if(dragPoints[5].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    dragPoints[5].GetComponent<SpriteRenderer>().color = color1;
                    dragPoints[5].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[6].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
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
            else
            {
                if(dragPoints[6].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    dragPoints[6].GetComponent<SpriteRenderer>().color = color1;
                    dragPoints[6].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[7].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
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
            else
            {
                if(dragPoints[7].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    dragPoints[7].GetComponent<SpriteRenderer>().color = color1;
                    dragPoints[7].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
        }
        else if(Vector2.Distance(this.gameObject.transform.localPosition, dragPoints[8].transform.localPosition) <= snapRadius)
        {
            if(this.gameObject.name == "0")
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
            else
            {
                if(dragPoints[8].GetComponent<SpriteRenderer>().color != Color.black)
                {
                    failPanelOccupied.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    dragPoints[8].GetComponent<SpriteRenderer>().color = color1;
                    dragPoints[8].GetComponentInChildren<TextMeshPro>().enabled = true;
                    GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value = GameObject.Find("Node 1").GetComponent<WinScriptGraphMatrix>().value + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                }
            }
        }
        else
        {
            this.gameObject.transform.localPosition = resetSpritePosition;
        }
    }
}
