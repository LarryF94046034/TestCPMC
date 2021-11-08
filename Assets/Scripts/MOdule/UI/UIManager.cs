using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    Dictionary<string, Dictionary<string, GameObject>> allWedgate;    //string->string的gameObject，兩層
    private void Awake()
    {
        Instance = this;
        allWedgate = new Dictionary<string, Dictionary<string, GameObject>>();
    }

    public void RegistGameObject(string panelName, string wedageName, GameObject obj)  //註冊子控件
    {
        if (!allWedgate.ContainsKey(panelName))
        {
            allWedgate[panelName] = new Dictionary<string, GameObject>();
        }

        if (!allWedgate[panelName].ContainsKey(wedageName))
        {
            allWedgate[panelName].Add(wedageName, obj);
        }
    }


    public GameObject GetGameObject(string panelName, string wedegateName) //獲取某一panel下的子控件，小D，取得第二層的string的gameObject(all[panelName][wedegateName])=gameObject)
    {
        if (allWedgate.ContainsKey(panelName))
        {
            return allWedgate[panelName][wedegateName];
        }

        return null;
    }


    public void UnRegistGameObject(string panelName, string widegeName)
    {
        if (allWedgate[panelName].ContainsKey(widegeName))
        {
            allWedgate[panelName].Remove(widegeName);
        }
    }

    public void UnRegistPanel(string panelName)
    {
        if (allWedgate.ContainsKey(panelName))
        {
            if (allWedgate[panelName] != null)
            {
                allWedgate[panelName].Clear();
                allWedgate[panelName] = null;
            }
        }
    }
    // public UIBase FindPanelBase(string panelName)
    // {
    //     GameObject tmpObj=UIManager.Instance.GetGameObject("PlayerSkill_N","PlayerSkill_N");
    //     UIBase tmpCtl=tmpObj.GetComponent<UIBase>();
    //     return tmpCtl;
    // }
    public UIBase FindPanelBase(string panelName)
    {
        GameObject tmpObj = UIManager.Instance.GetGameObject(panelName, panelName);
        UIBase tmpCtl = tmpObj.GetComponent<UIBase>();
        return tmpCtl;
    }
}
