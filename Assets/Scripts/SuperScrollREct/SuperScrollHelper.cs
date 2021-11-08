using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperScrollHelper : MonoBehaviour
{
    public void SetContentHeight(RectTransform rectTran,RectTransform contentTran,int maxXNum,int maxYNum,float blockWidth,float blockHeight,float xSpacing,float ySpacing)
    {
        contentTran.sizeDelta = new Vector2(maxXNum * blockWidth + (maxXNum + 1) * xSpacing,maxYNum * blockHeight+(maxYNum+1)*ySpacing);
        //superRect.sizeDelta = new Vector2(itemNum * itemWidth / queue, 0);
        rectTran.anchorMin = new Vector2(0, 0);
        rectTran.anchorMax = new Vector2(1, 0);
    }
}
