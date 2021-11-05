using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollBarEventHandler : MonoBehaviour
{
    public ScrollHelper scrollHelper;
    public TestScroll testScroll;

    void Start()
    {
        
    }

    public void SumScollWhenOnDrag(PointerEventData eventData)
    {
        //scrollHelper.SumScrollAmount(ref testScroll.scrollAmount,eventData);
        Debug.Log("OnMove");
    }
}
