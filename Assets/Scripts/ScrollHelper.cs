using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollHelper : MonoBehaviour
{
    public float changeSum=0;
    Vector2 dragBeginPos=new Vector2();
    Vector2 dragEndPos=new Vector2();
    public float dragMul=0.1f;


    public Scrollbar scrollBar;
    void Start()
    {
        //scrollBar.OnBeginDrag()=>OnBeginDrag();
        //scrollBar.OnEndDrag()=>OnEndDrag();
    }
    public static void Scroll(GameObject parent, List<GameObject> buttons, int startIndex, int endIndex, int maxIndex)
    {
        // for(int i=0;i<startIndex;i++)
        // {
        //     //buttons[i].SetActive(false);
        // }
        // for(int i=endIndex+1;i<maxIndex;i++)
        // {
        //     //buttons[i].SetActive(false);
        // }
        for (int i = startIndex; i < endIndex + 1; i++)
        {
            GameObject tmpBtn = Instantiate(buttons[i]);
            tmpBtn.transform.SetParent(parent.transform);
        }




    }


    public static void ScrollDynamicDown(List<GameObject> buttons, List<int> leftNum, List<int> rightNum, int AddAmount)
    {
        //for(int i=0;i<3;i++)
        //{
        //    buttons.Remove(buttons[i]);
        //}
        //for (int i = 0; i < 3; i++)
        //{
        //    buttons.Add(prefab);
        //}

        for (int i = 0; i < 9; i++)
        {
            buttons[i].transform.GetChild(1).GetComponent<Text>().text = leftNum[i + AddAmount].ToString();
            buttons[i].transform.GetChild(2).GetComponent<Text>().text = rightNum[i + AddAmount].ToString();
        }





    }

    public static void ScrollDynamicMove(List<GameObject> buttons, GameObject parent, GameObject otherParent, List<int> leftNum, List<int> rightNum, int AddAmount)
    {
        //for (int i = buttons.Count - 3, j = 0; i < buttons.Count; i++)
        //{
        //    
        //    buttons[i].transform.SetAsFirstSibling();
        //    j++;
        //}
        for (int i = 0, j = 0; i < 3; i++)
        {
            buttons[i].transform.SetAsLastSibling();
            buttons[i].transform.GetChild(1).GetComponent<Text>().text = leftNum[i + AddAmount].ToString();
            buttons[i].transform.GetChild(2).GetComponent<Text>().text = rightNum[i + AddAmount].ToString();
            j++;
        }

        //buttons[12].transform.SetSiblingIndex(0);
        //buttons[13].transform.SetSiblingIndex(1);
        //buttons[14].transform.SetSiblingIndex(2);
    }


    public void OnValueChangeSum()
    {
        
    }

    public void OnBeginDrag()
    {
        dragBeginPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }


    public void OnEndDrag()
    {
        dragEndPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        changeSum += (dragEndPos.y - dragBeginPos.y) * dragMul;
    }



}