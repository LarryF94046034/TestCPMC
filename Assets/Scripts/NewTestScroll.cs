using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewTestScroll : MonoBehaviour
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
    private GameObject buttonPrefab;   //�ͦ�BTN
    [SerializeField]
    private Transform fillParent;   //�ͦ��Τ�����
    [SerializeField]
    private ScrollRect scrollRect;   //SCROLLRECT
    [SerializeField]
    private RectTransform scrollRectReactTran;   //SCROLLRECT RT
    [SerializeField]
    private RectTransform contentRectTran;   //CONTENT RT
    [SerializeField]
    private int allowBlockXNum;   //���X��
    public int AllowBlockXNum { get { return allowBlockXNum; } set { allowBlockXNum = value; } }
    [SerializeField]
    private int allowBlockYNum;  //���Y�C
    [SerializeField]
    private float blockWidth;   //���X��
    [SerializeField]
    private float blockHeight;   //���Y��
    [SerializeField]
    private float allowXSpacing;  //���jX�e
    [SerializeField]
    private float allowYSpacing;  //���jY��
    [SerializeField]
    private int outsideBlockYNum;  //�B�~Y�C

    [SerializeField]
    public List<GameObject> btns;

    [SerializeField]
    private Image horizonHandleImage;
    [SerializeField]
    private Image horizonScrollbarImage;

    [SerializeField]
    public float scrollAmount = 0;

    


    // Start is called before the first frame update
    void Start()
    {
        ScrollHelper.FillScrollRect(buttonPrefab, fillParent, allowBlockXNum, allowBlockYNum + outsideBlockYNum * 2, btns);
        ScrollHelper.SetScrollRectWH(scrollRectReactTran, allowXSpacing, blockWidth, allowBlockXNum, allowYSpacing, blockHeight, allowBlockYNum);
        //ScrollHelper.SetContentHeight(contentRectTran, scrollRectReactTran);
        ScrollHelper.SetScrollRectHandleMidPoint(scrollRect,1.0f);
        ScrollHelper.SetScrollRectHorizontalOne(scrollRect);
        ScrollHelper.CloseHorizontalHandle(horizonHandleImage, horizonScrollbarImage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
