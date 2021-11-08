using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSuperScroll : MonoBehaviour
{
    public ScrollHelper ScrollHelper;
    [Header("Transform")]
    [SerializeField]
    private RectTransform contentTran;   //HANDLE RT
    [SerializeField]
    private RectTransform scrollRectTran;   //HANDLE RT
    [SerializeField]
    private RectTransform contentRectTran;   //CONTENT RT

    [Header("Input")]
    [SerializeField]
    private int maxXNum;   //maxXNum
    [SerializeField]
    private int maxYNum;   //maxYNum
    [SerializeField]
    private float blockWidth;   //maxXNum
    [SerializeField]
    private float blockHeight;   //maxYNum
    

    [SerializeField]
    private RectTransform scrollRectReactTran;   //SCROLLRECT RT
    [SerializeField]
    private float xSpacing;  //間隔X寬
    [SerializeField]
    private float ySpacing;  //間隔Y高
    [SerializeField]
    private int blockXNum;   //顯示X行
    [SerializeField]
    private int blockYNum;   //顯示X行
    [SerializeField]
    private int outsideBlockYNum;  //額外Y列

    [Header("List")]
    [SerializeField]
    private List<int> dataList;   //資料LIST
    [SerializeField]
    public List<GameObject> btnList;  //BTN LIST


    [Header("Instan")]
    [SerializeField]
    private GameObject buttonPrefab;   //生成BTN
    [SerializeField]
    private Transform fillParent;   //生成用父物件


    private void Start()
    {
        ScrollHelper.InitialData(blockXNum, blockYNum,dataList);
        ScrollHelper.FillScrollRect(buttonPrefab, fillParent, blockXNum, blockYNum, btnList);
        ScrollHelper.SetScrollRectWH(scrollRectReactTran, xSpacing, blockWidth, blockXNum,ySpacing, blockHeight, blockYNum);
        ScrollHelper.SetContentHeight(contentRectTran, scrollRectReactTran, blockYNum, outsideBlockYNum, ySpacing, blockHeight);
    }
}
