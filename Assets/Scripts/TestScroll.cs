using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScroll : MonoBehaviour
{
    public List<GameObject> buttons;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        ScrollHelper.Scroll(parent,buttons,10,28,parent.transform.childCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
