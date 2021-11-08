using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

using DG.Tweening;
public class UScrollHelper : UIBase
{
    public TestUScroll testUScroll;
    public void InitialData(int allowBlockXNum, int allowBlockYNum,int btnCount, List<int> dataList)
    {
        if(btnCount>allowBlockXNum*allowBlockYNum)
        {
            Debug.Log("BTN�`�Ƥj���`��*�`�C");
        }
        for (int i = 0; i < btnCount; i++)
        {
            dataList.Add(i);
        }
    }
    public void InitialGridWidthGridHeightSetGridPos(List<GameObject> rowList,GameObject rowPrefab,Transform parentTran,int allowBlockXNum,int allowBlockYNum,float xSpacing,float ySpacing,float blockXWidth,float blockYHeight,float initialYPos)
    {
        List<RectTransform> rowRectTranList = new List<RectTransform>();
        for(int i=0;i<allowBlockYNum;i++)
        {
            GameObject newRow = Instantiate(rowPrefab);
            newRow.transform.SetParent(parentTran);     //�ͦ�ROW��
            rowRectTranList.Add(newRow.GetComponent<RectTransform>());
            rowList.Add(newRow);
        }
        for(int i=0;i<allowBlockYNum;i++)
        {
            rowRectTranList[i].sizeDelta = new Vector2(blockXWidth * allowBlockXNum + xSpacing * (allowBlockXNum + 1), blockYHeight);
        }
        for(int i=0;i<allowBlockYNum;i++)
        {
            rowRectTranList[i].anchoredPosition = new Vector3
                (0,
                initialYPos-blockYHeight*i-ySpacing*i);
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
        //        GameObject newBtn = Instantiate(btnPrefab);  //�ͦ�
        //        newBtn.transform.SetParent(parentTran);    //SET��

        //        newBtn.transform.GetChild(1).GetComponent<Text>().text = index.ToString();  //�ܼƦr         //��@GRIDLAYOUT�[�k
        //        newBtn.gameObject.name = index.ToString();
        //        index++;

        //        btnList.Add(newBtn);
        //    }
        //}

        int parentListIndex = 0;   //�C�C�ӫ� +1
        int index = 0;
        for (int i = 0; i < allowBlockXNum; i++)
        {
            for (int j = 0; j < allowBlockYNum; j++)
            {
                if (index>1&&index % allowBlockXNum == 0)
                {
                    parentListIndex++;
                    Debug.Log(index);
                }
                GameObject newBtn = Instantiate(btnPrefab);  //�ͦ�
                newBtn.transform.SetParent(parentList[parentListIndex].transform);    //SET��

                newBtn.transform.GetChild(1).GetComponent<Text>().text = index.ToString();  //�ܼƦr         //��@GRIDLAYOUT�[�k
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


    #region �p��ưʶq
    public void SumScrollAmount(ref float scrollAmount, float addValue, ref float positiveBuffer, ref float negativeBuffer)  //�ֿn�ܶq
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
            if (value != scrollBarValueBuffer && sumOrNot == true)        //2.SCOLLBARBUFFER SET���������ܰ� �ֿn�ܰʶq SETVALUE
            {
                SumScrollAmount(ref testUScroll.scrollAmount, value - scrollBarValueBuffer, ref testUScroll.positiveBuffer, ref testUScroll.negativeBuffer);
            }
            scrollBarValueBuffer = value;
            Debug.Log(value);
        }
    }
    public Scrollbar verticalBar;   //���bONSCROLL EVENT��SCROLLVALUEUPDATE �L�k��SCROLLBAR �ҥH�b�o�̱�
    public void ScrollValueUpdate()     //����BAR�ܤ�    1.ONSCROLL�y���Ա����ܰʡASCROLLBARBUFFER�P���ܰ�
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
            nowRowDir += 1;   //��V�V�W  ��ƶ��U�u

            int floorNowIndex = nowIndex + allowBlockXNum;
            if (floorNowIndex <= allowBlockXNum * outsideBlockYNum)
            {
                nowIndex += allowBlockXNum;
            }
            //UpdateData(dataList,btnList, nowRowDir, allowBlockXNum);  //������Ʀr
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

            //UpdateData(dataList,btnList, nowRowDir, allowBlockXNum);  //������Ʀr
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

    #region ScrollView�v�TScrollBar
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
    private Vector2 startDragPos = new Vector2();   //�u��DRAGIMAGEEVENT�ϥ�
    private Vector2 endDragPos = new Vector2();     //�u��DRAGIMAGEEVENT�ϥ�
    private float xDragLength;
    private float yDragLength;
    public void StartCalculateDrag(GameObject dragImage,Slider slider,float imageHeight,float speed, float time)
    {
        AddBeginDragG(dragImage, BeginDragInitialDragBuffer);
        AddEndDragG(dragImage, EndDragCalculateDragBuffer);
        testUScroll.endDragEvent += () =>
        {
            //slider.value+=yDragLength/imageHeight*speed;
            slider.DOValue(slider.value += yDragLength / imageHeight*speed, time);
        };
    }
    public void BeginDragInitialDragBuffer(BaseEventData eventData)     //����DRAG POS�p��
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
    private float dragAmount;  //�u��DRAGIMAGEEVENT BYFRAME�ϥ�        //BYFRAME DRAGAMOUNT�p��
    public void StartCalculateDragByFrame(GameObject dragImage, Slider slider, float sliderSpeed, float timeSpeed, float time,float yPos,float frameCountRestrict,float sliderLength)
    {
        AddBeginDragG(dragImage, BeginDragStart);
        AddEndDragG(dragImage, EndDragEnd);
        if (dragPeriod==true&&Time.frameCount% frameCountRestrict==0)
        {
            //slider.DOValue(slider.value += (Input.mousePosition.y - yPos) / speed, time).SetEase(Ease.Linear);
            slider.DOValue(slider.value += (Input.mousePosition.y - yPos) / sliderSpeed, sliderLength*((Input.mousePosition.y - yPos) / sliderSpeed/ timeSpeed)).SetEase(Ease.Linear); 
        }
        
    }
    public void MousePosYUpdate(ref float yPos)
    {
        yPos = Input.mousePosition.y;
    }
    private bool dragPeriod=false;
    public void BeginDragStart(BaseEventData eventData)     //����DRAG POS�p��
    {
        dragPeriod = true;
    }
    public void EndDragEnd(BaseEventData eventData)
    {
        dragPeriod = false;
    }



    private Vector2 distance = new Vector2();   //�u��DRAGIMAGEEVENT BYMOUSEPOS�ϥ�
    
    public void StartDragByMousePos(GameObject dragImage)
    {
        AddBeginDragG(dragImage, BeginDragSetDistance);
        AddDragG(dragImage, OnDragSetSliderPos);
    }
    public void BeginDragSetDistance(BaseEventData eventData)     //����DRAG POS�p��
    {
        if ((Input.mousePosition.y + distance.y) < 386 && (Input.mousePosition.y + distance.y) > -74)
        {
            distance = testUScroll.sliderRectTran.anchoredPosition - (Vector2)Input.mousePosition;
        }
    }
    public void OnDragSetSliderPos(BaseEventData eventData)
    {
        if((Input.mousePosition.y + distance.y) < 386 && (Input.mousePosition.y + distance.y) > -74)
        {
            testUScroll.sliderRectTran.anchoredPosition = new Vector2(testUScroll.sliderRectTran.anchoredPosition.x, (Input.mousePosition.y + distance.y));
        }
    }
    public void EndDragSetSliderPos(BaseEventData eventData)
    {
        testUScroll.sliderRectTran.anchoredPosition = new Vector2(testUScroll.sliderRectTran.anchoredPosition.x, (Input.mousePosition.y + distance.y));    
    }






    #endregion
}
