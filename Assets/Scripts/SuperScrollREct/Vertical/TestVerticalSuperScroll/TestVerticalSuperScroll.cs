using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestVerticalSuperScroll : MonoBehaviour
{
    [SerializeField]
    public VerticalSuperScrollHelper SuperScrollHelper;
    [SerializeField]
    private ScrollRect superScrollRect;   //SCROLLRECT

    [Header("RectTransform")]
    [SerializeField]
    private RectTransform superRect;   //CONTENT RT
    [SerializeField]
    private RectTransform scrollRectTran;  //SCROLLRECT RT
    [SerializeField]
    private RectTransform scrollRectPositionTran;  //SCROLLRECT RT

    [Header("Data")]
    [SerializeField]
    private float itemNum;
    [SerializeField]
    private float itemNumBuffer;
    [SerializeField]
    private float itemWidth;
    [SerializeField]
    private float itemWidthBuffer;

    [SerializeField]
    private float itemHeight;
    [SerializeField]
    private float itemHeightBuffer;
    [SerializeField]
    private float maxItemNum;
    [SerializeField]
    private float maxItemNumBuffer;
    [SerializeField]
    private float queue;
    [SerializeField]
    private float queueBuffer;
    
    [SerializeField]
    private float viewYNum;    //直向排
    [SerializeField]
    private float viewYNumBuffer;
    [Range(1,3)]
    [SerializeField]
    private float containRow;
    [SerializeField]
    private float containRowBuffer;
    
    [SerializeField]
    private float revealXNum;
    [SerializeField]
    private float scrollViewXMin;
    [SerializeField]
    private float scrollViewXMax;
    [SerializeField]
    private bool dataChange=false;

    [Header("GameObject")]
    [SerializeField]
    private GameObject _obj;
    [SerializeField]
    private GameObject scrollViewPrefab;
    [Header("Buffer")]
    [SerializeField]
    private List<GameObject> item;
    [SerializeField]
    private float yPosBuffer = 0;
    [SerializeField]
    private List<int> dataList;

    [Header("Index")]
    [SerializeField]
    private int lastIndex = 0;
    [SerializeField]
    private int firstIndex = 0;
    [SerializeField]
    private int nowIndex = 0;
    [SerializeField]
    private float xPositivePosBuffer = 0;
    [SerializeField]
    private float xNegativePosBuffer = 0;

    [Header("Optimizing")]
    [SerializeField]
    private int divideFrameCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        SuperScrollHelper.InitialIndexBufferValue(ref itemNumBuffer, ref itemNum);
        SuperScrollHelper.InitialIndexBufferValue(ref maxItemNumBuffer, ref maxItemNum);
        SuperScrollHelper.InitialIndexBufferValue(ref itemWidthBuffer, ref itemWidth);
        SuperScrollHelper.InitialIndexBufferValue(ref itemHeightBuffer, ref itemHeight);
        SuperScrollHelper.InitialIndexBufferValue(ref queueBuffer, ref queue);
        SuperScrollHelper.InitialIndexBufferValue(ref viewYNumBuffer, ref viewYNum);
        SuperScrollHelper.InitialIndexBufferValue(ref containRowBuffer, ref containRow);


        SuperScrollHelper.InitialData(dataList, maxItemNum);
        //SuperScrollHelper.InitialInsCountitemWidth(_obj, superRect, item, dataList, itemNum, maxItemNum, queue, containRow, viewYNum, itemWidth, itemHeight, ref lastIndex);
        SuperScrollHelper.InsCountitemWidth(_obj, superRect, item, dataList, itemNum, maxItemNum, queue, containRow, viewYNum, itemWidth, itemHeight, ref lastIndex);
        SuperScrollHelper.SetContentWidth(scrollRectTran, superRect, itemNum, maxItemNum, queue, itemWidth, itemHeight, viewYNum);
        //SuperScrollHelper.InsCountitemWidth(_obj, superRect, item, dataList, itemNum, maxItemNum, queue, itemWidth, itemHeight, ref lastIndex);
        SuperScrollHelper.SetScrollViewPos(scrollRectTran, scrollRectPositionTran);
        SuperScrollHelper.SetContentYPos(superRect, 0);
    }

    // Update is called once per frame
    void Update()
    {
        SuperScrollHelper.DetectValueChange_float(ref itemNumBuffer, ref itemNum, ref dataChange);
        SuperScrollHelper.DetectValueChange_float(ref maxItemNumBuffer, ref maxItemNum, ref dataChange);
        SuperScrollHelper.DetectValueChange_float(ref itemWidthBuffer, ref itemWidth, ref dataChange);
        SuperScrollHelper.DetectValueChange_float(ref itemHeightBuffer, ref itemHeight, ref dataChange);
        SuperScrollHelper.DetectValueChange_float(ref queueBuffer, ref queue, ref dataChange);
        SuperScrollHelper.DetectValueChange_float(ref viewYNumBuffer, ref viewYNum, ref dataChange);
        SuperScrollHelper.DetectValueChange_float(ref containRowBuffer, ref containRow, ref dataChange);

        if (dataChange == true)
        {
            SuperScrollHelper.ItemDestroy(item);
            //GameObject newScrollView = Instantiate(scrollViewPrefab);
            //superScrollRect = newScrollView.GetComponent<ScrollRect>();
            //scrollRectTran = newScrollView.GetComponent<RectTransform>();
            //superRect = superScrollRect.content;
            SuperScrollHelper.SetContentWidth(scrollRectTran, superRect, itemNum, maxItemNum, queue, itemWidth, itemHeight, viewYNum);
            //SuperScrollHelper.InitialInsCountitemWidth(_obj, superRect, item, dataList, itemNum, maxItemNum, queue, containRow, viewYNum, itemWidth, itemHeight, ref lastIndex);
            SuperScrollHelper.InsCountitemWidth(_obj, superRect, item, dataList, itemNum, maxItemNum, queue, containRow, viewYNum, itemWidth, itemHeight, ref lastIndex);
            SuperScrollHelper.SetScrollViewPos(scrollRectTran, scrollRectPositionTran);
            SuperScrollHelper.SetContentYPos(superRect, 0);

            SuperScrollHelper.SetIndex(ref firstIndex, 0);
            SuperScrollHelper.SetIndex(ref nowIndex, 0);
            SuperScrollHelper.SetIndex(ref lastIndex, (int)itemNum-1);
            dataChange = false;
        }


        SuperScrollHelper.OnScrollMoveWidth(scrollRectTran, superRect, item, dataList, itemNum, maxItemNum, queue,containRow, itemWidth, itemHeight, ref firstIndex, ref lastIndex, ref nowIndex, ref xPositivePosBuffer, ref xNegativePosBuffer);
        SuperScrollHelper.LockScrollViewYMax(superRect,0);
        SuperScrollHelper.LockScrollViewYMin(superRect,Mathf.Ceil(maxItemNum/queue)*itemHeight-viewYNum*itemHeight);     //扣掉顯示屏最前段半段根最末段顯示半段
    }
}
