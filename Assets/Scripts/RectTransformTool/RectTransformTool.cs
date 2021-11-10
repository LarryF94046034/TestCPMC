using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CHENKAIHSUN
{
    public class RectTransformTool : MonoBehaviour
    {   
        static RectTransformTool _instance;
        public static RectTransformTool Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType(typeof(RectTransformTool)) as RectTransformTool;
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("RectTransformTool");
                        _instance = go.AddComponent<RectTransformTool>();
                    }
                }
                return _instance;
            }
        }
        

        public void SetSize(RectTransform rectTran, float x, float y)
        {
            rectTran.sizeDelta = new Vector2(x, y);
        }
        public void SetAnchor(RectTransform rectTran,float minX,float minY,float maxX,float maxY)
        {
            rectTran.anchorMin = new Vector2(minX, minY);
            rectTran.anchorMax = new Vector2(maxX, maxY);
        }

        #region Position Lock
        public void XPosCeilingLock(RectTransform rectTran,float maxX)
        {
            if(rectTran.anchoredPosition.x>=maxX)
            {
                rectTran.anchoredPosition = new Vector2(maxX, rectTran.anchoredPosition.y);
            }
        }
        public void XPosFloorLock(RectTransform rectTran, float minX)
        {
            if (rectTran.anchoredPosition.x <= minX)
            {
                rectTran.anchoredPosition = new Vector2(minX, rectTran.anchoredPosition.y);
            }
        }
        public void YPosCeilingLock(RectTransform rectTran, float maxX)
        {
            if (rectTran.anchoredPosition.y >= maxX)
            {
                rectTran.anchoredPosition = new Vector2(rectTran.anchoredPosition.x, maxX);
            }
        }
        public void YPosFloorLock(RectTransform rectTran, float minX)
        {
            if (rectTran.anchoredPosition.y <= minX)
            {
                rectTran.anchoredPosition = new Vector2(rectTran.anchoredPosition.x, minX);
            }
        }
        #endregion
        #region SetAnchorPosition
        public void SetPosX(RectTransform rectTran, float xPos)
        {
            rectTran.anchoredPosition = new Vector2(xPos, rectTran.anchoredPosition.y);
        }
        public void SetPosY(RectTransform rectTran, float yPos)
        {
            rectTran.anchoredPosition = new Vector2(rectTran.anchoredPosition.x, yPos);
        }
        #endregion

    }
}

