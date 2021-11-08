using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class UIBase : MonoBehaviour
{
    private void Awake()
    {
        Transform[] allChildren = transform.GetComponentsInChildren<Transform>();  //找到Panel下所有子控件
        for (int i = 0; i < allChildren.Length; i++)
        {
            if (allChildren[i].name.EndsWith("N"))   //Button_N or ..._N加上UIBEHAVIOUR
            {
                allChildren[i].gameObject.AddComponent<UIBehaviour>();
            }
        }

    }

    public void AddUIBehaviour(GameObject tmpGameObject)
    {
        tmpGameObject.AddComponent<UIBehaviour>();
    }

    public void AddUIBehaviours(List<GameObject> tmpGameObjects)
    {
        foreach (GameObject tmpGameObject in tmpGameObjects)
        {
            tmpGameObject.AddComponent<UIBehaviour>();
        }
    }


    public GameObject GetWedgate(string widegateName)
    {
        return UIManager.Instance.GetGameObject(transform.name, widegateName);

    }


    public UIBehaviour GetBehaviour(string widageName)
    {
        GameObject tmpObj = GetWedgate(widageName);
        if (tmpObj != null)
        {
            return tmpObj.GetComponent<UIBehaviour>();

        }
        return null;
    }


    public void AddPointClick(string widageName, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widageName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddPointClick(action);
        }
    }

    public void AddPointClickG(GameObject tmpGameObject, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = tmpGameObject.GetComponent<UIBehaviour>();
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddPointClick(action);
        }
    }
    public void AddPointerExitG(GameObject tmpGameObject, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = tmpGameObject.GetComponent<UIBehaviour>();
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddPointerExit(action);
        }
    }


    public void AddPointerEnterG(GameObject tmpGameObject, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = tmpGameObject.GetComponent<UIBehaviour>();
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddPointerEnter(action);
        }
    }

    public void AddPointerEnter(string widageName, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widageName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddPointerEnter(action);
        }
    }
    public void AddPointClickGameObject(string widageName, UnityAction<BaseEventData> action)        //二次賦予
    {
        GameObject tmpGameObject = FindChildWithName(widageName);
        UIBehaviour tmpBehaviour = tmpGameObject.GetComponent<UIBehaviour>();
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddPointClick(action);
        }
    }

    public GameObject FindChildWithName(string widageName)
    {
        List<GameObject> tmpChildList = new List<GameObject>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            tmpChildList.Add(this.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < tmpChildList.Count; i++)
        {
            if (tmpChildList[i].name == widageName)
            {
                return tmpChildList[i];

            }
        }
        return null;
    }


    private void OnDestroy()
    {         //換場景自我摧毀時字典內自動卸載

        UIManager.Instance.UnRegistPanel(transform.name);

    }




    public void AddDrag(string widageName, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widageName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddDragInterface(action);
        }
    }
    public void AddDragG(GameObject tmpGameObject, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = tmpGameObject.GetComponent<UIBehaviour>();
        //如果不存在，動態增加
        if (tmpBehaviour == null)
        {
            tmpBehaviour = tmpGameObject.AddComponent<UIBehaviour>();
        }
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddDragInterface(action);
        }
    }
    public void AddBeginDrag(string widageName, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widageName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddOnBeginDrag(action);
        }
    }
    public void AddBeginDragG(GameObject tmpGameObject, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = tmpGameObject.GetComponent<UIBehaviour>();
        //如果不存在，動態增加
        if (tmpBehaviour == null)
        {
            tmpBehaviour = tmpGameObject.AddComponent<UIBehaviour>();
        }
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddOnBeginDrag(action);
        }
    }

    public void AddEndDrag(string widageName, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widageName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddOnEndDrag(action);
        }
    }

    public void AddEndDragG(GameObject tmpGameObject, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = tmpGameObject.GetComponent<UIBehaviour>();
        //如果不存在，動態增加
        if (tmpBehaviour == null)
        {
            tmpBehaviour = tmpGameObject.AddComponent<UIBehaviour>();
        }
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddOnEndDrag(action);
        }
    }



    public void AddSelect(string widageName, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widageName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddSelect(action);
        }
    }


    public void AddPointerExit(string widageName, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widageName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddPointerExit(action);
        }
    }






    public Image GetImage(string widageName)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widageName);
        if (tmpBehaviour != null)
        {
            return tmpBehaviour.GetImage();
        }
        else
        {
            Debug.Log("GetImage null");
        }
        return null;
    }
    public Slider GetSlider(string widageName)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widageName);
        if (tmpBehaviour != null)
        {
            return tmpBehaviour.GetSlider();
        }
        else
        {
            Debug.Log("GetSlider null");
        }
        return null;
    }
    public Transform GetTransform(string widageName)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widageName);
        if (tmpBehaviour != null)
        {
            return tmpBehaviour.transform;
        }
        else
        {
            Debug.Log("GetTransform null");
        }
        return null;
    }


    public TextMeshProUGUI GetTextMeshPro(string widageName)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widageName);
        if (tmpBehaviour != null)
        {
            return tmpBehaviour.GetTextMeshPro();
        }
        else
        {
            Debug.Log("GetTMP null");
        }
        return null;
    }



    public void AddButtonListen(string widageName, UnityAction action)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widageName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddButtonListen(action);
        }
    }



}
