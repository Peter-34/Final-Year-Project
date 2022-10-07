using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateMinHeapScript : MonoBehaviour
{
    private bool isDragging;
    public List<GameObject> dragPoints = new List<GameObject>();
    private Vector3 resetSpritePosition;

    public GameObject failPanelTwoPreviousNode, failPanelCheckIfSmallest, failPanelNodeInPlace, failPanelParentSmaller, failPanelNoOtherOptions;
    //Public instead of private so random number can be assigned to each node from *MinHeapRNGScript*
    public int value; 

    private int[] values = new int[6];

    private double snapRadius = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        resetSpritePosition = this.gameObject.transform.localPosition;
        //Stores the random values from MinHeapRNGScript to values. 
        for(int i = 0; i < values.Length; i++)
        {
            //Stores from smallest to largest
            values[i] = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().values[i];
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
            //Checks if there is already a node in place
            if(dragPoints[0].activeSelf == false)
            {
                failPanelNodeInPlace.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            //Makes sure smallest value is droppable based on below restriction
            else if(value == values[0])
            {
                this.gameObject.transform.localPosition = dragPoints[0].transform.localPosition;
                dragPoints[0].GetComponent<HeapDragPointValues>().value = value;
                dragPoints[0].SetActive(false);
                GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                //Prevents anymore movement for objects in place by destroying script and to prevent color swapping to indicate it can no longer be moved.
                Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                Destroy(this.gameObject.GetComponent<Color_Swap>());
            }
            //Makes sure that smallest value of the group is in 2nd layer if the other child of main root is not the smallest.
            else if(dragPoints[1].GetComponent<HeapDragPointValues>().value != values[0] && dragPoints[1].activeSelf == false)
            {
                failPanelCheckIfSmallest.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            //Checks if the dragged node is bigger than root node, if true, allow snap to dragpoint. if false, error message, reset node to starting position.
            else if(value > dragPoints[0].GetComponent<HeapDragPointValues>().value)
            {
                //Ensures the two largest value is not droppable in any of the 2nd layer and everything else is.
                if(value == values[5] || value == values[4])
                {
                    failPanelCheckIfSmallest.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = dragPoints[0].transform.localPosition;
                    //We update the second layer dragPoints to match the value of the node that has been dropped in. 
                    dragPoints[0].GetComponent<HeapDragPointValues>().value = value;
                    dragPoints[0].SetActive(false);
                    GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                    Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                    Destroy(this.gameObject.GetComponent<Color_Swap>());
                }
            }
            else
            {
                //Fail screen if the root node is smaller.
                failPanelParentSmaller.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        //Right Child of main root/Root 2
        else if(Vector2.Distance(dragPoints[1].transform.localPosition, this.gameObject.transform.localPosition) <= snapRadius)
        {
            //Checks if there is already a node in place
            if(dragPoints[1].activeSelf == false)
            {
                failPanelNodeInPlace.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            //Makes sure smallest value is droppable based on below restriction
            else if(value == values[0])
            {
                this.gameObject.transform.localPosition = dragPoints[1].transform.localPosition;
                dragPoints[1].GetComponent<HeapDragPointValues>().value = value;
                dragPoints[1].SetActive(false);
                GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                Destroy(this.gameObject.GetComponent<Color_Swap>());
            }
            //Makes sure that smallest value of the group is in 2nd layer if the other child of main root is not the smallest.
            else if(dragPoints[0].GetComponent<HeapDragPointValues>().value != values[0] && dragPoints[0].activeSelf == false)
            {
                failPanelCheckIfSmallest.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            //Checks if the dragged node is bigger than root node, if true, allow snap to dragpoint. if false, error message, reset node to starting position.
            else if(value > dragPoints[1].GetComponent<HeapDragPointValues>().value)
            {
                //Ensures the two largest value is not droppable in any of the 2nd layer and everything else is.
                if(value == values[5] || 
                value == values[4])
                {
                    failPanelCheckIfSmallest.SetActive(true);
                    this.gameObject.transform.localPosition = resetSpritePosition;
                    GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                }
                else
                {
                    this.gameObject.transform.localPosition = dragPoints[1].transform.localPosition;
                    dragPoints[1].GetComponent<HeapDragPointValues>().value = value;
                    dragPoints[1].SetActive(false);
                    GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                    GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                    Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                    Destroy(this.gameObject.GetComponent<Color_Swap>());
                }
            }
            else
            {
                //Fail screen if the root node is smaller.
                failPanelParentSmaller.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
            }
        }
        //Left Child of Root 1
        else if(Vector2.Distance(dragPoints[2].transform.localPosition, this.gameObject.transform.localPosition) <= snapRadius)
        {
            //Checks if there is already a node in place
            if(dragPoints[2].activeSelf == false)
            {
                failPanelNodeInPlace.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            //Checks if the parent node is there
            else if(dragPoints[0].activeSelf == true)
            {
                failPanelTwoPreviousNode.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            //Checks if layer 2 nodes are minimum value and 3rd largest value regardless of position
            else if((dragPoints[0].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[1].GetComponent<HeapDragPointValues>().value == values[3]) ||
            (dragPoints[1].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[0].GetComponent<HeapDragPointValues>().value == values[3]))
            {
                //If parent node is minimum value then do not allow the two largest value to drop but allow everything else.
                if(dragPoints[0].GetComponent<HeapDragPointValues>().value == values[0])
                {
                    if(value == values[4] || value == values[5])
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                    else if(value > dragPoints[0].GetComponent<HeapDragPointValues>().value)
                    {
                        this.gameObject.transform.localPosition = dragPoints[2].transform.localPosition;
                        dragPoints[2].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                }
                //If parent node is 3rd largest number, then allow the two largest to drop, rejects everything else.
                else if(dragPoints[0].GetComponent<HeapDragPointValues>().value == values[3])
                {
                    if(value == values[4] || value == values[5])
                    {
                        this.gameObject.transform.localPosition = dragPoints[2].transform.localPosition;
                        dragPoints[2].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                }
            }
            //Checks if layer 2 nodes are minimum value and 4th largest value regardless of position
            else if((dragPoints[0].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[1].GetComponent<HeapDragPointValues>().value == values[2]) ||
            (dragPoints[1].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[0].GetComponent<HeapDragPointValues>().value == values[2]))
            {
                //If parent node is minimum value then allow all value but one of them needs to be the 2nd smallest number.
                if(dragPoints[0].GetComponent<HeapDragPointValues>().value == values[0])
                {
                    //Checks Right Child of Root 1 to see if it is the 2nd smallest number, if yes allow placement of any number.
                    if(dragPoints[3].GetComponent<HeapDragPointValues>().value == values[1])
                    {
                        this.gameObject.transform.localPosition = dragPoints[2].transform.localPosition;
                        dragPoints[2].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[2].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    //Checks Right Child of Root 1 to see if it is empty, if so then allow placement of any number.
                    else if(dragPoints[3].GetComponent<HeapDragPointValues>().value == 0)
                    {
                        this.gameObject.transform.localPosition = dragPoints[2].transform.localPosition;
                        dragPoints[2].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[2].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    //Allows placement of 2nd smallest value. 
                    else if(value == values[1])
                    {
                        this.gameObject.transform.localPosition = dragPoints[2].transform.localPosition;
                        dragPoints[2].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[2].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    //Prevents other numbers from being placed if 2nd smallest number is not in either child. 
                    else if(dragPoints[3].GetComponent<HeapDragPointValues>().value != values[1])
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                }
                //If the Left Child of Root 1 value is 4th largest value then  allow placement of any value.
                else if(dragPoints[0].GetComponent<HeapDragPointValues>().value == values[2])
                {
                    if(value > dragPoints[0].GetComponent<HeapDragPointValues>().value)
                    {
                        this.gameObject.transform.localPosition = dragPoints[2].transform.localPosition;
                        dragPoints[2].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                }
            }
            //Checks if the dragged node is bigger than root node, if true, allow snap to dragpoint. if false, error message, reset node to starting position.
            else if(value > dragPoints[0].GetComponent<HeapDragPointValues>().value)
            {
                this.gameObject.transform.localPosition = dragPoints[2].transform.localPosition;
                dragPoints[2].SetActive(false);
                GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                Destroy(this.gameObject.GetComponent<Color_Swap>());
            }
            else
            {
                failPanelParentSmaller.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        //Right Child of Root 1
        else if(Vector2.Distance(dragPoints[3].transform.localPosition, this.gameObject.transform.localPosition) <= snapRadius)
        {
            //Checks if there is already a node in place
            if(dragPoints[3].activeSelf == false)
            {
                failPanelNodeInPlace.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(dragPoints[0].activeSelf == true)
            {
                failPanelTwoPreviousNode.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            //Checks if layer 2 nodes are minimum value and 3rd largest value regardless of position
            else if((dragPoints[0].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[1].GetComponent<HeapDragPointValues>().value == values[3]) ||
            (dragPoints[1].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[0].GetComponent<HeapDragPointValues>().value == values[3]))
            {
                //If parent node is minimum value then do not allow the two largest value to drop but allow everything else.
                if(dragPoints[0].GetComponent<HeapDragPointValues>().value == values[0])
                {
                    if(value == values[4] || value == values[5])
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                    else if(value > dragPoints[0].GetComponent<HeapDragPointValues>().value)
                    {
                        this.gameObject.transform.localPosition = dragPoints[3].transform.localPosition;
                        dragPoints[3].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[3].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                }
                //If parent node is 3rd largest number, then allow the two largest to drop, rejects everything else.
                else if(dragPoints[0].GetComponent<HeapDragPointValues>().value == values[3])
                {
                    if(value == values[4] || value == values[5])
                    {
                        this.gameObject.transform.localPosition = dragPoints[3].transform.localPosition;
                        dragPoints[3].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[3].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                }
            }
            else if((dragPoints[0].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[1].GetComponent<HeapDragPointValues>().value == values[2]) ||
            (dragPoints[1].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[0].GetComponent<HeapDragPointValues>().value == values[2]))
            {
                //If parent node is minimum value then allow all value but one of them needs to be the 2nd smallest number.
                if(dragPoints[0].GetComponent<HeapDragPointValues>().value == values[0])
                {
                    if(dragPoints[2].GetComponent<HeapDragPointValues>().value == values[1])
                    {
                        this.gameObject.transform.localPosition = dragPoints[3].transform.localPosition;
                        dragPoints[3].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[3].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else if(dragPoints[2].GetComponent<HeapDragPointValues>().value == 0)
                    {
                        this.gameObject.transform.localPosition = dragPoints[3].transform.localPosition;
                        dragPoints[3].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[3].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else if(value == values[1])
                    {
                        this.gameObject.transform.localPosition = dragPoints[3].transform.localPosition;
                        dragPoints[3].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[3].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else if(dragPoints[2].GetComponent<HeapDragPointValues>().value != values[1])
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                }
                else if(dragPoints[0].GetComponent<HeapDragPointValues>().value == values[2])
                {
                    if(value > dragPoints[0].GetComponent<HeapDragPointValues>().value)
                    {
                        this.gameObject.transform.localPosition = dragPoints[3].transform.localPosition;
                        dragPoints[3].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                }
            }
            //Checks if the dragged node is bigger than root node, if true, allow snap to dragpoint. if false, error message, reset node to starting position.
            else if(value > dragPoints[0].GetComponent<HeapDragPointValues>().value)
            {
                this.gameObject.transform.localPosition = dragPoints[3].transform.localPosition;
                dragPoints[3].GetComponent<HeapDragPointValues>().value = value;
                dragPoints[3].SetActive(false);
                GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                Destroy(this.gameObject.GetComponent<Color_Swap>());
            }
            else
            {
                failPanelParentSmaller.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        //Left Child of Root 2
        else if(Vector2.Distance(dragPoints[4].transform.localPosition, this.gameObject.transform.localPosition) <= snapRadius)
        {
            //Checks if there is already a node in place
            if(dragPoints[4].activeSelf == false)
            {
                failPanelNodeInPlace.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(dragPoints[1].activeSelf == true)
            {
                failPanelTwoPreviousNode.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            //Checks if layer 2 nodes are minimum value and 3rd largest value regardless of position
            else if((dragPoints[0].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[1].GetComponent<HeapDragPointValues>().value == values[3]) ||
            (dragPoints[1].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[0].GetComponent<HeapDragPointValues>().value == values[3]))
            {
                //If parent node is minimum value then do not allow the two largest value to drop but allow everything else.
                if(dragPoints[1].GetComponent<HeapDragPointValues>().value == values[0])
                {
                    if(value == values[4] || value == values[5])
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                    }
                    else if(value > dragPoints[1].GetComponent<HeapDragPointValues>().value)
                    {
                        this.gameObject.transform.localPosition = dragPoints[4].transform.localPosition;
                        dragPoints[4].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[4].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                }
                //If parent node is 3rd largest number, then allow the two largest to drop.
                else if(dragPoints[1].GetComponent<HeapDragPointValues>().value == values[3])
                {
                    if(value == values[4] || value == values[5])
                    {
                        this.gameObject.transform.localPosition = dragPoints[4].transform.localPosition;
                        dragPoints[4].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[4].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                }
            }
            else if((dragPoints[0].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[1].GetComponent<HeapDragPointValues>().value == values[2]) ||
            (dragPoints[1].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[0].GetComponent<HeapDragPointValues>().value == values[2]))
            {
                //If parent node is minimum value then allow all value but one of them needs to be the 2nd smallest number.
                if(dragPoints[1].GetComponent<HeapDragPointValues>().value == values[0])
                {
                    if(dragPoints[5].GetComponent<HeapDragPointValues>().value == values[1])
                    {
                        this.gameObject.transform.localPosition = dragPoints[4].transform.localPosition;
                        dragPoints[4].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[4].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else if(dragPoints[5].GetComponent<HeapDragPointValues>().value == 0)
                    {
                        this.gameObject.transform.localPosition = dragPoints[4].transform.localPosition;
                        dragPoints[4].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[4].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else if(value == values[1])
                    {
                        this.gameObject.transform.localPosition = dragPoints[4].transform.localPosition;
                        dragPoints[4].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[4].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else if(dragPoints[5].GetComponent<HeapDragPointValues>().value != values[1])
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                }
                else if(dragPoints[1].GetComponent<HeapDragPointValues>().value == values[2])
                {
                    if(value > dragPoints[1].GetComponent<HeapDragPointValues>().value)
                    {
                        this.gameObject.transform.localPosition = dragPoints[4].transform.localPosition;
                        dragPoints[4].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                }
            }
            //Checks if the dragged node is bigger than root node, if true, allow snap to dragpoint. if false, error message, reset node to starting position.
            else if(value > dragPoints[1].GetComponent<HeapDragPointValues>().value)
            {
                this.gameObject.transform.localPosition = dragPoints[4].transform.localPosition;
                dragPoints[4].GetComponent<HeapDragPointValues>().value = value;
                dragPoints[4].SetActive(false);
                GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                Destroy(this.gameObject.GetComponent<Color_Swap>());
            }
            else
            {
                failPanelParentSmaller.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
        }
        //Right Child of Root 2
        else if(Vector2.Distance(dragPoints[5].transform.localPosition, this.gameObject.transform.localPosition) <= snapRadius)
        {
            //Checks if there is already a node in place
            if(dragPoints[5].activeSelf == false)
            {
                failPanelNodeInPlace.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            else if(dragPoints[1].activeSelf == true)
            {
                failPanelTwoPreviousNode.SetActive(true);
                this.gameObject.transform.localPosition = resetSpritePosition;
                GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
            }
            //Checks if layer 2 nodes are minimum value and 3rd largest value regardless of position
            else if((dragPoints[0].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[1].GetComponent<HeapDragPointValues>().value == values[3]) ||
            (dragPoints[1].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[0].GetComponent<HeapDragPointValues>().value == values[3]))
            {
                //If parent node is minimum value then do not allow the two largest value to drop but allow everything else.
                if(dragPoints[1].GetComponent<HeapDragPointValues>().value == values[0])
                {
                    if(value == values[4] || value == values[5])
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                    else if(value > dragPoints[1].GetComponent<HeapDragPointValues>().value)
                    {
                        this.gameObject.transform.localPosition = dragPoints[5].transform.localPosition;
                        dragPoints[5].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[5].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                }
                //If parent node is 3rd largest number, then allow the two largest to drop.
                else if(dragPoints[1].GetComponent<HeapDragPointValues>().value == values[3])
                {
                    if(value == values[4] || value == values[5])
                    {
                        this.gameObject.transform.localPosition = dragPoints[5].transform.localPosition;
                        dragPoints[5].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[5].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                }
            }
            else if((dragPoints[0].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[1].GetComponent<HeapDragPointValues>().value == values[2]) ||
            (dragPoints[1].GetComponent<HeapDragPointValues>().value == values[0] && dragPoints[0].GetComponent<HeapDragPointValues>().value == values[2]))
            {
                //If parent node is minimum value then allow all value but one of them needs to be the 2nd smallest number.
                if(dragPoints[1].GetComponent<HeapDragPointValues>().value == values[0])
                {
                    if(dragPoints[4].GetComponent<HeapDragPointValues>().value == values[1])
                    {
                        this.gameObject.transform.localPosition = dragPoints[5].transform.localPosition;
                        dragPoints[5].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[5].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else if(dragPoints[4].GetComponent<HeapDragPointValues>().value == 0)
                    {
                        this.gameObject.transform.localPosition = dragPoints[5].transform.localPosition;
                        dragPoints[5].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[5].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else if(value == values[1])
                    {
                        this.gameObject.transform.localPosition = dragPoints[5].transform.localPosition;
                        dragPoints[5].GetComponent<HeapDragPointValues>().value = value;
                        dragPoints[5].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else if(dragPoints[4].GetComponent<HeapDragPointValues>().value != values[1])
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                }
                else if(dragPoints[1].GetComponent<HeapDragPointValues>().value == values[2])
                {
                    if(value > dragPoints[1].GetComponent<HeapDragPointValues>().value)
                    {
                        this.gameObject.transform.localPosition = dragPoints[5].transform.localPosition;
                        dragPoints[5].SetActive(false);
                        GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                        GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                        Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                        Destroy(this.gameObject.GetComponent<Color_Swap>());
                    }
                    else
                    {
                        failPanelNoOtherOptions.SetActive(true);
                        this.gameObject.transform.localPosition = resetSpritePosition;
                        GameObject.Find("Audio Wrong").GetComponent<AudioSource>().Play();
                    }
                }
            }
            //Checks if the dragged node is bigger than root node, if true, allow snap to dragpoint. if false, error message, reset node to starting position.
            else if(value > dragPoints[1].GetComponent<HeapDragPointValues>().value)
            {
                this.gameObject.transform.localPosition = dragPoints[5].transform.localPosition;
                dragPoints[5].GetComponent<HeapDragPointValues>().value = value;
                dragPoints[5].SetActive(false);
                GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue = GameObject.Find("Node 1").GetComponent<MinHeapRNGScript>().winValue + 1;
                GameObject.Find("Audio Correct").GetComponent<AudioSource>().Play();
                Destroy(this.gameObject.GetComponent<CreateMinHeapScript>());
                Destroy(this.gameObject.GetComponent<Color_Swap>());
            }
            else
            {
                failPanelCheckIfSmallest.SetActive(true);
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
