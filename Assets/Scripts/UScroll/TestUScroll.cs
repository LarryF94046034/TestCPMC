using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUScroll : MonoBehaviour
{
    public UScrollHelper UScrollHelper;

    [Header("PREFAB")]
    [SerializeField]
    private GameObject buttonPrefab;   //�ͦ�BTN
    [Header("Transform")]
    [SerializeField]
    private Transform fillParent;   //�ͦ��Τ�����A�ͦ��b�o�U��
    [Header("RectTransform")]
    [SerializeField]
    private RectTransform backgroundTran;   //�I�� RT
    [SerializeField]
    private RectTransform verticalBarTran;   //��BAR RT
    [Header("Input")]
    [SerializeField]
    private int btnCount;   //�`�@�h��Btn
    [SerializeField]
    private int allowBlockXNum;   //���X��A��V�AX��        BLOCK
    [SerializeField]
    private int allowBlockYNum;  //���Y�C�A���V�AY��
    [SerializeField]
    private int outsideBlockYNum;  //�B�~Y�C
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


    [Header("Buffer")]
    [SerializeField]
    private List<GameObject> btnList;   //�Ҧ�Button GO
    [SerializeField]
    private List<int> dataList = new List<int>();   //���LIST INT

    [Header("ScrollAmount")]
    [SerializeField]
    public float scrollAmount = 0;
    [SerializeField]
    public float positiveBuffer = 0;
    [SerializeField]
    public float negativeBuffer = 0;

    [Header("NegativeGap")]
    [SerializeField]
    private float positiveGap=0;   //�W�L���� ���w�q Ĳ�o
    [SerializeField]
    private float negativeGap=0;   //�W�L�t�� ���w�q Ĳ�o

    [Header("Scrollbar")]
    [SerializeField]
    private Scrollbar verticalBar;   //�W�L���� ���w�q Ĳ�o



    // Start is called before the first frame update
    void Start()
    {
        UScrollHelper.InitialData(allowBlockXNum, allowBlockYNum + outsideBlockYNum * 2,btnCount, dataList);  //�ͦ����
        UScrollHelper.AddButton(buttonPrefab, fillParent, allowBlockXNum, allowBlockYNum, btnList);    //�ͦ�BTN
        UScrollHelper.SetBackgroundAdaptive(backgroundTran, allowBlockXNum, allowBlockYNum, blockXWidth, blockYHeight, allowXSpacing, allowYSpacing);  //�վ�UI�j�p
        UScrollHelper.SetVerticalBarAdaptive(verticalBarTran,barXLength,allowBlockYNum, blockYHeight, allowYSpacing);   //��BAR �۾A��
        UScrollHelper.SetVerticalBarPosition(verticalBarTran, (allowBlockXNum * blockXWidth + (allowBlockXNum + 1) * allowXSpacing)/*BACKGROUND�e*/, barXLength);   //��BAR X�y�г]�w
    }

    // Update is called once per frame
    void Update()
    {
        //UScrollHelper.AddIndexUpdateData(ref negativeBuffer, negativeGap, ref nowIndex, allowBlockXNum, allowBlockYNum, dataList,btnList);    // �U����sDATA
        //UScrollHelper.MinusIndexUpdateData(ref positiveBuffer, positiveGap, ref nowIndex, allowBlockXNum, allowBlockYNum, dataList,btnList);  //�W����sDATA
        
        //UScrollHelper.UpdateDataByBar(btnList, dataList,nowIndex, allowBlockXNum, allowBlockYNum, verticalBar.value);
    }

    public void UpdateDataByBarOnScroll()
    {
        UScrollHelper.UpdateDataByBar(btnList, dataList, nowIndex, allowBlockXNum, allowBlockYNum, verticalBar.value);
    }
}
