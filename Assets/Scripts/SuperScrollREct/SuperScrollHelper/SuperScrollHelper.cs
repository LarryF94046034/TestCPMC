
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using CHENKAIHSUN;

public class SuperScrollHelper : MonoBehaviour
{
    public RectTransformTool rectTranTool;
    public void GetComponent(ScrollRect scrollRect,RectTransform contentTran)
    {

    }
    public void SetContentWidth(RectTransform scrollRectTran,RectTransform contentRectTran,float itemNum,float maxItemNum,float queue,float itemWidth,float itemHeight)  //左對齊
    {
        if(maxItemNum<itemNum)
        {
            Debug.Log("背包顯示格>背包總數，背包未滿");
            maxItemNum = itemNum;
        }
        //transform.GetComponent<RectTransform>().sizeDelta = new Vector2(itemWidth * maxItemNum / queue, (_obj.GetComponent<RectTransform>().sizeDelta.y + 20) * queue);  //設SCROLL RT SIZE
        //transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Ceil(maxItemNum / queue) * itemWidth, itemHeight * queue);  //設SCROLL RT SIZE
        float sizeX = Mathf.Ceil(maxItemNum / queue) * itemWidth;
        float sizeY = itemHeight * queue;
        rectTranTool.SetSize(scrollRectTran,sizeX,sizeY);     //MAXITEMNUM設定最大SCROLL VIEW

        //superRect.sizeDelta = new Vector2(itemNum * itemWidth / queue, 0);
        //superRect.sizeDelta = new Vector2((Mathf.Ceil(itemNum / queue) * itemWidth), 0);  //設 CONTENT SIZE
        float sizeX1 = (Mathf.Ceil(itemNum / queue) * itemWidth);
        float sizeY1 = 0;
        rectTranTool.SetSize(contentRectTran, sizeX1, sizeY1); //ITEMNUM設定可視CONTENT

        //superRect.anchorMin = new Vector2(0, 0);   //設CONTENT ANCHOR
        //superRect.anchorMax = new Vector2(0, 1);
        rectTranTool.SetAnchor(contentRectTran, 0, 0, 0, 1);
    }

    public void InsCountitemWidth(GameObject instanPrefab,RectTransform contentRectTran,List<GameObject> itemList, float itemNum, float maxItemNum, float queue, float itemWidth, float itemHeight,ref int lastIndex)
    {
        int needItemNum = Mathf.Clamp((int)maxItemNum, 0, (int)itemNum);

        int forIndex = 0;
        //for (int j = 0; j < needItemNum / queue + 1; j++)
        for (int j = 0; j < (Mathf.Ceil(itemNum / queue)); j++)
        {
            for (int i = 0; i < queue; i++)
            {
                if(forIndex>itemNum-1)
                {
                    break;
                }
                //生成
                GameObject obj = Instantiate(instanPrefab,contentRectTran);
                //取名和赋值
                obj.name = (j * queue + i).ToString();
                obj.transform.Find("Text").GetComponent<Text>().text = obj.name;
                //设定锚点以及锚点位置
                RectTransform _rect = obj.transform.GetComponent<RectTransform>();
                _rect.pivot = new Vector2(0, 1);
                _rect.anchorMin = new Vector2(0, 1);
                _rect.anchorMax = new Vector2(0, 1);
                _rect.anchoredPosition = new Vector2(j * itemWidth, -itemHeight * i);
                //将游戏对象按顺序加到显示list当中
                itemList.Add(obj);

                forIndex++;
            }
        }
        //设置最后的索引
        //lastIndex = (int)needItemNum - 1 + (int)queue;
        lastIndex = (int)needItemNum - 1;
    }

    public void LockScrollViewXMin(RectTransform contentTran,float maxX)
    {
        rectTranTool.XPosCeilingLock(contentTran,maxX);
    }
    public void LockScrollViewXMax(RectTransform contentTran, float minX)
    {
        rectTranTool.XPosFloorLock(contentTran, minX);
    }

    public void OnScrollMoveWidth(RectTransform scrollRectTran, RectTransform contentRectTran,List<GameObject> itemList, float itemNum, float maxItemNum, float queue, float itemWidth, float itemHeight,ref int firstIndex, ref int lastIndex,ref int nowIndex,ref float xPositivePosBuffer,ref float xNegativePosBuffer)
    {
        Debug.Log("ANCHORPOS" + Mathf.Abs(contentRectTran.anchoredPosition.x));
        Debug.Log("ITEMPOS:" + (itemWidth * (firstIndex / queue)));
        Debug.Log("LASTINDEX" + lastIndex);
        Debug.Log("FIRSTINDEX" + firstIndex);
        //Debug.Log(lastIndex);
        Debug.Log("TRUE" + (Mathf.Abs(contentRectTran.anchoredPosition.x) > itemWidth * (firstIndex / queue) && lastIndex >= itemNum - 1));
        //从左往右
        
        while (Mathf.Abs(contentRectTran.anchoredPosition.x) > itemWidth * (firstIndex / queue) && nowIndex >= firstIndex)
        {
            Debug.Log("In");
            for (int i = 0; i < queue; i++)
            {
                GameObject _first = itemList[0];  //取得頭部 每次拔除頭部=拔1 拔2 拔3                
                RectTransform _firstRect = _first.GetComponent<RectTransform>();
                if(i==0)
                {
                    xPositivePosBuffer = (float)((lastIndex + 1) / queue) * itemWidth;
                }
                itemList.RemoveAt(0);
                itemList.Add(_first);
                _firstRect.anchoredPosition = new Vector2(xPositivePosBuffer,_firstRect.anchoredPosition.y);

                //firstIndex++;
                //lastIndex++;
                firstIndex++;
                lastIndex++;
                nowIndex++;

                //修改显示
                _first.name = lastIndex.ToString();
                _first.transform.Find("Text").GetComponent<Text>().text = _first.name;

            }
        }
        Debug.Log("ANCHORPOS" + Mathf.Abs(contentRectTran.anchoredPosition.x));
        Debug.Log("ITEMPOS" + (itemWidth * firstIndex / queue));
        Debug.Log(firstIndex);
        Debug.Log("TRUE" + (Mathf.Abs(contentRectTran.anchoredPosition.x) < itemWidth * firstIndex / queue && firstIndex >= 0));
        //从右往左
        while (Mathf.Abs(contentRectTran.anchoredPosition.x) < itemWidth * firstIndex / queue && firstIndex <=nowIndex)
        {
            for (int i = 0; i < queue; i++)
            {
                GameObject _last = itemList[itemList.Count - 1];
                RectTransform _lastRect = _last.GetComponent<RectTransform>();
                if (i == 0)
                {
                    xNegativePosBuffer = ((firstIndex - 1) / queue) * itemWidth;
                }
                itemList.RemoveAt(itemList.Count - 1);
                itemList.Insert(0, _last);
                _lastRect.anchoredPosition = new Vector2(xNegativePosBuffer, _lastRect.anchoredPosition.y);

                firstIndex--;
                lastIndex--;
                nowIndex--;

                //修改显示
                _last.name = firstIndex.ToString();
                _last.transform.Find("Text").GetComponent<Text>().text = _last.name;
            }

        }

    }

}
