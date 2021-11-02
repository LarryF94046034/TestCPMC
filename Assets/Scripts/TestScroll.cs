using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScroll : MonoBehaviour
{
    public List<GameObject> buttons;
    public GameObject parent;
    public GameObject otherParent;


    public ScrollRect scrollView;
    

    public List<int> leftNum = new List<int>();
    public List<int> rightNum = new List<int>();
    
    public bool firstTime = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(scrollView.verticalScrollbar.value<0.5f&&firstTime==false)
        //{
        //    ScrollHelper.ScrollDynamicDown(buttons, leftNum, rightNum, 3);
        //    firstTime = true;
        //}

        if (scrollView.verticalScrollbar.value < 0.5f && firstTime == false)
        {
            ScrollHelper.ScrollDynamicMove(buttons,parent,otherParent, leftNum, rightNum,15);
            firstTime = true;
        }
    }
}
