using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseGradient : MonoBehaviour
{
    public Gradient gradient;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRenderObject()
    {
        gradient.ModifyMesh(new VertexHelper());
    }
}
