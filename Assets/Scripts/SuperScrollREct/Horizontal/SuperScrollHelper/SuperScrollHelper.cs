
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using CHENKAIHSUN;

public class SuperScrollHelper : MonoBehaviour
{
    public void InitialData(List<int> dataList,float maxItemNum)
    {
        for(int i=0;i<maxItemNum;i++)
        {
            if((int)Random.Range(0, (int)maxItemNum)<maxItemNum/2)
            {
                dataList.Add(-1);
            }
            else
            {
                dataList.Add((int)Random.Range(1, (int)maxItemNum));
            }
            
        }
    }
    //public void SetContentWidth(RectTransform scrollRectTran,RectTransform contentRectTran,float itemNum,float maxItemNum,float queue,float itemWidth,float itemHeight)  //左對齊
    //{
    //    if(maxItemNum<itemNum)
    //    {
    //        Debug.Log("背包顯示格>背包總數，背包未滿");
    //        maxItemNum = itemNum;
    //    }
    //    //transform.GetComponent<RectTransform>().sizeDelta = new Vector2(itemWidth * maxItemNum / queue, (_obj.GetComponent<RectTransform>().sizeDelta.y + 20) * queue);  //設SCROLL RT SIZE
    //    //transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Ceil(maxItemNum / queue) * itemWidth, itemHeight * queue);  //設SCROLL RT SIZE
    //    float sizeX = Mathf.Ceil(maxItemNum / queue) * itemWidth;
    //    float sizeY = itemHeight * queue;
    //    RectTransformTool.Instance.SetSize(scrollRectTran,sizeX,sizeY);     //MAXITEMNUM設定最大SCROLL VIEW

    //    //superRect.sizeDelta = new Vector2(itemNum * itemWidth / queue, 0);
    //    //superRect.sizeDelta = new Vector2((Mathf.Ceil(itemNum / queue) * itemWidth), 0);  //設 CONTENT SIZE
    //    float sizeX1 = (Mathf.Ceil(itemNum / queue) * itemWidth);
    //    float sizeY1 = 0;
    //    RectTransformTool.Instance.SetSize(contentRectTran, sizeX1, sizeY1); //ITEMNUM設定可視CONTENT

    //    //superRect.anchorMin = new Vector2(0, 0);   //設CONTENT ANCHOR
    //    //superRect.anchorMax = new Vector2(0, 1);
    //    RectTransformTool.Instance.SetAnchor(contentRectTran, 0, 0, 0, 1);
    //}

    //public void InsCountitemWidth(GameObject instanPrefab,RectTransform contentRectTran,List<GameObject> itemList,List<int> dataList, float itemNum, float maxItemNum, float queue, float itemWidth, float itemHeight,ref int lastIndex)
    //{
    //    int needItemNum = Mathf.Clamp((int)maxItemNum, 0, (int)itemNum);

    //    int forIndex = 0;
    //    //for (int j = 0; j < needItemNum / queue + 1; j++)
    //    for (int j = 0; j < (Mathf.Ceil(itemNum / queue)); j++)
    //    {
    //        for (int i = 0; i < queue; i++)
    //        {
    //            if(forIndex>itemNum-1)
    //            {
    //                break;
    //            }
    //            //生成
    //            GameObject obj = Instantiate(instanPrefab,contentRectTran);
    //            //取名和赋值
    //            obj.name = (j * queue + i).ToString();
    //            //obj.transform.Find("Text").GetComponent<Text>().text = obj.name;
    //            //设定锚点以及锚点位置
    //            RectTransform _rect = obj.transform.GetComponent<RectTransform>();
    //            _rect.pivot = new Vector2(0, 1);
    //            _rect.anchorMin = new Vector2(0, 1);
    //            _rect.anchorMax = new Vector2(0, 1);
    //            _rect.anchoredPosition = new Vector2(j * itemWidth, -itemHeight * i);
    //            //将游戏对象按顺序加到显示list当中
    //            itemList.Add(obj);

    //            if(dataList[forIndex]!=-1)
    //            {
    //                obj.transform.Find("Text").GetComponent<Text>().text = dataList[forIndex].ToString();    //導入資料
    //            }


    //            forIndex++;
    //        }
    //    }
    //    //设置最后的索引
    //    //lastIndex = (int)needItemNum - 1 + (int)queue;
    //    lastIndex = (int)needItemNum - 1;
    //}

    //public void LockScrollViewXMin(RectTransform contentTran,float maxX)
    //{
    //    RectTransformTool.Instance.XPosCeilingLock(contentTran,maxX);
    //}
    //public void LockScrollViewXMax(RectTransform contentTran, float minX)
    //{
    //    RectTransformTool.Instance.XPosFloorLock(contentTran, minX);
    //}

    //public void OnScrollMoveWidth(RectTransform scrollRectTran, RectTransform contentRectTran,List<GameObject> itemList,List<int> dataList, float itemNum, float maxItemNum, float queue, float itemWidth, float itemHeight,ref int firstIndex, ref int lastIndex,ref int nowIndex,ref float xPositivePosBuffer,ref float xNegativePosBuffer)
    //{
    //    Debug.Log("ANCHORPOS" + Mathf.Abs(contentRectTran.anchoredPosition.x));
    //    Debug.Log("ITEMPOS:" + (itemWidth * (firstIndex / queue)));
    //    Debug.Log("LASTINDEX" + lastIndex);
    //    Debug.Log("FIRSTINDEX" + firstIndex);
    //    //Debug.Log(lastIndex);
    //    Debug.Log("TRUE" + (Mathf.Abs(contentRectTran.anchoredPosition.x) > itemWidth * (firstIndex / queue) && lastIndex >= itemNum - 1));
    //    //从左往右

    //    bool doRight = false;

    //    while (Mathf.Abs(contentRectTran.anchoredPosition.x) > itemWidth * (firstIndex / queue) && nowIndex >= firstIndex && (nowIndex + (int)itemNum)-5 < (maxItemNum))
    //    {
    //        doRight = true;
    //        Debug.Log("SCROLLRIHGT");
    //        for (int i = 0; i < queue; i++)
    //        {
    //            int _firstIndex=0;
    //            GameObject _first = itemList[0];  //取得頭部 每次拔除頭部=拔1 拔2 拔3                
    //            RectTransform _firstRect = _first.GetComponent<RectTransform>();
    //            if (i == 0)
    //            {
    //                xPositivePosBuffer = (float)((lastIndex + 1) / queue) * itemWidth;
    //                _firstIndex = nowIndex;
    //            }
    //            itemList.RemoveAt(0);
    //            itemList.Add(_first);
    //            _firstRect.anchoredPosition = new Vector2(xPositivePosBuffer, _firstRect.anchoredPosition.y);

    //            //firstIndex++;
    //            //lastIndex++;
    //            firstIndex++;
    //            lastIndex++;
    //            nowIndex++;

    //            //修改显示
    //            _first.name = lastIndex.ToString();
    //            //_first.transform.Find("Text").GetComponent<Text>().text = _first.name;
    //            //if (dataList[nowIndex-(int)queue] != -1)
    //            //{
    //            //    _first.transform.Find("Text").GetComponent<Text>().text = dataList[nowIndex-(int)queue].ToString();
    //            //}
    //            //else 
    //            //{
    //            //    _first.transform.Find("Text").GetComponent<Text>().text = " ";
    //            //}
    //            //if ((lastIndex - ((int)itemNum-1))>=0&&dataList[lastIndex - ((int)itemNum - 1)] != -1)
    //            //{
    //            //    _first.transform.Find("Text").GetComponent<Text>().text = dataList[lastIndex - ((int)itemNum - 1)].ToString();
    //            //}
    //            //else if((lastIndex - ((int)itemNum - 1)) >= 0)
    //            //{
    //            //    _first.transform.Find("Text").GetComponent<Text>().text = " ";
    //            //}

    //            Debug.Log(_first);
    //            if ((nowIndex) < dataList.Count && dataList[nowIndex] != -1)
    //            {
    //                _first.transform.Find("Text").GetComponent<Text>().text = dataList[nowIndex].ToString();
    //            }
    //            else if ((nowIndex) >= dataList.Count)
    //            {
    //                _first.transform.Find("Text").GetComponent<Text>().text = " ";
    //            }
    //            else
    //            {
    //                _first.transform.Find("Text").GetComponent<Text>().text = " ";
    //            }

    //        }
    //    }

    //    //Debug.Log("ANCHORPOS" + Mathf.Abs(contentRectTran.anchoredPosition.x));
    //    //Debug.Log("ITEMPOS" + (itemWidth * firstIndex / queue));
    //    //Debug.Log(firstIndex);
    //    //Debug.Log("TRUE" + (Mathf.Abs(contentRectTran.anchoredPosition.x) < itemWidth * firstIndex / queue && firstIndex >= 0));

    //    Debug.Log("nowIndex"+nowIndex);
    //    Debug.Log("lastIndex" + lastIndex);
    //    //从右往左
    //    while (Mathf.Abs(contentRectTran.anchoredPosition.x) < itemWidth * firstIndex / queue && firstIndex <=nowIndex)
    //    {
    //        doRight = false;
    //        Debug.Log("SCROLLLEFT");  
    //        for (int i = 0; i < queue; i++)
    //        {
    //            GameObject _last = itemList[itemList.Count - 1];
    //            RectTransform _lastRect = _last.GetComponent<RectTransform>();
    //            if (i == 0)
    //            {
    //                xNegativePosBuffer = ((firstIndex - 1) / queue) * itemWidth;
    //            }
    //            itemList.RemoveAt(itemList.Count - 1);
    //            itemList.Insert(0, _last);
    //            _lastRect.anchoredPosition = new Vector2(xNegativePosBuffer, _lastRect.anchoredPosition.y);



    //            firstIndex--;
    //            lastIndex--;
    //            nowIndex--;

    //            //修改显示
    //            _last.name = firstIndex.ToString();
    //            //_last.transform.Find("Text").GetComponent<Text>().text = _last.name;
    //            if ((nowIndex + (int)itemNum) < dataList.Count && dataList[nowIndex + (int)itemNum] != -1)
    //            {
    //                _last.transform.Find("Text").GetComponent<Text>().text = dataList[nowIndex + (int)itemNum].ToString();
    //            }
    //            else if ((nowIndex + (int)itemNum) >= dataList.Count)
    //            {
    //                _last.transform.Find("Text").GetComponent<Text>().text = " ";
    //            }
    //            else
    //            {
    //                _last.transform.Find("Text").GetComponent<Text>().text = " ";
    //            }




    //        }

    //    }

    //}



    
    
    public void SetContentWidth(RectTransform scrollRectTran, RectTransform contentRectTran, float itemNum, float maxItemNum, float queue, float itemWidth, float itemHeight)  //左對齊
    {
        if (maxItemNum < itemNum)
        {
            Debug.Log("背包顯示格>背包總數，背包未滿");
            maxItemNum = itemNum;
        }
        //transform.GetComponent<RectTransform>().sizeDelta = new Vector2(itemWidth * maxItemNum / queue, (_obj.GetComponent<RectTransform>().sizeDelta.y + 20) * queue);  //設SCROLL RT SIZE
        //transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Ceil(maxItemNum / queue) * itemWidth, itemHeight * queue);  //設SCROLL RT SIZE
        float sizeX = Mathf.Ceil(maxItemNum / queue) * itemWidth;
        float sizeY = itemHeight * queue;
        RectTransformTool.Instance.SetSize(scrollRectTran, sizeX, sizeY);     //MAXITEMNUM設定最大SCROLL VIEW

        //superRect.sizeDelta = new Vector2(itemNum * itemWidth / queue, 0);
        //superRect.sizeDelta = new Vector2((Mathf.Ceil(itemNum / queue) * itemWidth), 0);  //設 CONTENT SIZE
        float sizeX1 = (Mathf.Ceil(itemNum / queue) * itemWidth);
        float sizeY1 = 0;
        RectTransformTool.Instance.SetSize(contentRectTran, sizeX1, sizeY1); //ITEMNUM設定可視CONTENT

        //superRect.anchorMin = new Vector2(0, 0);   //設CONTENT ANCHOR
        //superRect.anchorMax = new Vector2(0, 1);
        RectTransformTool.Instance.SetAnchor(contentRectTran, 0, 0, 0, 1);
    }

    public void InsCountitemWidth(GameObject instanPrefab, RectTransform contentRectTran, List<GameObject> itemList,List<int> dataList, float itemNum, float maxItemNum, float queue, float itemWidth, float itemHeight, ref int lastIndex)
    {
        int needItemNum = Mathf.Clamp((int)maxItemNum, 0, (int)itemNum);

        int forIndex = 0;
        //for (int j = 0; j < needItemNum / queue + 1; j++)
        for (int j = 0; j < (Mathf.Ceil(itemNum / queue)); j++)
        {
            for (int i = 0; i < queue; i++)
            {
                if (forIndex > itemNum - 1)
                {
                    break;
                }
                //生成
                GameObject obj = Instantiate(instanPrefab, contentRectTran);
                //取名和赋值
                obj.name = (j * queue + i).ToString();
                obj.transform.Find("Text").GetComponent<Text>().text = obj.name;
                //obj.transform.Find("Text").GetComponent<Text>().text = dataList[(int)(j * queue + i)].ToString();
                //if ((j * queue + i) > maxItemNum)
                //{
                //    obj.transform.Find("Text").GetComponent<Text>().text = " ";
                //}
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

    public void LockScrollViewXMin(RectTransform contentTran, float maxX)
    {
        RectTransformTool.Instance.XPosCeilingLock(contentTran, maxX);
    }
    public void LockScrollViewXMax(RectTransform contentTran, float minX)
    {
        RectTransformTool.Instance.XPosFloorLock(contentTran, minX);
    }

    public void OnScrollMoveWidth(RectTransform scrollRectTran, RectTransform contentRectTran, List<GameObject> itemList, List<int> dataList, float itemNum, float maxItemNum, float queue, float itemWidth, float itemHeight, ref int firstIndex, ref int lastIndex, ref int nowIndex, ref float xPositivePosBuffer, ref float xNegativePosBuffer)
    {
        Debug.Log("ANCHORPOS" + Mathf.Abs(contentRectTran.anchoredPosition.x));
        Debug.Log("ITEMPOS:" + (itemWidth * (firstIndex / queue)));
        Debug.Log("LASTINDEX" + lastIndex);
        Debug.Log("FIRSTINDEX" + firstIndex);
        //Debug.Log(lastIndex);
        Debug.Log("TRUE" + (Mathf.Abs(contentRectTran.anchoredPosition.x) > itemWidth * (firstIndex / queue) && lastIndex >= itemNum - 1));
        //从左往右

        while (Mathf.Abs(contentRectTran.anchoredPosition.x)-itemWidth*0.9f > itemWidth * (firstIndex / queue) && nowIndex >= firstIndex  && (nowIndex + (int)itemNum) < (maxItemNum))
        {
            Debug.Log("In");
            for (int i = 0; i < queue; i++)
            {
                GameObject _first = itemList[0];  //取得頭部 每次拔除頭部=拔1 拔2 拔3                
                RectTransform _firstRect = _first.GetComponent<RectTransform>();
                if (i == 0)
                {
                    xPositivePosBuffer = (float)((lastIndex + 1) / queue) * itemWidth;
                }
                itemList.RemoveAt(0);
                itemList.Add(_first);
                _firstRect.anchoredPosition = new Vector2(xPositivePosBuffer, _firstRect.anchoredPosition.y);

                //firstIndex++;
                //lastIndex++;
                firstIndex++;
                lastIndex++;
                nowIndex++;

                //修改显示
                _first.name = lastIndex.ToString();
                _first.transform.Find("Text").GetComponent<Text>().text = _first.name;
                //if(lastIndex >= maxItemNum)
                //{
                //    _first.transform.Find("Text").GetComponent<Text>().text = " ";
                //}
                //else
                //{
                //    _first.transform.Find("Text").GetComponent<Text>().text = dataList[lastIndex].ToString();
                //}

            }
        }
        Debug.Log("ANCHORPOS" + Mathf.Abs(contentRectTran.anchoredPosition.x));
        Debug.Log("ITEMPOS" + (itemWidth * firstIndex / queue));
        Debug.Log(firstIndex);
        Debug.Log("TRUE" + (Mathf.Abs(contentRectTran.anchoredPosition.x) < itemWidth * firstIndex / queue && firstIndex >= 0));
        //从右往左
        while (Mathf.Abs(contentRectTran.anchoredPosition.x) < itemWidth * firstIndex / queue && firstIndex <= nowIndex)
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
                //if (firstIndex >= maxItemNum)
                //{
                //    _last.transform.Find("Text").GetComponent<Text>().text = " ";
                //}
                //else
                //{
                //    _last.transform.Find("Text").GetComponent<Text>().text = dataList[firstIndex].ToString();
                //}

            }

        }

    }

}
