using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

using DG.Tweening;
public class UScrollHelper : UIBase
{
    public TestUScroll testUScroll;
    public void InitialData(int allowBlockXNum, int allowBlockYNum, int btnCount, List<int> dataList)
    {
        if (btnCount < allowBlockXNum * allowBlockYNum)
        {
            Debug.Log("BTN總數小於資料總數");
        }
        for (int i = 0; i < allowBlockXNum * allowBlockYNum; i++)
        {
            dataList.Add(i);
        }
    }
    public void InitialGridWidthGridHeightSetGridPos(List<GameObject> rowList, GameObject rowPrefab, Transform parentTran, int allowBlockXNum, int allowBlockYNum, float xSpacing, float ySpacing, float blockXWidth, float blockYHeight, float initialYPos)
    {
        List<RectTransform> rowRectTranList = new List<RectTransform>();
        for (int i = 0; i < allowBlockYNum; i++)
        {
            GameObject newRow = Instantiate(rowPrefab);
            newRow.transform.SetParent(parentTran);     //生成ROW們
            rowRectTranList.Add(newRow.GetComponent<RectTransform>());
            rowList.Add(newRow);
        }
        for (int i = 0; i < allowBlockYNum; i++)
        {
            rowRectTranList[i].sizeDelta = new Vector2(blockXWidth * allowBlockXNum + xSpacing * (allowBlockXNum + 1), blockYHeight);
        }
        for (int i = 0; i < allowBlockYNum; i++)
        {
            rowRectTranList[i].anchoredPosition = new Vector3
                (0,
                initialYPos - blockYHeight * i - ySpacing * i);
        }

    }
    public void InstanPrefab(GameObject rowPrefab, Transform parentTran, List<GameObject> rowList, List<RectTransform> rowRectTranList, int allowBlockYNum)   //生成ROW 添GO、RECTTRAN LIST
    {
        for (int i = 0; i < allowBlockYNum; i++)
        {
            GameObject newRow = Instantiate(rowPrefab);
            newRow.transform.SetParent(parentTran);     //生成ROW們
            rowRectTranList.Add(newRow.GetComponent<RectTransform>());
            rowList.Add(newRow);
        }
    }
    public void SetRowDeltaSize(List<RectTransform> rowRectTranList, int allowBlockXNum, int allowBlockYNum, float blockXWidth, float blockYHeight, float xSpacing) //SET ROW SIZE
    {
        for (int i = 0; i < allowBlockYNum; i++)
        {
            rowRectTranList[i].sizeDelta = new Vector2(blockXWidth * allowBlockXNum + xSpacing * (allowBlockXNum + 1), blockYHeight);
        }
    }
    public void SetRowAnchorPos(List<RectTransform> rowRectTranList, int allowBlockYNum, float blockYHeight, float ySpacing, float initialYPos)  //SET ROW POS
    {
        for (int i = 0; i < allowBlockYNum; i++)
        {
            rowRectTranList[i].anchoredPosition = new Vector3
                (0,
                initialYPos - blockYHeight * i - ySpacing * i);
        }
    }
    public void AddButton(GameObject btnPrefab, Transform parentTran, int allowBlockXNum, int allowBlockYNum, List<GameObject> btnList,
        List<GameObject> parentList)
    {
        //int index = 0;
        //for (int i = 0; i < allowBlockXNum; i++)
        //{
        //    for (int j = 0; j < allowBlockYNum; j++)
        //    {
        //        GameObject newBtn = Instantiate(btnPrefab);  //生成
        //        newBtn.transform.SetParent(parentTran);    //SET父

        //        newBtn.transform.GetChild(1).GetComponent<Text>().text = index.ToString();  //變數字         //單一GRIDLAYOUT加法
        //        newBtn.gameObject.name = index.ToString();
        //        index++;

        //        btnList.Add(newBtn);
        //    }
        //}

        int parentListIndex = 0;   //每列個後 +1
        int index = 0;
        for (int i = 0; i < allowBlockXNum; i++)
        {
            for (int j = 0; j < allowBlockYNum; j++)
            {
                if (index > 1 && index % allowBlockXNum == 0)
                {
                    parentListIndex++;
                    Debug.Log(index);
                }
                GameObject newBtn = Instantiate(btnPrefab);  //生成
                newBtn.transform.SetParent(parentList[parentListIndex].transform);    //SET父

                //newBtn.transform.GetChild(1).GetComponent<Text>().text = index.ToString();  //變數字         //單一GRIDLAYOUT加法  SET INDEX NUMBER
                newBtn.gameObject.name = index.ToString();
                index++;

                btnList.Add(newBtn);




            }
        }
    }

    public void SetButtonData(List<GameObject> btnList, List<int> dataList, int start, int end)
    {
        if (end > dataList.Count)
        {
            Debug.Log("尾INDEX超過DATALIST最大數");
        }
        else
        {
            int btnListIndex = 0;
            for (int i = start; i < end; i++)
            {
                btnList[btnListIndex].transform.GetChild(1).GetComponent<Text>().text = dataList[i].ToString();
                btnListIndex++;
            }
        }
        
    }
    public void SetBigBlockParent(List<GameObject> parentList,Transform bigBlock)
    {
        for(int i=0;i<parentList.Count;i++)
        {
            parentList[i].transform.SetParent(bigBlock);
        }
    }
    public void SetBigBlockPos(List<Transform> bigBlockList,int index,int allowYNum,float blockYHeight,float ySpacing,float initialPosY)
    {
        bigBlockList[index].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2
            (bigBlockList[index].GetComponent<RectTransform>().anchoredPosition.x,
            initialPosY - index*((allowYNum * (blockYHeight + ySpacing))));
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

    public float scrollBarValueBuffer = 0f;
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
    public void AddIndexUpdateData(ref float negativeBuffer, float negativeGap, ref int nowIndex, int allowBlockXNum, int allowBlockYNum, List<int> dataList, List<GameObject> btnList)
    {
        if (negativeBuffer > negativeGap)
        {
            negativeBuffer = 0;

            int ceilingIndex = nowIndex + allowBlockXNum;
            if (ceilingIndex <= (dataList.Count - 1) - (allowBlockXNum - 1) - ((allowBlockYNum - 1) * allowBlockXNum))
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

    public void UpdateData(List<GameObject> btnList, List<int> dataList, int nowIndex, int allowBlockXNum, int allowBlockYNum)
    {
        int nowIndexIndex = nowIndex;
        for (int i = 0; i < allowBlockXNum * allowBlockYNum; i++)
        {
            btnList[i].transform.GetChild(1).GetComponent<Text>().text = dataList[nowIndexIndex].ToString();
            nowIndexIndex++;
        }
    }
    public void UpdateDataByBar(List<GameObject> btnList, List<int> dataList, int nowIndex, int allowBlockXNum, int allowBlockYNum, float verticalBarValue)
    {
        float oneMinus = verticalBarValue * (dataList.Count - btnList.Count);
        float floor = Mathf.Floor(oneMinus);
        int index = (int)Mathf.Clamp(floor, 0, (dataList.Count - btnList.Count));

        Debug.Log(new { oneMinus, floor, index });


        for (int i = 0; i < btnList.Count; i++)
        {
            btnList[i].transform.GetChild(1).GetComponent<Text>().text = dataList[index].ToString();
            index++;
        }
    }
    #endregion

    #region ScrollView影響ScrollBar
    public void BindScrollRectOnValueChange(ScrollRect scrollRect)
    {
        scrollRect.onValueChanged.AddListener(ScrollValue);
    }
    public void ScrollValue(Vector2 scrollValue)
    {
        Debug.Log("X:" + scrollValue.x);
        Debug.Log("Y:" + scrollValue.y);
    }
    #endregion


    #region DragImageEvent
    private Vector2 startDragPos = new Vector2();   //只有DRAGIMAGEEVENT使用
    private Vector2 endDragPos = new Vector2();     //只有DRAGIMAGEEVENT使用
    private float xDragLength;
    private float yDragLength;
    public void StartCalculateDrag(GameObject dragImage, Slider slider, float imageHeight, float speed, float time)
    {
        AddBeginDragG(dragImage, BeginDragInitialDragBuffer);
        AddEndDragG(dragImage, EndDragCalculateDragBuffer);
        testUScroll.endDragEvent += () =>
        {
            //slider.value+=yDragLength/imageHeight*speed;
            slider.DOValue(slider.value += yDragLength / imageHeight * speed, time);
        };
    }
    public void BeginDragInitialDragBuffer(BaseEventData eventData)     //首尾DRAG POS計算
    {
        startDragPos = Input.mousePosition;
    }
    public void EndDragCalculateDragBuffer(BaseEventData eventData)
    {
        endDragPos = Input.mousePosition;
        xDragLength = (endDragPos - startDragPos).x;
        yDragLength = (endDragPos - startDragPos).y;
        Debug.Log(new { xDragLength, yDragLength });

        testUScroll.TriggerEndDragEvent();
    }
    private float dragAmount;  //只有DRAGIMAGEEVENT BYFRAME使用        //BYFRAME DRAGAMOUNT計算
    public void StartCalculateDragByFrame(GameObject dragImage, Slider slider, float sliderSpeed, float timeSpeed, float time, float yPos, float frameCountRestrict, float sliderLength)
    {
        AddBeginDragG(dragImage, BeginDragStart);
        AddEndDragG(dragImage, EndDragEnd);
        if (dragPeriod == true && Time.frameCount % frameCountRestrict == 0)
        {
            //slider.DOValue(slider.value += (Input.mousePosition.y - yPos) / speed, time).SetEase(Ease.Linear);
            slider.DOValue(slider.value += (Input.mousePosition.y - yPos) / sliderSpeed, sliderLength * ((Input.mousePosition.y - yPos) / sliderSpeed / timeSpeed)).SetEase(Ease.Linear);
        }

    }
    public void MousePosYUpdate(ref float yPos)
    {
        yPos = Input.mousePosition.y;
    }
    private bool dragPeriod = false;
    public void BeginDragStart(BaseEventData eventData)     //首尾DRAG POS計算
    {
        dragPeriod = true;
    }
    public void EndDragEnd(BaseEventData eventData)
    {
        dragPeriod = false;
    }



    private Vector2 distance = new Vector2();   //只有DRAGIMAGEEVENT BYMOUSEPOS使用
    private float yBuffer = -74.0f;
    public float YBuffer
    {
        set
        {
            dragVectorAmount += (value - yBuffer);
            float positiveAdd = (value - yBuffer);
            float negativeAdd = (value - yBuffer);
            if (value - yBuffer > 0)
            {
                testUScroll.positiveBuffer += positiveAdd;
                negativeAdd = 0;

            }

            if (value - yBuffer < 0)
            {
                testUScroll.negativeBuffer -= negativeAdd;
                positiveAdd = 0;
            }
            yBuffer = value;
            
        }
        get
        {
            return yBuffer;
        }
    }
    private float beginY = 0;
    private float endY = 0;
    [SerializeField]
    private float dragVectorAmount=0;

    public void StartDragByMousePos(GameObject dragImage)
    {
        yBuffer = testUScroll.HandleTran.anchoredPosition.y;
        AddBeginDragG(dragImage, BeginDragSetDistance);
        AddDragG(dragImage, OnDragSetSliderPos);
        AddEndDragG(dragImage, EndDragSet);
    }
    public void BeginDragSetDistance(BaseEventData eventData)     //首尾DRAG POS計算
    {
        if ((Input.mousePosition.y + distance.y) < 10000000 && (Input.mousePosition.y + distance.y) >= -74)
        {
            yBuffer = testUScroll.sliderRectTran.anchoredPosition.y;
            distance = testUScroll.sliderRectTran.anchoredPosition - (Vector2)Input.mousePosition;
            beginY = testUScroll.sliderRectTran.anchoredPosition.y;
        }
    }
    public void OnDragSetSliderPos(BaseEventData eventData)
    {
        if ((Input.mousePosition.y + distance.y) < 10000000 && (Input.mousePosition.y + distance.y) >= -74)
        {
            testUScroll.sliderRectTran.anchoredPosition = new Vector2(testUScroll.sliderRectTran.anchoredPosition.x, (Input.mousePosition.y + distance.y));

            YBuffer = testUScroll.sliderRectTran.anchoredPosition.y;

            //endY= testUScroll.sliderRectTran.anchoredPosition.y;
            
        }
        
        
    }
    public void EndDragSet(BaseEventData eventData)
    {
        YBuffer = testUScroll.sliderRectTran.anchoredPosition.y;
        //YBuffer = endY - beginY;
    }
    public void UpdateYPos()
    {
        YBuffer= testUScroll.sliderRectTran.anchoredPosition.y;
    }
    #endregion

    #region UpdateAndRemove
    
    public void AddDownButton(Transform parent)
    {
        
    }
    public void RemoveTopButton(Transform parent)
    {
        Destroy(parent.GetChild(0));
    }




    #endregion



    #region RollingUp
    public void RollingUp(List<Transform> bigBlockList, float bigBlockHeight,ref float positiveBuffer,float positiveBufferMax,ref float negativeBuffer)
    {
        if(positiveBuffer-negativeBuffer>positiveBufferMax)
        {
            MovingTopToBottom(bigBlockList, bigBlockHeight);
            CleanPositiveBuffer(ref positiveBuffer);
            CleanNegativeBuffer(ref negativeBuffer);
            positiveBuffer = 0;
            negativeBuffer = 0;
        }  
    }

    public void MovingTopToBottom(List<Transform> bigBlockList,float bigBlockHeight)
    {
        GameObject topBlock;
        int topBlockIndex = 0;
        for (int i=0;i<bigBlockList.Count;i++)
        {
            BigBlockData bigBlock = bigBlockList[i].gameObject.GetComponent<BigBlockData>();
            if(bigBlock.Index==0)
            {
                //topBlock = bigBlock.gameObject;
                topBlockIndex = i;
            }
            else
            {
                bigBlock.Index--;
            }
        }
        topBlock = bigBlockList[topBlockIndex].gameObject;
        topBlock.GetComponent<RectTransform>().anchoredPosition = new Vector2
            (topBlock.GetComponent<RectTransform>().anchoredPosition.x,
            topBlock.GetComponent<RectTransform>().anchoredPosition.y - 3 * bigBlockHeight);

        topBlock.GetComponent<BigBlockData>().Index = 2;
    }
    public void CleanPositiveBuffer(ref float positiveBuffer)
    {
        positiveBuffer = 0;
    }

    public void RollingDown(List<Transform> bigBlockList, float bigBlockHeight, ref float positiveBuffer, float negativeBufferMax, ref float negativeBuffer)
    {
        if (negativeBuffer-positiveBuffer > negativeBufferMax)
        {
            MovingBottomToTop(bigBlockList, bigBlockHeight);
            CleanNegativeBuffer(ref negativeBuffer);
            CleanPositiveBuffer(ref positiveBuffer);
            positiveBuffer = 0;
            negativeBuffer = 0;
        }
    }

    public void MovingBottomToTop(List<Transform> bigBlockList, float bigBlockHeight)
    {
        GameObject bottomBlock;
        int bottomBlockIndex = 0;
        for (int i = 0; i < bigBlockList.Count; i++)
        {
            BigBlockData bigBlock = bigBlockList[i].gameObject.GetComponent<BigBlockData>();
            if (bigBlock.Index == 2)
            {
                //bottomBlock = bigBlock.gameObject;
                bottomBlockIndex = i;
            }
            else
            {
                bigBlock.Index++;
            }
        }
        bottomBlock = bigBlockList[bottomBlockIndex].gameObject;
        bottomBlock.GetComponent<RectTransform>().anchoredPosition = new Vector2
            (bottomBlock.GetComponent<RectTransform>().anchoredPosition.x,
            bottomBlock.GetComponent<RectTransform>().anchoredPosition.y + 3 * bigBlockHeight);

        bottomBlock.GetComponent<BigBlockData>().Index = 0;
    }
    public void CleanNegativeBuffer(ref float negativeBuffer)
    {
        negativeBuffer = 0;
    }
    #endregion
}
