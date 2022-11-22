using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObjects : MonoBehaviour
{
    /// <summary>
    /// Перетаскиваемый объект.
    /// </summary>
    public GameObject DragObj;

    Vector3 firstpoint;
    Vector3 secondpoint;   
    bool ismoved;

    void OnMouseDown()
    {
        ismoved = true;
        firstpoint = Camera.main.ScreenToViewportPoint(Input.mousePosition) - DragObj.transform.localPosition;
    }

    void OnMouseUp()
    {
        ismoved = false;
    }

    private void Update()
    {             
        if (ismoved)
        {
            secondpoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            var delta = secondpoint - firstpoint;                
            DragObj.transform.localPosition = delta;
        }        
    }
  
}
