using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
public class UIBehaviour : MonoBehaviour
{
    private void Awake()
    {
        if (this.gameObject.name[this.gameObject.name.Length - 1] == 'N' && this.gameObject.name[this.gameObject.name.Length - 2] == '_')
        {
            UIBase tmpBase = transform.GetComponentInParent<UIBase>();
            UIManager.Instance.RegistGameObject(tmpBase.name, transform.name, gameObject);    //子控件主動上報進大Dictionary
        }
    }


    public void AddButtonListen(UnityAction action)
    {
        Button tmpBtn = transform.GetComponent<Button>();
        if (tmpBtn != null)
        {
            tmpBtn.onClick.AddListener(action);
        }
    }


    public void AddSliderListen(UnityAction<float> action)
    {
        Slider tmpBtn = transform.GetComponent<Slider>();
        if (tmpBtn != null)
        {
            tmpBtn.onValueChanged.AddListener(action);
        }
    }

    public void AddInputFieldListen(UnityAction<string> action)
    {
        InputField tmpBtn = transform.GetComponent<InputField>();
        if (tmpBtn != null)
        {
            tmpBtn.onEndEdit.AddListener(action);
        }
    }

    public void AddInputFieldEndEditorListen(UnityAction<string> action)
    {
        InputField tmpBtn = transform.GetComponent<InputField>();
        if (tmpBtn != null)
        {
            tmpBtn.onEndEdit.AddListener(action);
        }
    }

    public void AddInputFieldValueChangeListen(UnityAction<string> action)
    {
        InputField tmpBtn = transform.GetComponent<InputField>();
        if (tmpBtn != null)
        {
            tmpBtn.onValueChanged.AddListener(action);
        }
    }

    public void ChangeTextContentListen(string content)
    {
        Text tmpBtn = transform.GetComponent<Text>();
        if (tmpBtn != null)
        {
            tmpBtn.text = content;
        }
    }

    public void ChangeImageListen(Sprite content)
    {
        Image tmpBtn = transform.GetComponent<Image>();
        if (tmpBtn != null)
        {
            tmpBtn.sprite = content;
        }
    }



    //加事件
    public void AddDragInterface(UnityAction<BaseEventData> action)
    {
        //獲取事件系統
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //如果不存在，動態增加
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //事件實體
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //事件類型
        entry.eventID = EventTriggerType.Drag;
        //事件回調
        entry.callback = new EventTrigger.TriggerEvent();
        //添加回調函數
        entry.callback.AddListener(action);
        //監聽事件
        trigger.triggers.Add(entry);

    }
    public void AddOnBeginDrag(UnityAction<BaseEventData> action)
    {
        //獲取事件系統
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //如果不存在，動態增加
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //事件實體
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //事件類型
        entry.eventID = EventTriggerType.BeginDrag;
        //事件回調
        entry.callback = new EventTrigger.TriggerEvent();
        //添加回調函數
        entry.callback.AddListener(action);
        //監聽事件
        trigger.triggers.Add(entry);

    }
    public void AddSelect(UnityAction<BaseEventData> action)
    {
        //獲取事件系統
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //如果不存在，動態增加
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //事件實體
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //事件類型
        entry.eventID = EventTriggerType.Select;
        //事件回調
        entry.callback = new EventTrigger.TriggerEvent();
        //添加回調函數
        entry.callback.AddListener(action);
        //監聽事件
        trigger.triggers.Add(entry);

    }
    public void AddPointerEnter(UnityAction<BaseEventData> action)
    {
        //獲取事件系統
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //如果不存在，動態增加
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //事件實體
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //事件類型
        entry.eventID = EventTriggerType.PointerEnter;
        //事件回調
        entry.callback = new EventTrigger.TriggerEvent();
        //添加回調函數
        entry.callback.AddListener(action);
        //監聽事件
        trigger.triggers.Add(entry);

    }
    public void AddPointerExit(UnityAction<BaseEventData> action)
    {
        //獲取事件系統
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //如果不存在，動態增加
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //事件實體
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //事件類型
        entry.eventID = EventTriggerType.PointerExit;
        //事件回調
        entry.callback = new EventTrigger.TriggerEvent();
        //添加回調函數
        entry.callback.AddListener(action);
        //監聽事件
        trigger.triggers.Add(entry);

    }
    public void AddOnEndDrag(UnityAction<BaseEventData> action)
    {
        //獲取事件系統
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //如果不存在，動態增加
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //事件實體
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //事件類型
        entry.eventID = EventTriggerType.EndDrag;
        //事件回調
        entry.callback = new EventTrigger.TriggerEvent();
        //添加回調函數
        entry.callback.AddListener(action);
        //監聽事件
        trigger.triggers.Add(entry);

    }


    public void AddPointClick(UnityAction<BaseEventData> action)
    {
        //獲取事件系統
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //如果不存在，動態增加
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //事件實體
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //事件類型
        entry.eventID = EventTriggerType.PointerClick;
        //事件回調
        entry.callback = new EventTrigger.TriggerEvent();
        //添加回調函數
        entry.callback.AddListener(action);
        //監聽事件
        trigger.triggers.Add(entry);

    }


    public Image GetImage()
    {
        Image tmpImage = transform.GetComponent<Image>();
        if (tmpImage != null)
        {
            return tmpImage;
        }
        else
        {
            Debug.Log("Image null");
        }
        return null;
    }
    public Slider GetSlider()
    {
        Slider tmpImage = transform.GetComponent<Slider>();
        if (tmpImage != null)
        {
            return tmpImage;
        }
        else
        {
            Debug.Log("Image null");
        }
        return null;

    }

    public TextMeshProUGUI GetTextMeshPro()
    {
        TextMeshProUGUI tmpImage = transform.GetComponent<TextMeshProUGUI>();
        if (tmpImage != null)
        {
            return tmpImage;
        }
        else
        {
            Debug.Log("Image null");
        }
        return null;

    }




}
