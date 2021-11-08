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
            UIManager.Instance.RegistGameObject(tmpBase.name, transform.name, gameObject);    //�l����D�ʤW���i�jDictionary
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



    //�[�ƥ�
    public void AddDragInterface(UnityAction<BaseEventData> action)
    {
        //����ƥ�t��
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //�p�G���s�b�A�ʺA�W�[
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //�ƥ����
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //�ƥ�����
        entry.eventID = EventTriggerType.Drag;
        //�ƥ�^��
        entry.callback = new EventTrigger.TriggerEvent();
        //�K�[�^�ը��
        entry.callback.AddListener(action);
        //��ť�ƥ�
        trigger.triggers.Add(entry);

    }
    public void AddOnBeginDrag(UnityAction<BaseEventData> action)
    {
        //����ƥ�t��
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //�p�G���s�b�A�ʺA�W�[
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //�ƥ����
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //�ƥ�����
        entry.eventID = EventTriggerType.BeginDrag;
        //�ƥ�^��
        entry.callback = new EventTrigger.TriggerEvent();
        //�K�[�^�ը��
        entry.callback.AddListener(action);
        //��ť�ƥ�
        trigger.triggers.Add(entry);

    }
    public void AddSelect(UnityAction<BaseEventData> action)
    {
        //����ƥ�t��
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //�p�G���s�b�A�ʺA�W�[
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //�ƥ����
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //�ƥ�����
        entry.eventID = EventTriggerType.Select;
        //�ƥ�^��
        entry.callback = new EventTrigger.TriggerEvent();
        //�K�[�^�ը��
        entry.callback.AddListener(action);
        //��ť�ƥ�
        trigger.triggers.Add(entry);

    }
    public void AddPointerEnter(UnityAction<BaseEventData> action)
    {
        //����ƥ�t��
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //�p�G���s�b�A�ʺA�W�[
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //�ƥ����
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //�ƥ�����
        entry.eventID = EventTriggerType.PointerEnter;
        //�ƥ�^��
        entry.callback = new EventTrigger.TriggerEvent();
        //�K�[�^�ը��
        entry.callback.AddListener(action);
        //��ť�ƥ�
        trigger.triggers.Add(entry);

    }
    public void AddPointerExit(UnityAction<BaseEventData> action)
    {
        //����ƥ�t��
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //�p�G���s�b�A�ʺA�W�[
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //�ƥ����
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //�ƥ�����
        entry.eventID = EventTriggerType.PointerExit;
        //�ƥ�^��
        entry.callback = new EventTrigger.TriggerEvent();
        //�K�[�^�ը��
        entry.callback.AddListener(action);
        //��ť�ƥ�
        trigger.triggers.Add(entry);

    }
    public void AddOnEndDrag(UnityAction<BaseEventData> action)
    {
        //����ƥ�t��
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //�p�G���s�b�A�ʺA�W�[
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //�ƥ����
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //�ƥ�����
        entry.eventID = EventTriggerType.EndDrag;
        //�ƥ�^��
        entry.callback = new EventTrigger.TriggerEvent();
        //�K�[�^�ը��
        entry.callback.AddListener(action);
        //��ť�ƥ�
        trigger.triggers.Add(entry);

    }


    public void AddPointClick(UnityAction<BaseEventData> action)
    {
        //����ƥ�t��
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //�p�G���s�b�A�ʺA�W�[
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();

        }
        //�ƥ����
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //�ƥ�����
        entry.eventID = EventTriggerType.PointerClick;
        //�ƥ�^��
        entry.callback = new EventTrigger.TriggerEvent();
        //�K�[�^�ը��
        entry.callback.AddListener(action);
        //��ť�ƥ�
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
