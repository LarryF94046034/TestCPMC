using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CHENKAIHSUN
{
    public class RectTransformTool : MonoBehaviour
    {
        public static RectTransformTool Instance;
        private void Awake()
        {
            Instance = this;
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


    }
}

