using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollBar : MonoBehaviour
{
    public Scrollbar scrollBar;

    void Start()
    {
        //scrollBar.OnBeginDrag += () =>
        //{
        //    Debug.Log("0");
  
        //};

        //scrollBar.OnBeginDrag(new PointereventData) += DebugOne();
    }

    public void DebugOne()
    {
        Debug.Log("01");
    }
    
}
