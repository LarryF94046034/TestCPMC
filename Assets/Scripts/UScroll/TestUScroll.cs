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
    private GameObject buttonPrefab;   //�ͦ�BTN
    [SerializeField]
    private GameObject rowPrefab;   //�ͦ�ROW


    [Header("Transform")]
    [SerializeField]
    private Transform fillParent;   //�ͦ��Τ�����A�ͦ��b�o�U��
    [SerializeField]
    private Transform rowParent;   //�ͦ��Τ�����A�ͦ��b�o�U��
    [Header("RectTransform")]
    [SerializeField]
    private RectTransform backgroundTran;   //�I�� RT
    [SerializeField]
    private RectTransform verticalBarTran;   //��BAR RT
    [SerializeField]
    private RectTransform maskTran;   //�B�n RT
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
    private int btnCount;   //�`�@�h��Btn
    [SerializeField]
    private int allowBlockXNum;   //���X��A��V�AX��        BLOCK
    [SerializeField]
    private int allowBlockYNum;  //���Y�C�A���V�AY�ӡA��ܰ��`�@ allowBlockYNum�C
    [SerializeField]
    private int outsideBlockYNum;  //�B�~Y�C�A������`�@ allowBlockYNum+outsideBlockYNum�C
    [SerializeField]
    private int additionalBlockYNum;  //�B�~Y�C�A��ܰ�+��s���`�@ allowBlockYNum(��)+additionalBlockYNum�C(��)
    [SerializeField]
    private float blockXWidth;   //���X��
    [SerializeField]
    private float blockYHeight;   //���Y��
    [SerializeField]
    private float allowXSpacing;  //���jX�e
    [SerializeField]
    private float allowYSpacing;  //���jY��

    [SerializeField]
    private float barXLength;  //��BAR X ��                  BAR

    [SerializeField]
    public int nowIndex = 0;    //�ثe��Ʀ�m               INDEX
    [SerializeField]
    private float initialYPos=200;  //�Ĥ@�氪��
    

    [SerializeField]
    public Vector2 scrollRectValueChange = new Vector2();    //����ScrollRect ValueChange


    [Header("Buffer")]
    [SerializeField]
    private List<GameObject> btnList;   //�Ҧ�ROW Button GO
    [SerializeField]
    private List<GameObject> additionalBtnList;   //�B�~ROW1 Button GO
    [SerializeField]
    private List<GameObject> additionalBtn1List;   //�B�~ROW2 Button GO
    [SerializeField]
    private List<int> dataList = new List<int>();   //���LIST INT
    [SerializeField]
    private List<GameObject> parentList = new List<GameObject>();    //ROW ��
    [SerializeField]
    private List<GameObject> additionalParentList = new List<GameObject>();  //�B�~ ROW1 ��
    [SerializeField]
    private List<GameObject> additionalParent1List = new List<GameObject>();  //�B�~ ROW2 ��
    [SerializeField]
    private List<RectTransform> rowRectTranList = new List<RectTransform>();   //���ROW�� RectTran
    [SerializeField]
    private List<RectTransform> additionalRowRectTranList = new List<RectTransform>();   //�B�~ ROW1�� RectTran
    [SerializeField]
    private List<RectTransform> additionalRowRectTran1List = new List<RectTransform>();   //�B�~ ROW2�� RectTran

    [SerializeField]
    private List<Transform> bigBlockList = new List<Transform>();   //3�j���

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
    private float positiveGap=0;   //�W�L���� ���w�q Ĳ�o
    [SerializeField]
    private float negativeGap=0;   //�W�L�t�� ���w�q Ĳ�o

    [Header("Scrollbar")]
    [SerializeField]
    private Scrollbar verticalBar;   //�W�L���� ���w�q Ĳ�o


    #region �s���:�j�wImage(Drag�Z���p��) + ScrollBar +�W���w���\��UScroll //DRAG IMAGE EVENT dragImage//DRAG IMAGE EVENT endDragEvent
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
        UScrollHelper.InitialData(allowBlockXNum, allowBlockYNum + additionalBlockYNum*2, btnCount, dataList);  //�ͦ����

        //UScrollHelper.InitialGridWidthGridHeightSetGridPos(parentList,rowPrefab, rowParent, allowBlockXNum, allowBlockYNum, allowXSpacing, allowYSpacing, blockXWidth, blockYHeight,initialYPos);
        UScrollHelper.InstanPrefab(rowPrefab, rowParent, parentList, rowRectTranList, allowBlockYNum);  //�ͦ�ALLOW ROW
        UScrollHelper.SetRowDeltaSize(rowRectTranList, allowBlockXNum, allowBlockYNum, blockXWidth, blockYHeight, allowXSpacing);   //�]�wALLOW ROW SIZE
        UScrollHelper.SetRowAnchorPos(rowRectTranList, allowBlockYNum, blockYHeight, allowYSpacing, initialYPos);   //�]�wALLOW ROW POS
        UScrollHelper.AddButton(buttonPrefab, fillParent, allowBlockXNum, allowBlockYNum, btnList, parentList);    //�ͦ�ALLOW ROW BTN
        UScrollHelper.SetButtonData(btnList, dataList,0,btnList.Count);   //�]�wALLOE ROW ���
        UScrollHelper.SetBigBlockParent(parentList, bigBlockList[0]);
        

        UScrollHelper.InstanPrefab(rowPrefab, rowParent, additionalParentList, additionalRowRectTranList, additionalBlockYNum);  //�ͦ�ADDITION ROW
        UScrollHelper.SetRowDeltaSize(additionalRowRectTranList, allowBlockXNum, additionalBlockYNum, blockXWidth, blockYHeight, allowXSpacing);   //�]�wADDITION ROW SIZE
        //UScrollHelper.SetRowAnchorPos(additionalRowRectTranList, additionalBlockYNum, blockYHeight, allowYSpacing, (initialYPos-allowBlockYNum*(blockYHeight+allowYSpacing)));   //�]�wADDITION ROW POS
        UScrollHelper.SetRowAnchorPos(additionalRowRectTranList, additionalBlockYNum, blockYHeight, allowYSpacing, initialYPos);   //�]�wALLOW ROW POS
        UScrollHelper.AddButton(buttonPrefab, fillParent, allowBlockXNum, additionalBlockYNum, additionalBtnList, additionalParentList);    //�ͦ�ADDITION BTN
        UScrollHelper.SetButtonData(additionalBtnList, dataList,btnList.Count+0, btnList.Count+additionalBtnList.Count);   //�]�wADDITION ROW ���   additionalList�W��btnList����
        UScrollHelper.SetBigBlockParent(additionalParentList, bigBlockList[1]);
        UScrollHelper.SetBigBlockPos(bigBlockList, 1, additionalBlockYNum, blockYHeight, allowYSpacing, 0);

        UScrollHelper.InstanPrefab(rowPrefab, rowParent, additionalParent1List, additionalRowRectTran1List, additionalBlockYNum);  //�ͦ�ADDITION ROW
        UScrollHelper.SetRowDeltaSize(additionalRowRectTran1List, allowBlockXNum, additionalBlockYNum, blockXWidth, blockYHeight, allowXSpacing);   //�]�wADDITION ROW SIZE
        //UScrollHelper.SetRowAnchorPos(additionalRowRectTran1List, additionalBlockYNum, blockYHeight, allowYSpacing, (initialYPos - 2*allowBlockYNum * (blockYHeight + allowYSpacing)));   //�]�wADDITION ROW POS
        UScrollHelper.SetRowAnchorPos(additionalRowRectTran1List, additionalBlockYNum, blockYHeight, allowYSpacing,initialYPos);   //�]�wALLOW ROW POS
        UScrollHelper.AddButton(buttonPrefab, fillParent, allowBlockXNum, additionalBlockYNum, additionalBtn1List, additionalParent1List);    //�ͦ�ADDITION BTN
        UScrollHelper.SetButtonData(additionalBtn1List, dataList, btnList.Count + additionalBtn1List.Count, btnList.Count + 2*additionalBtn1List.Count);   //�]�wADDITION ROW ���   additionalList�W��btnList����
        UScrollHelper.SetBigBlockParent(additionalParent1List, bigBlockList[2]);
        UScrollHelper.SetBigBlockPos(bigBlockList, 2, additionalBlockYNum, blockYHeight, allowYSpacing, 0);


        UScrollHelper.SetBackgroundAdaptive(maskTran, allowBlockXNum, allowBlockYNum, blockXWidth, blockYHeight, allowXSpacing, allowYSpacing);  //�վ�UI�j�p
        
        //UScrollHelper.SetVerticalBarAdaptive(verticalBarTran,barXLength,allowBlockYNum, blockYHeight, allowYSpacing);   //��BAR �۾A��
        //UScrollHelper.SetVerticalBarPosition(verticalBarTran, (allowBlockXNum * blockXWidth + (allowBlockXNum + 1) * allowXSpacing)/*BACKGROUND�e*/, barXLength);   //��BAR X�y�г]�w

        //UScrollHelper.StartCalculateDrag(dragImage,slider,4000,0.3f,6.0f);  //�j�w�p��DRAG�Z���ƥ�

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
