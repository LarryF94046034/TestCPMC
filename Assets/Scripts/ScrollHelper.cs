using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollHelper : MonoBehaviour
{
    public static void Scroll(GameObject parent,List<GameObject> buttons,int startIndex,int endIndex,int maxIndex)
    {
        // for(int i=0;i<startIndex;i++)
        // {
        //     //buttons[i].SetActive(false);
        // }
        // for(int i=endIndex+1;i<maxIndex;i++)
        // {
        //     //buttons[i].SetActive(false);
        // }
        for(int i=startIndex;i<endIndex+1;i++)
        {
            GameObject tmpBtn=Instantiate(buttons[i]);
            tmpBtn.transform.SetParent(parent.transform);
        }


        

    }
}
