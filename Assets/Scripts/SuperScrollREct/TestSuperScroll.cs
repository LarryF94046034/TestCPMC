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
    private float xSpacing;  //���jX�e
    [SerializeField]
    private float ySpacing;  //���jY��
    [SerializeField]
    private int blockXNum;   //���X��
    [SerializeField]
    private int blockYNum;   //���X��
    [SerializeField]
    private int outsideBlockYNum;  //�B�~Y�C

    [Header("List")]
    [SerializeField]
    private List<int> dataList;   //���LIST
    [SerializeField]
    public List<GameObject> btnList;  //BTN LIST


    [Header("Instan")]
    [SerializeField]
    private GameObject buttonPrefab;   //�ͦ�BTN
    [SerializeField]
    private Transform fillParent;   //�ͦ��Τ�����


    private void Start()
    {
        ScrollHelper.InitialData(blockXNum, blockYNum,dataList);
        ScrollHelper.FillScrollRect(buttonPrefab, fillParent, blockXNum, blockYNum, btnList);
        ScrollHelper.SetScrollRectWH(scrollRectReactTran, xSpacing, blockWidth, blockXNum,ySpacing, blockHeight, blockYNum);
        ScrollHelper.SetContentHeight(contentRectTran, scrollRectReactTran, blockYNum, outsideBlockYNum, ySpacing, blockHeight);
    }
}
