using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TestUScroll : UIBase
{
    public UScrollHelper UScrollHelper;

    //[Header("New:EndDragEvent")]       //DRAG IMAGE EVENT endDragEvent
    [SerializeField]
    public event Action endDragEvent;
    [SerializeField]           //DRAG IMAGE EVENT  sliderRectTran
    public RectTransform sliderRectTran;
    [Header("New:Slider")]       //DRAG IMAGE EVENT dragImage
    [SerializeField]
    public Slider slider;

    [Header("PREFAB")]
    [SerializeField]
    private GameObject buttonPrefab;   //生成BTN
    [SerializeField]
    private GameObject rowPrefab;   //生成ROW


    [Header("Transform")]
    [SerializeField]
    private Transform fillParent;   //生成用父物件，生成在這下面
    [SerializeField]
    private Transform rowParent;   //生成用父物件，生成在這下面
    [Header("RectTransform")]
    [SerializeField]
    private RectTransform backgroundTran;   //背景 RT
    [SerializeField]
    private RectTransform verticalBarTran;   //直BAR RT
    [SerializeField]
    private RectTransform maskTran;   //遮罩 RT
    [SerializeField]
    private RectTransform handleTran;   //HANDLE RT
    public RectTransform HandleTran
    {
        get
        {
            return handleTran;
        }
    }
    [Header("Input")]
    [SerializeField]
    private int btnCount;   //總共多少Btn
    [SerializeField]
    private int allowBlockXNum;   //顯示X行，橫向，X個        BLOCK
    [SerializeField]
    private int allowBlockYNum;  //顯示Y列，直向，Y個，顯示區總共 allowBlockYNum列
    [SerializeField]
    private int outsideBlockYNum;  //額外Y列，資料欄總共 allowBlockYNum+outsideBlockYNum列
    [SerializeField]
    private int additionalBlockYNum;  //額外Y列，顯示區+更新區總共 allowBlockYNum(顯)+additionalBlockYNum列(更)
    [SerializeField]
    private float blockXWidth;   //單格X長
    [SerializeField]
    private float blockYHeight;   //單格Y高
    [SerializeField]
    private float allowXSpacing;  //間隔X寬
    [SerializeField]
    private float allowYSpacing;  //間隔Y高

    [SerializeField]
    private float barXLength;  //直BAR X 長                  BAR

    [SerializeField]
    public int nowIndex = 0;    //目前資料位置               INDEX
    [SerializeField]
    private float initialYPos=200;  //第一行高度
    

    [SerializeField]
    public Vector2 scrollRectValueChange = new Vector2();    //測試ScrollRect ValueChange


    [Header("Buffer")]
    [SerializeField]
    private List<GameObject> btnList;   //所有ROW Button GO
    [SerializeField]
    private List<GameObject> additionalBtnList;   //額外ROW1 Button GO
    [SerializeField]
    private List<GameObject> additionalBtn1List;   //額外ROW2 Button GO
    [SerializeField]
    private List<int> dataList = new List<int>();   //資料LIST INT
    [SerializeField]
    private List<GameObject> parentList = new List<GameObject>();    //ROW 們
    [SerializeField]
    private List<GameObject> additionalParentList = new List<GameObject>();  //額外 ROW1 們
    [SerializeField]
    private List<GameObject> additionalParent1List = new List<GameObject>();  //額外 ROW2 們
    [SerializeField]
    private List<RectTransform> rowRectTranList = new List<RectTransform>();   //資料ROW們 RectTran
    [SerializeField]
    private List<RectTransform> additionalRowRectTranList = new List<RectTransform>();   //額外 ROW1們 RectTran
    [SerializeField]
    private List<RectTransform> additionalRowRectTran1List = new List<RectTransform>();   //額外 ROW2們 RectTran

    [SerializeField]
    private List<Transform> bigBlockList = new List<Transform>();   //3大方格

    [Header("ScrollAmount")]
    [SerializeField]
    public float scrollAmount = 0;
    [SerializeField]
    public float positiveBuffer = 0;
    [SerializeField]
    public float negativeBuffer = 0;
    [SerializeField]
    public float positiveBufferMax = 1000;
    [SerializeField]
    public float negativeBufferMax = 1000;

    [Header("NegativeGap")]
    [SerializeField]
    private float positiveGap=0;   //超過正值 正定量 觸發
    [SerializeField]
    private float negativeGap=0;   //超過負值 正定量 觸發

    [Header("Scrollbar")]
    [SerializeField]
    private Scrollbar verticalBar;   //超過正值 正定量 觸發


    #region 新領域:綁定Image(Drag距離計算) + ScrollBar +上面已成功的UScroll //DRAG IMAGE EVENT dragImage//DRAG IMAGE EVENT endDragEvent
    [Header("New:ScrollRect")]
    [SerializeField]
    private ScrollRect scrollRect;   //SR

    [Header("New:GameObject")]       //DRAG IMAGE EVENT dragImage
    [SerializeField]
    private GameObject dragImage;

    
    

    [Header("New:Data")]       //DRAG IMAGE EVENT dragImage
    [SerializeField]
    private float mousePosY=0;

    
    

    #endregion



    // Start is called before the first frame update
    void Start()
    {
        UScrollHelper.InitialData(allowBlockXNum, allowBlockYNum + additionalBlockYNum*2, btnCount, dataList);  //生成資料

        //UScrollHelper.InitialGridWidthGridHeightSetGridPos(parentList,rowPrefab, rowParent, allowBlockXNum, allowBlockYNum, allowXSpacing, allowYSpacing, blockXWidth, blockYHeight,initialYPos);
        UScrollHelper.InstanPrefab(rowPrefab, rowParent, parentList, rowRectTranList, allowBlockYNum);  //生成ALLOW ROW
        UScrollHelper.SetRowDeltaSize(rowRectTranList, allowBlockXNum, allowBlockYNum, blockXWidth, blockYHeight, allowXSpacing);   //設定ALLOW ROW SIZE
        UScrollHelper.SetRowAnchorPos(rowRectTranList, allowBlockYNum, blockYHeight, allowYSpacing, initialYPos);   //設定ALLOW ROW POS
        UScrollHelper.AddButton(buttonPrefab, fillParent, allowBlockXNum, allowBlockYNum, btnList, parentList);    //生成ALLOW ROW BTN
        UScrollHelper.SetButtonData(btnList, dataList,0,btnList.Count);   //設定ALLOE ROW 資料
        UScrollHelper.SetBigBlockParent(parentList, bigBlockList[0]);
        

        UScrollHelper.InstanPrefab(rowPrefab, rowParent, additionalParentList, additionalRowRectTranList, additionalBlockYNum);  //生成ADDITION ROW
        UScrollHelper.SetRowDeltaSize(additionalRowRectTranList, allowBlockXNum, additionalBlockYNum, blockXWidth, blockYHeight, allowXSpacing);   //設定ADDITION ROW SIZE
        //UScrollHelper.SetRowAnchorPos(additionalRowRectTranList, additionalBlockYNum, blockYHeight, allowYSpacing, (initialYPos-allowBlockYNum*(blockYHeight+allowYSpacing)));   //設定ADDITION ROW POS
        UScrollHelper.SetRowAnchorPos(additionalRowRectTranList, additionalBlockYNum, blockYHeight, allowYSpacing, initialYPos);   //設定ALLOW ROW POS
        UScrollHelper.AddButton(buttonPrefab, fillParent, allowBlockXNum, additionalBlockYNum, additionalBtnList, additionalParentList);    //生成ADDITION BTN
        UScrollHelper.SetButtonData(additionalBtnList, dataList,btnList.Count+0, btnList.Count+additionalBtnList.Count);   //設定ADDITION ROW 資料   additionalList上升btnList高度
        UScrollHelper.SetBigBlockParent(additionalParentList, bigBlockList[1]);
        UScrollHelper.SetBigBlockPos(bigBlockList, 1, additionalBlockYNum, blockYHeight, allowYSpacing, 0);

        UScrollHelper.InstanPrefab(rowPrefab, rowParent, additionalParent1List, additionalRowRectTran1List, additionalBlockYNum);  //生成ADDITION ROW
        UScrollHelper.SetRowDeltaSize(additionalRowRectTran1List, allowBlockXNum, additionalBlockYNum, blockXWidth, blockYHeight, allowXSpacing);   //設定ADDITION ROW SIZE
        //UScrollHelper.SetRowAnchorPos(additionalRowRectTran1List, additionalBlockYNum, blockYHeight, allowYSpacing, (initialYPos - 2*allowBlockYNum * (blockYHeight + allowYSpacing)));   //設定ADDITION ROW POS
        UScrollHelper.SetRowAnchorPos(additionalRowRectTran1List, additionalBlockYNum, blockYHeight, allowYSpacing,initialYPos);   //設定ALLOW ROW POS
        UScrollHelper.AddButton(buttonPrefab, fillParent, allowBlockXNum, additionalBlockYNum, additionalBtn1List, additionalParent1List);    //生成ADDITION BTN
        UScrollHelper.SetButtonData(additionalBtn1List, dataList, btnList.Count + additionalBtn1List.Count, btnList.Count + 2*additionalBtn1List.Count);   //設定ADDITION ROW 資料   additionalList上升btnList高度
        UScrollHelper.SetBigBlockParent(additionalParent1List, bigBlockList[2]);
        UScrollHelper.SetBigBlockPos(bigBlockList, 2, additionalBlockYNum, blockYHeight, allowYSpacing, 0);


        UScrollHelper.SetBackgroundAdaptive(maskTran, allowBlockXNum, allowBlockYNum, blockXWidth, blockYHeight, allowXSpacing, allowYSpacing);  //調整UI大小
        
        //UScrollHelper.SetVerticalBarAdaptive(verticalBarTran,barXLength,allowBlockYNum, blockYHeight, allowYSpacing);   //直BAR 自適應
        //UScrollHelper.SetVerticalBarPosition(verticalBarTran, (allowBlockXNum * blockXWidth + (allowBlockXNum + 1) * allowXSpacing)/*BACKGROUND寬*/, barXLength);   //直BAR X座標設定

        //UScrollHelper.StartCalculateDrag(dragImage,slider,4000,0.3f,6.0f);  //綁定計算DRAG距離事件

        UScrollHelper.StartDragByMousePos(dragImage);


    }

    // Update is called once per frame
    void Update()
    {
        UScrollHelper.RollingUp(bigBlockList, ((allowBlockYNum + 1) * allowYSpacing + (allowBlockYNum * blockYHeight)),ref positiveBuffer, positiveBufferMax,ref negativeBuffer);
        UScrollHelper.RollingDown(bigBlockList, ((allowBlockYNum + 1) * allowYSpacing + (allowBlockYNum * blockYHeight)), ref positiveBuffer, negativeBufferMax, ref negativeBuffer);
    }

    public void UpdateDataByBarOnScroll()
    {
        UScrollHelper.UpdateDataByBar(btnList, dataList, nowIndex, allowBlockXNum, allowBlockYNum, verticalBar.value);
    }
    public void TriggerEndDragEvent()
    {
        endDragEvent.Invoke();
    }
    

    
}
