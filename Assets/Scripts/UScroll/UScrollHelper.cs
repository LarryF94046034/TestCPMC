using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UScrollHelper : MonoBehaviour
{
    public TestUScroll testUScroll;
    public void InitialData(int allowBlockXNum, int allowBlockYNum,int btnCount, List<int> dataList)
    {
        if(btnCount>allowBlockXNum*allowBlockYNum)
        {
            Debug.Log("BTN總數大於總行*總列");
        }
        for (int i = 0; i < btnCount; i++)
        {
            dataList.Add(i);
        }
    }
    public void AddButton(GameObject btnPrefab, Transform parentTran, int allowBlockXNum, int allowBlockYNum, List<GameObject> btnList)
    {
        int index = 0;
        for (int i = 0; i < allowBlockXNum; i++)
        {
            for (int j = 0; j < allowBlockYNum; j++)
            {
                GameObject newBtn = Instantiate(btnPrefab);  //生成
                newBtn.transform.SetParent(parentTran);    //SET父

                newBtn.transform.GetChild(1).GetComponent<Text>().text = index.ToString();  //變數字
                newBtn.gameObject.name = index.ToString();
                index++;

                btnList.Add(newBtn);
            }
        }
    }

    public void SetBackgroundAdaptive(RectTransform backgroundTran, int allowBlockXNum, int allowBlockYNum, float xBlockSpacing, float yBlockSpacing, float xBtwnBlockSpacing, float yBtwnBlockSpacing)
    {
        backgroundTran.sizeDelta = new Vector2
        (allowBlockXNum * xBlockSpacing + (allowBlockXNum + 1) * xBtwnBlockSpacing,  //Width
        allowBlockYNum * yBlockSpacing + (allowBlockYNum + 1) * yBtwnBlockSpacing);  //Height)
        Debug.Log((allowBlockXNum * xBlockSpacing)/* + (allowBlockXNum + 1) * xBtwnBlockSpacing*/);
        Debug.Log((allowBlockYNum * yBlockSpacing)/* + (allowBlockYNum + 1) * yBtwnBlockSpacing*/);

        //backgroundTran.sizeDelta = new Vector2
        //(500,  //Width
        //400);  //Height)

    }
    public void SetVerticalBarAdaptive(RectTransform verticalBar, float barXLength, int allowBlockYNum, float yBlockSpacing, float yBtwnBlockSpacing)
    {
        verticalBar.sizeDelta = new Vector2
        (barXLength,  //Width
        allowBlockYNum * yBlockSpacing + (allowBlockYNum + 1) * yBtwnBlockSpacing);  //Height)
    }

    public void SetVerticalBarPosition(RectTransform verticalBar, float layoutXLength, float barXLength)
    {
        verticalBar.anchoredPosition = new Vector2(layoutXLength / 2 + barXLength / 2, verticalBar.anchoredPosition.y);
    }


    #region 計算滑動量
    public void SumScrollAmount(ref float scrollAmount, float addValue, ref float positiveBuffer, ref float negativeBuffer)  //累積變量
    {
        scrollAmount += addValue;
        float posAddValue = Mathf.Abs(addValue);
        float negAddValue = Mathf.Abs(addValue);
        if (addValue < 0)
        {
            negAddValue = 0;
            positiveBuffer += posAddValue;
        }
        else
        {
            posAddValue = 0;
            negativeBuffer += negAddValue;
        }
    }

    private float scrollBarValueBuffer = 0f;
    private bool sumOrNot = true;
    public float ScrollBarValueBuffer
    {
        get
        {
            return scrollBarValueBuffer;
        }
        set
        {

            if (value < -1.1f || value > 1.1f)
            {
                sumOrNot = false;
            }
            if (value != scrollBarValueBuffer && sumOrNot == true)        //2.SCOLLBARBUFFER SET內偵測到變動 累積變動量 SETVALUE
            {
                SumScrollAmount(ref testUScroll.scrollAmount, value - scrollBarValueBuffer, ref testUScroll.positiveBuffer, ref testUScroll.negativeBuffer);
            }
            scrollBarValueBuffer = value;
            Debug.Log(value);
        }
    }
    public Scrollbar verticalBar;   //掛在ONSCROLL EVENT的SCROLLVALUEUPDATE 無法掛SCROLLBAR 所以在這裡掛
    public void ScrollValueUpdate()     //偵測BAR變化    1.ONSCROLL造成拉條值變動，SCROLLBARBUFFER同時變動
    {
        ScrollBarValueBuffer = verticalBar.value;
    }

    public void OverValueUpdateData(Scrollbar scrollbar, ref float scrollAmount, float overAmount, ref int nowRowDir, List<int> dataList, List<GameObject> btnList, int allowBlockXNum, int allowBlockYNum, int outsideBlockYNum, ref int nowIndex)
    {
        if (scrollAmount > 0.3f)
        {
            //scrollRect.verticalScrollbar.value = 0.5f;
            scrollbar.value = 0.5f;

            scrollAmount = 0f;
            nowRowDir += 1;   //方向向上  行數項下滾

            int floorNowIndex = nowIndex + allowBlockXNum;
            if (floorNowIndex <= allowBlockXNum * outsideBlockYNum)
            {
                nowIndex += allowBlockXNum;
            }
            //UpdateData(dataList,btnList, nowRowDir, allowBlockXNum);  //直接改數字
            //UpdateDataFromServer(dataList, btnList, nowIndex, allowBlockXNum, allowBlockYNum, outsideBlockYNum, nowRowDir);
            nowRowDir = 0;
            Debug.Log("Over");
        }
    }
    public void BelowValueUpdateData(Scrollbar scrollbar, ref float scrollAmount, float overAmount, ref int nowRowDir, List<int> dataList, List<GameObject> btnList, int allowBlockXNum, int allowBlockYNum, int outsideBlockYNum, ref int nowIndex)
    {
        if (scrollAmount < -0.3f)
        {
            //scrollRect.verticalScrollbar.value = 0.5f;
            scrollbar.value = 0.5f;

            scrollAmount = 0f;
            nowRowDir -= 1;

            int ceilingNowIndex = nowIndex - allowBlockXNum;
            if (ceilingNowIndex >= -allowBlockXNum * outsideBlockYNum)
            {
                nowIndex -= allowBlockXNum;
            }

            //UpdateData(dataList,btnList, nowRowDir, allowBlockXNum);  //直接改數字
            //UpdateDataFromServer(dataList, btnList, nowIndex, allowBlockXNum, allowBlockYNum, outsideBlockYNum, nowRowDir);
            nowRowDir = 0;
        }
    }
    #endregion

    #region UpdateValue
    public void AddIndexUpdateData(ref float negativeBuffer,float negativeGap,ref int nowIndex,int allowBlockXNum,int allowBlockYNum,List<int> dataList, List<GameObject> btnList)
    {
        if(negativeBuffer>negativeGap)
        {
            negativeBuffer = 0;

            int ceilingIndex = nowIndex + allowBlockXNum;
            if(ceilingIndex <= (dataList.Count-1)-(allowBlockXNum-1)-((allowBlockYNum-1)*allowBlockXNum))
            {
                nowIndex += allowBlockXNum;
                UpdateData(btnList, dataList, nowIndex, allowBlockXNum, allowBlockYNum);
            }
            //nowIndex += allowBlockXNum;
        }
    }
    public void MinusIndexUpdateData(ref float positiveBuffer, float positiveGap, ref int nowIndex, int allowBlockXNum, int allowBlockYNum, List<int> dataList, List<GameObject> btnList)
    {
        if (positiveBuffer > positiveGap)
        {
            positiveBuffer = 0;

            int floorIndex = nowIndex - allowBlockXNum;
            if (floorIndex >= 0)
            {
                nowIndex -= allowBlockXNum;
                UpdateData(btnList, dataList, nowIndex, allowBlockXNum, allowBlockYNum);
            }
            //nowIndex += allowBlockXNum;
        }
    }

    public void UpdateData(List<GameObject> btnList,List<int> dataList, int nowIndex,int allowBlockXNum, int allowBlockYNum)
    {
        int nowIndexIndex = nowIndex;
        for(int i=0;i<allowBlockXNum*allowBlockYNum;i++)
        {
            btnList[i].transform.GetChild(1).GetComponent<Text>().text = dataList[nowIndexIndex].ToString();
            nowIndexIndex++;
        }
    }
    public void UpdateDataByBar(List<GameObject> btnList, List<int> dataList, int nowIndex, int allowBlockXNum, int allowBlockYNum, float verticalBarValue)
    {
        float oneMinus = verticalBarValue* (dataList.Count - btnList.Count);
        float floor = Mathf.Floor(oneMinus);
        int index = (int)Mathf.Clamp(floor, 0, (dataList.Count -btnList.Count));

        Debug.Log(new { oneMinus, floor, index });

        
        for (int i = 0; i < btnList.Count; i++)
        {
            btnList[i].transform.GetChild(1).GetComponent<Text>().text = dataList[index].ToString();
            index++;
        }
    }


    

    #endregion

}
