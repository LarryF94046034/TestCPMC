using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScroll : MonoBehaviour
{
    public List<GameObject> Buttons;
    public GameObject Parent;
    public GameObject otherParent;


    public ScrollRect scrollView;
    

    public List<int> leftNum = new List<int>();
    public List<int> rightNum = new List<int>();
    
    public bool firstTime = false;

    public ScrollHelper ScrollHelper;

    [Header("ScrollRect")]
    [SerializeField]
    private GameObject buttonPrefab;   //生成BTN
    [SerializeField]
    private Transform fillParent;   //生成用父物件
    [SerializeField]
    private ScrollRect scrollRect;   //SCROLLRECT
    [SerializeField]
    private RectTransform scrollRectReactTran;   //SCROLLRECT RT
    [SerializeField]
    private RectTransform contentRectTran;   //CONTENT RT
    [SerializeField]
    private int allowBlockXNum;   //顯示X行
    public int AllowBlockXNum { get { return allowBlockXNum; } set { allowBlockXNum = value; } }
    [SerializeField]
    private int allowBlockYNum;  //顯示Y列
    [SerializeField]
    private float blockWidth;   //單格X長
    [SerializeField]
    private float blockHeight;   //單格Y高
    [SerializeField]
    private float allowXSpacing;  //間隔X寬
    [SerializeField]
    private float allowYSpacing;  //間隔Y高
    [SerializeField]
    private int outsideBlockYNum;  //額外Y列

    [SerializeField]
    public List<GameObject> btns;

    [SerializeField]
    private Image horizonHandleImage;
    [SerializeField]
    private Image horizonScrollbarImage;

    [SerializeField]
    public float scrollAmount=0;

    [SerializeField]
    public float overToUpdateAmount = 0.3f;

    [SerializeField]
    public int nowRowDir = 0;

    [SerializeField]
    public int nowIndex = 0;
    [SerializeField]
    private bool setNowIndex = false;

    [SerializeField]
    public List<int> dataList = new List<int>();
    [SerializeField]
    public int allAmount = 0;   //總數


    public Scrollbar verticalBar;

    // Start is called before the first frame update
    void Start()
    {
        //scrollHelper.SetScrollRectHeight(scrollRectReactTran,allowYSpacing,blockHeight,allowBlockYNum);
        //scrollHelper.SetScrollRectWidth(scrollRectReactTran, allowXSpacing,blockWidth, allowBlockXNum);
        ScrollHelper.InitialData(allowBlockXNum, allowBlockYNum+outsideBlockYNum*2, dataList);
        ScrollHelper.FillScrollRect(buttonPrefab, fillParent, allowBlockXNum, allowBlockYNum + outsideBlockYNum * 2, btns);
        ScrollHelper.SetScrollRectWH(scrollRectReactTran, allowXSpacing, blockWidth, allowBlockXNum, allowYSpacing, blockHeight, allowBlockYNum);
        ScrollHelper.SetContentHeight(contentRectTran, scrollRectReactTran, allowBlockYNum, outsideBlockYNum, allowYSpacing, blockHeight);
        
        ScrollHelper.SetContentPosition(contentRectTran, allowXSpacing, allowBlockXNum,btns);
        
        //ScrollHelper.SetScrollRectHandleMidPoint(scrollRect,0.5f);
        ScrollHelper.SetScrollRectHorizontalOne(scrollRect);
        ScrollHelper.CloseHorizontalHandle(horizonHandleImage, horizonScrollbarImage);
    }

    // Update is called once per frame
    void Update()
    {
        ScrollHelper.OverValueUpdateData(/*scrollRect*/verticalBar, ref scrollAmount, overToUpdateAmount, ref nowRowDir, dataList, btns, allowBlockXNum, allowBlockYNum, outsideBlockYNum, ref nowIndex);
        ScrollHelper.BelowValueUpdateData(/*scrollRect*/verticalBar, ref scrollAmount, overToUpdateAmount, ref nowRowDir, dataList, btns, allowBlockXNum, allowBlockYNum, outsideBlockYNum, ref nowIndex);
        //if(setNowIndex==false)
        //{
        //    ScrollHelper.SetNowIndex(ref nowIndex, 0);
        //    setNowIndex = true;
        //}

    }
}
