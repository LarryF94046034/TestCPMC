using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IDragHandler
{
    void Start()
    {
        
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //do something...
        Debug.Log("PD");
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        //do something...
        Debug.Log("PU");
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        //do something...
        Debug.Log("DRAG");
    }


}
