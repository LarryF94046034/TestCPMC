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
    [Header("Input")]
    [SerializeField]
    private int btnCount;   //總共多少Btn
    [SerializeField]
    private int allowBlockXNum;   //顯示X行，橫向，X個        BLOCK
    [SerializeField]
    private int allowBlockYNum;  //顯示Y列，直向，Y個
    [SerializeField]
    private int outsideBlockYNum;  //額外Y列
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
    private List<GameObject> btnList;   //所有Button GO
    [SerializeField]
    private List<int> dataList = new List<int>();   //資料LIST INT

    [Header("ScrollAmount")]
    [SerializeField]
    public float scrollAmount = 0;
    [SerializeField]
    public float positiveBuffer = 0;
    [SerializeField]
    public float negativeBuffer = 0;

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

    [Header("New:List")]       //DRAG IMAGE EVENT parentList
    [SerializeField]
    private List<GameObject> parentList = new List<GameObject>();

    #endregion



    // Start is called before the first frame update
    void Start()
    {
        UScrollHelper.InitialGridWidthGridHeightSetGridPos(parentList,rowPrefab, rowParent, allowBlockXNum, allowBlockYNum, allowXSpacing, allowYSpacing, blockXWidth, blockYHeight,initialYPos);
        UScrollHelper.InitialData(allowBlockXNum, allowBlockYNum + outsideBlockYNum * 2,btnCount, dataList);  //生成資料
        UScrollHelper.AddButton(buttonPrefab, fillParent, allowBlockXNum, allowBlockYNum, btnList,parentList);    //生成BTN
        //UScrollHelper.SetBackgroundAdaptive(backgroundTran, allowBlockXNum, allowBlockYNum, blockXWidth, blockYHeight, allowXSpacing, allowYSpacing);  //調整UI大小
        //UScrollHelper.SetVerticalBarAdaptive(verticalBarTran,barXLength,allowBlockYNum, blockYHeight, allowYSpacing);   //直BAR 自適應
        //UScrollHelper.SetVerticalBarPosition(verticalBarTran, (allowBlockXNum * blockXWidth + (allowBlockXNum + 1) * allowXSpacing)/*BACKGROUND寬*/, barXLength);   //直BAR X座標設定

        //UScrollHelper.StartCalculateDrag(dragImage,slider,4000,0.3f,6.0f);  //綁定計算DRAG距離事件

        UScrollHelper.StartDragByMousePos(dragImage);


    }

    // Update is called once per frame
    void Update()
    {
        
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
