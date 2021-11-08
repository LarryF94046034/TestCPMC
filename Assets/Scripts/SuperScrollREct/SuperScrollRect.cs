using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperScrollRect : MonoBehaviour
{
    [SerializeField]
    private ScrollRect scrollRect;   
    [SerializeField]
    private RectTransform superRect;

    [SerializeField]
    private int itemNum;
    [SerializeField]
    private float itemWidth;
    [SerializeField]
    private float itemHeight;
    [SerializeField]
    private int maxItemNum;
    [SerializeField]
    private int queue;
    [SerializeField]
    private GameObject _obj;
    [SerializeField]
    private RectTransform scrollRectTran;

    [SerializeField]
    private List<GameObject> item;
    [SerializeField]
    private int lastIndex=0;
    [SerializeField]
    private int firstIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetContentWidth()  //左對齊
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(itemWidth * maxItemNum / queue, (_obj.GetComponent<RectTransform>().sizeDelta.y + 20) * queue);
        superRect.sizeDelta = new Vector2(itemNum * itemWidth / queue, 0);
        superRect.anchorMin = new Vector2(0, 0);
        superRect.anchorMax = new Vector2(0, 1);
    }

    public void InsCountitemWidth()
    {
        int needItemNum = Mathf.Clamp(maxItemNum, 0, itemNum);
        for (int j = 0; j < needItemNum / queue + 1; j++)
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
        lastIndex = needItemNum - 1 + queue;
    }


    private void OnScrollMoveWidth(Vector2 pVec)
    {
        //从左往右
        while (Mathf.Abs(superRect.anchoredPosition.x) > itemWidth * (firstIndex / queue) && lastIndex < itemNum - 1)
        {
            for (int i = 0; i < queue; i++)
            {
                GameObject _first = item[0];
                RectTransform _firstRect = _first.GetComponent<RectTransform>();
                item.RemoveAt(0);
                item.Add(_first);
                _firstRect.anchoredPosition = new Vector2(((lastIndex + 1) / queue) * itemWidth, _firstRect.anchoredPosition.y);
                firstIndex++;
                lastIndex++;
                //修改显示
                _first.name = lastIndex.ToString();
                _first.transform.Find("Text").GetComponent<Text>().text = _first.name;

            }
        }
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
