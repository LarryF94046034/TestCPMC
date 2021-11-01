using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    Text buttonText;
    // Start is called before the first frame update
    void Start()
    {
        // buttonText=this.gameObject.transform.GetChild(0).GetComponent<Text>();
        // buttonText.text="Button"+this.gameObject.transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("SetText")]
    public void SetText()
    {
        buttonText=this.gameObject.transform.GetChild(0).GetComponent<Text>();
        buttonText.text="Button"+this.gameObject.transform.GetSiblingIndex();
    }
}
