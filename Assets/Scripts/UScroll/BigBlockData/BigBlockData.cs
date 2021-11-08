using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBlockData : MonoBehaviour
{
    [SerializeField]
    private int index = 0;

    public int Index
    {
        set
        {
            index = value;
        }
        get
        {
            return index;
        }
    }
}
