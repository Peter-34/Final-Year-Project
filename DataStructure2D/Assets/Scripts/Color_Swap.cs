using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Color_Swap : MonoBehaviour
{
    private Color originalColor;

    void Update() 
    {
        //Restricts the draggable area of the gameobjects
        //(Zotov 2018)
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.3f, 8.3f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f), transform.position.z);
    }
    private void OnMouseEnter() 
    {
        //(Unity Documentation 2018)
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            //Sets original color to white upon mouse enter, since that is the default color for all gameobjects. 
            originalColor = this.gameObject.GetComponent<SpriteRenderer>().color;
            //Changes the color of the current gameobject to cyan.
            this.gameObject.transform.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }

    private void OnMouseExit() 
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        }
    }

    private void OnMouseDown() 
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            if(Input.GetMouseButton(0))
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = originalColor;
            }
        }
    }

    private void OnMouseDrag() 
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        }
    }
}
