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

    public TestScroll testScroll;

    

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
    #region CountLogic
    public int RawCount(int btnCount,int allowBlockXNum)
    {
        return btnCount / allowBlockXNum;
    }
    public void SetNowIndex(ref int nowIndex,int value)
    {
        nowIndex = value;
    }
    #endregion

    public void OnEndDrag()
    {
        dragEndPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        changeSum += (dragEndPos.y - dragBeginPos.y) * dragMul;
    }
    #region InitialDataBuffer
    public void InitialData(int allowBlockXNum, int allowBlockYNum, List<int> dataList)
    {
        for(int i=0;i<allowBlockXNum*allowBlockYNum;i++)
        {
            dataList.Add(i);
        }
    }
    #endregion


    #region ScrollRect
    public void FillScrollRect(GameObject btnPrefab,Transform parentTran,int allowBlockXNum, int allowBlockYNum,List<GameObject> btnList)
    {
        int index=0;
        for(int i=0;i<allowBlockXNum;i++)
        {
            for(int j=0;j<allowBlockYNum;j++)
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
    public void SetScrollRectWH()
    {

    }
    //public void SetScrollRectHeight(RectTransform scrollRectTran,float yBtwnBlockSpacing,float yBlockSpacing,int allowBlockNum)
    //{
    //    scrollRectTran.rect.Set(
    //        scrollRectTran.rect.x,   //不變
    //        scrollRectTran.rect.y,   //不變
    //        scrollRectTran.rect.width,  //不變
    //        allowBlockNum * yBlockSpacing + (allowBlockNum + 1) * yBtwnBlockSpacing);  //Height
    //}
    //public void SetScrollRectWidth(RectTransform scrollRectTran, float xBtwnBlockSpacing, float xBlockSpacing, int allowBlockNum)
    //{
    //    scrollRectTran.rect.Set(
    //        scrollRectTran.rect.x,   //不變
    //        scrollRectTran.rect.y,   //不變
    //        allowBlockNum * xBlockSpacing + (allowBlockNum + 1) * xBtwnBlockSpacing,  //Width
    //        scrollRectTran.rect.height);  //不變
    //}
    public void SetScrollRectWH(RectTransform scrollRectTran, float xBtwnBlockSpacing, float xBlockSpacing, int allowBlockXNum, 
    float yBtwnBlockSpacing, float yBlockSpacing, int allowBlockYNum)
    {
        //scrollRectTran.rect.Set(
        //    scrollRectTran.rect.x,   //不變
        //    scrollRectTran.rect.y,   //不變
        //    allowBlockXNum * xBlockSpacing + (allowBlockXNum + 1) * xBtwnBlockSpacing,  //Width
        //    allowBlockYNum * yBlockSpacing + (allowBlockYNum + 1) * yBtwnBlockSpacing);  //Height

            scrollRectTran.sizeDelta=new Vector2
            (allowBlockXNum * xBlockSpacing + (allowBlockXNum + 1) * xBtwnBlockSpacing,  //Width
            allowBlockYNum * yBlockSpacing + (allowBlockYNum + 1) * yBtwnBlockSpacing);  //Height)
    }
    public void SetScrollRectHandleMidPoint(ScrollRect scrollRect,float verticalHandleValue)
    {
        scrollRect.verticalScrollbar.value = verticalHandleValue;
    }
    public void SetScrollRectHorizontalOne(ScrollRect scrollRect)   //CONTENT位置造成錯位，未知原因，可直接調整SCROLLBAR為1讓其自動計算
    {
        scrollRect.horizontalScrollbar.value = 1.0f;
    }
    public void CloseHorizontalHandle(Image handleImage,Image scrollBarHorizontalImage)
    {
        handleImage.enabled = false;
        scrollBarHorizontalImage.enabled = false;
    }
    public void SetContentHeight(RectTransform contentTran,RectTransform scrollRect,int allowBlockYNum,int outsideYNum, float yBtwnBlockSpacing, float yBlockSpacing)
    {
        contentTran.sizeDelta = new Vector2(scrollRect.rect.width, scrollRect.rect.height * 2);
        
        //contentTran.sizeDelta = new Vector2(scrollRect.rect.width, (allowBlockYNum+2*outsideYNum)* yBlockSpacing+((allowBlockYNum + 2 * outsideYNum)+1)* yBtwnBlockSpacing);
    }
    public void SetContentPosition(RectTransform contentTran,float xBlockSpacing,int allowBlockXNum,List<GameObject> btnList)   //執行後CONTENT位置偏右，重新設定位置
    {


        //float xPos= (-contentTran.rect.width / 2)+ (((allowBlockXNum - 1) * xBlockSpacing));   //註解的
        //contentTran.position = new Vector2(xPos, contentTran.rect.y);
        //Debug.Log(-contentTran.rect.width / 2);
        //Debug.Log(((allowBlockXNum - 1) * xBlockSpacing));

        //RectTransform firstBtnRT = btnList[0].GetComponent<RectTransform>();        //之前的
        //RectTransform xRangeBtnRT = btnList[allowBlockXNum].GetComponent<RectTransform>();
        //float xPos = (firstBtnRT.position.x + xRangeBtnRT.position.x) / 2;
        //float yPos = (firstBtnRT.position.y + xRangeBtnRT.position.y) / 2;
        //contentTran.position = new Vector2(xPos, yPos);


        RectTransform firstBtnRT = btnList[0].GetComponent<RectTransform>();      //新的
        RectTransform xRangeBtnRT = btnList[allowBlockXNum].GetComponent<RectTransform>();
        //float xPos = (-contentTran.rect.width / 2) - (((allowBlockXNum - 1) * xBlockSpacing));
        //float yPos = (firstBtnRT.position.y + xRangeBtnRT.position.y) / 2;
        float xPos = (-contentTran.sizeDelta.x / 2);
        contentTran.offsetMax = new Vector2(contentTran.offsetMax.x, 0);
        //Debug.Log(contentTran.sizeDelta.x);
        //Debug.Log(contentTran.sizeDelta.y);

    }
    #endregion


    #region ScrollAmount
    //public void SumScrollAmount(ref float scrollAmount, AxisEventData eventData)
    //{
    //    int posOrNeg = 1;
    //    switch(eventData.moveDir)
    //    {
    //        case MoveDirection.Up:
    //        {
    //            posOrNeg = 1;
    //        }
    //        break;
    //        case MoveDirection.Down:
    //        {
    //            posOrNeg = -1;
    //        }
    //        break;

    //        default:
    //            break;
    //    }
    //    scrollAmount += eventData.moveVector.y * posOrNeg;
    //}
    public void SumScrollAmount(ref float scrollAmount,float addValue)
    {
        scrollAmount += addValue;
    }

    private float scrollBarValueBuffer = 0.5f;
    public float ScrollBarValueBuffer
    {
        get
        {
            return scrollBarValueBuffer;
        }
        set
        {
            //if(value>0.15f)
            //{
            //    MoveLastSetFirstSibling(testScroll.btns, testScroll.AllowBlockXNum);
            //    testScroll.scrollAmount = 0;
            //    scrollBarValueBuffer = value;
            //}
            if (value != scrollBarValueBuffer/*&&value!=0*/)
            {
                SumScrollAmount(ref testScroll.scrollAmount, value - scrollBarValueBuffer);
            }
            //if(value > 0.15f)
            //{
            //    OverValueTriggerMFFS(ref testScroll.scrollAmount, testScroll.btns, testScroll.AllowBlockXNum);
            //    testScroll.scrollAmount=0;
            //}
            scrollBarValueBuffer = value;
        }
    }
    public Scrollbar verticalBar;
    public void ScrollValueUpdate()
    {
        ScrollBarValueBuffer = verticalBar.value;
    }
    #endregion

    #region MoveAndSetAsFirstOrLastSibling
    public void MoveFirstSetLastSibling(List<GameObject> btnList,int allowBlockXNum)   //向下滑
    {
        for(int i=0;i<allowBlockXNum;i++)
        {
            btnList[i].transform.SetAsLastSibling();
        }
    }
    public void MoveLastSetFirstSibling(List<GameObject> btnList, int allowBlockXNum)   //向上滑
    {
        for (int i = (btnList.Count-1)-(allowBlockXNum-1); i < allowBlockXNum; i++)
        {
            btnList[i].transform.SetAsFirstSibling();
        }
    }
    #endregion

    #region Update偵測
    public void OverValueTriggerMFFS(ref float scrollValue, List<GameObject> btnList, int allowBlockXNum)
    {
        if(scrollValue>0.35f)
        {
            MoveLastSetFirstSibling(btnList, allowBlockXNum);
            scrollValue = 0;
        }
    }
    public void OverValueTriggerMFLS(ref float scrollValue, List<GameObject> btnList, int allowBlockXNum)
    {
        if (scrollValue < 0.35f)
        {
            MoveFirstSetLastSibling(btnList, allowBlockXNum);
            scrollValue = 0;
        }
    }

    public void OverValueUpdateData(/*ScrollRect scrollRect*/Scrollbar scrollbar,ref float scrollAmount,float overAmount,ref int nowRowDir,List<int> dataList, List<GameObject> btnList, int allowBlockXNum,int allowBlockYNum, int outsideBlockYNum, ref int nowIndex)
    {
        if (scrollAmount > 0.3f)
        {
            //scrollRect.verticalScrollbar.value = 0.5f;
            scrollbar.value = 0.5f;

            scrollAmount = 0f;
            nowRowDir+=1;   //方向向上  行數項下滾

            int floorNowIndex = nowIndex + allowBlockXNum;
            if (floorNowIndex <= allowBlockXNum*outsideBlockYNum)
            {
                nowIndex += allowBlockXNum;
            }
            //UpdateData(dataList,btnList, nowRowDir, allowBlockXNum);  //直接改數字
            UpdateDataFromServer(dataList, btnList, nowIndex,allowBlockXNum, allowBlockYNum, outsideBlockYNum, nowRowDir);
            nowRowDir = 0;
            Debug.Log("Over");
        }
    }
    public void BelowValueUpdateData(/*ScrollRect scrollRect*/Scrollbar scrollbar, ref float scrollAmount,float overAmount,ref int nowRowDir, List<int> dataList,List<GameObject> btnList, int allowBlockXNum,int allowBlockYNum,int outsideBlockYNum, ref int nowIndex)
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
            UpdateDataFromServer(dataList,btnList, nowIndex,allowBlockXNum, allowBlockYNum,outsideBlockYNum,nowRowDir);
            nowRowDir = 0;
        }
    }
    #endregion

    #region UpdateData
    public void UpdateData(List<int> dataList,List<GameObject> btnList,int nowRow,int allowBlockXNum)
    {
        for(int i=0;i<btnList.Count;i++)
        {
            //int nowNum = int.Parse(btnList[i].transform.GetChild(1).GetComponent<Text>().text);
            //int detectValue = nowNum + nowRow * allowBlockXNum;
            //if (detectValue <= btnList.Count - 1 && detectValue >= 0)
            //{
            //    nowNum += nowRow * allowBlockXNum;
            //}


            //if(nowNum<=btnList.Count-1&&nowNum>=0)
            //{
            //    //btnList[i].transform.GetChild(1).GetComponent<Text>().text = nowNum.ToString();
            //    btnList[i].transform.GetChild(1).GetComponent<Text>().text = dataList[nowNum].ToString();
            //}


            //原方法
            int nowNum = int.Parse(btnList[i].transform.GetChild(1).GetComponent<Text>().text);
            nowNum += nowRow * allowBlockXNum;
            btnList[i].transform.GetChild(1).GetComponent<Text>().text = nowNum.ToString();

        }
    }
    public void UpdateDataFromServer(List<int> dataList, List<GameObject> btnList,int nowIndex, int allowBlockXNum, int allowBlockYNum,int outsideBlockYNum,int nowRowDir)
    {
        //int addedIndex = nowIndex;
        //int clampIndex = Mathf.Clamp(addedIndex,0, (btnList.Count-1) - (allowBlockXNum * allowBlockYNum-1));
        ////for (int i = allowBlockXNum*outsideBlockYNum; i < allowBlockXNum * outsideBlockYNum+allowBlockXNum * allowBlockYNum; i++)
        ////{
        ////    btnList[i].transform.GetChild(1).GetComponent<Text>().text = dataList[clampIndex].ToString();
        ////    clampIndex++;
        ////}

        //int maxIndex = Mathf.Clamp(clampIndex, 0, btnList.Count);
        //for (int i = nowIndex; i < btnList.Count; i++)
        //{
        //    btnList[i].transform.GetChild(1).GetComponent<Text>().text = dataList[i].ToString();
        //    clampIndex++;
        //}
    }


    #endregion






    }