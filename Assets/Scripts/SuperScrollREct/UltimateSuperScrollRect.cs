using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UltimateSuperScrollRect : MonoBehaviour
{
    [SerializeField]
    private ScrollRect superScrollRect;   //SCROLLRECT
    [SerializeField]
    private RectTransform superRect;   //CONTENT RT

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
    [SerializeField]
    private GameObject _obj;
    [SerializeField]
    private RectTransform scrollRectTran;

    [SerializeField]
    private List<GameObject> item;
    [SerializeField]
    private int lastIndex = 0;
    [SerializeField]
    private int firstIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        superScrollRect = GetComponent<ScrollRect>();//获取到ScrollerView上的ScrollRect
        superRect = superScrollRect.content.transform.GetComponent<RectTransform>();//获取到ScrollRect上的content的RectTransform组件

        SetContentWidth();
        InsCountitemWidth();
        //superScrollRect.onValueChanged.AddListener((Vector2 vec) => OnScrollMoveWidth(vec));
    }

    // Update is called once per frame
    void Update()
    {
        //OnScrollMoveWidth();
        
    }


    public void SetContentWidth()  //左對齊
    {
        //transform.GetComponent<RectTransform>().sizeDelta = new Vector2(itemWidth * maxItemNum / queue, (_obj.GetComponent<RectTransform>().sizeDelta.y + 20) * queue);  //設SCROLL RT SIZE
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Ceil(maxItemNum / queue)*itemWidth, itemHeight * queue);  //設SCROLL RT SIZE

        //superRect.sizeDelta = new Vector2(itemNum * itemWidth / queue, 0);
        superRect.sizeDelta = new Vector2((Mathf.Ceil(itemNum / queue) * itemWidth), 0);  //設 CONTENT SIZE
        Debug.Log(Mathf.Ceil(itemNum / queue));

        superRect.anchorMin = new Vector2(0, 0);   //設CONTENT ANCHOR
        superRect.anchorMax = new Vector2(0, 1);
    }

    public void InsCountitemWidth()
    {
        int needItemNum = Mathf.Clamp((int)maxItemNum, 0, (int)itemNum);

        //for (int j = 0; j < needItemNum / queue + 1; j++)
        for (int j = 0; j < (Mathf.Ceil(itemNum / queue)); j++)
        {
            for (int i = 0; i < queue; i++)
            {

                //生成
                GameObject obj = Instantiate(_obj, superRect);
                //取名和赋值
                obj.name = (j * queue + i).ToString();
                obj.transform.Find("Text").GetComponent<Text>().text = obj.name;
                //设定锚点以及锚点位置
                RectTransform _rect = obj.transform.GetComponent<RectTransform>();
                _rect.pivot = new Vector2(0, 1);
                _rect.anchorMin = new Vector2(0, 1);
                _rect.anchorMax = new Vector2(0, 1);
                _rect.anchoredPosition = new Vector2(j * itemWidth, -itemHeight * i);
                //将游戏对象按顺序加到显示list当中
                item.Add(obj);

            }
        }
        //设置最后的索引
        lastIndex = (int)needItemNum - 1 + (int)queue;
    }



    private void OnScrollMoveWidth()
    {
        Debug.Log("ANCHORPOS" + Mathf.Abs(superRect.anchoredPosition.x));
        Debug.Log("INDEX" + itemWidth * (firstIndex / queue));
        Debug.Log(lastIndex);
        Debug.Log("TRUE" + (Mathf.Abs(superRect.anchoredPosition.x) > itemWidth * (firstIndex / queue) && lastIndex < itemNum - 1));
        ////从左往右
        //while (Mathf.Abs(superRect.anchoredPosition.x) > itemWidth * (firstIndex / queue) && lastIndex < itemNum - 1)
        //{
        //    for (int i = 0; i < queue; i++)
        //    {
        //        GameObject _first = item[0];
        //        RectTransform _firstRect = _first.GetComponent<RectTransform>();
        //        item.RemoveAt(0);
        //        item.Add(_first);
        //        _firstRect.anchoredPosition = new Vector2(((lastIndex + 1) / queue) * itemWidth, _firstRect.anchoredPosition.y);
        //        firstIndex++;
        //        lastIndex++;

        //        ////修改显示
        //        //_first.name = lastIndex.ToString();
        //        //_first.transform.Find("Text").GetComponent<Text>().text = _first.name;

        //    }
        //}
        //从右往左
        while (Mathf.Abs(superRect.anchoredPosition.x) < itemWidth * firstIndex / queue && firstIndex > 0)
        {
            for (int i = 0; i < queue; i++)
            {
                GameObject _last = item[item.Count - 1];
                RectTransform _lastRect = _last.GetComponent<RectTransform>();
                item.RemoveAt(item.Count - 1);
                item.Insert(0, _last);
                _lastRect.anchoredPosition = new Vector2(((firstIndex - 1) / queue) * itemWidth, _lastRect.anchoredPosition.y);

                firstIndex--;
                lastIndex--;
                //修改显示
                _last.name = firstIndex.ToString();
                _last.transform.Find("Text").GetComponent<Text>().text = _last.name;
            }

        }
    }
}
