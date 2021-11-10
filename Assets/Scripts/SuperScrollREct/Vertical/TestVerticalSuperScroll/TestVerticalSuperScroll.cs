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

    [Header("Data")]
    [SerializeField]
    private float itemNum;
    [SerializeField]
    private float itemWidth;
    [SerializeField]
    private float itemHeight;
    [SerializeField]
    private float maxItemNum;
    [SerializeField]
    private float queue;
    [Range(1,10)]
    [SerializeField]
    private float containRow;
    [SerializeField]
    private float revealXNum;
    [SerializeField]
    private float scrollViewXMin;
    [SerializeField]
    private float scrollViewXMax;

    [Header("GameObject")]
    [SerializeField]
    private GameObject _obj;

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


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        SuperScrollHelper.InitialData(dataList, maxItemNum);
        SuperScrollHelper.SetContentWidth(scrollRectTran, superRect, itemNum, maxItemNum, queue, itemWidth, itemHeight);
        SuperScrollHelper.InsCountitemWidth(_obj, superRect, item, dataList, itemNum, maxItemNum, queue, itemWidth, itemHeight, ref lastIndex);
        SuperScrollHelper.SetContentYPos(superRect,0);
    }

    // Update is called once per frame
    void Update()
    {
        SuperScrollHelper.OnScrollMoveWidth(scrollRectTran, superRect, item, dataList, itemNum, maxItemNum, queue,containRow, itemWidth, itemHeight, ref firstIndex, ref lastIndex, ref nowIndex, ref xPositivePosBuffer, ref xNegativePosBuffer);
        SuperScrollHelper.LockScrollViewYMax(superRect,0);
        SuperScrollHelper.LockScrollViewXMax(superRect, -(Mathf.Ceil(maxItemNum / queue) * itemWidth - (9 * itemWidth)));     //������ܫ̳̫e�q�b�q�ڳ̥��q��ܥb�q
    }
}