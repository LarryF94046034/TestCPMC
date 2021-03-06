using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/Gradient")]
public class Gradient : BaseMeshEffect
{
    

    //[SerializeField]
    //private Color32
    //    topColor = Color.white;
    //[SerializeField]
    //private Color32
    //    bottomColor = Color.black;

    //public override void ModifyMesh(Mesh mesh)
    //{
    //    if (!IsActive())
    //    {
    //        return;
    //    }

    //    Vector3[] vertexList = mesh.vertices;
    //    int count = mesh.vertexCount;
    //    if (count > 0)
    //    {
    //        float bottomY = vertexList[0].y;
    //        float topY = vertexList[0].y;

    //        for (int i = 1; i < count; i++)
    //        {
    //            float y = vertexList[i].y;
    //            if (y > topY)
    //            {
    //                topY = y;
    //            }
    //            else if (y < bottomY)
    //            {
    //                bottomY = y;
    //            }
    //        }
    //        List<Color32> colors = new List<Color32>();
    //        float uiElementHeight = topY - bottomY;
    //        for (int i = 0; i < count; i++)
    //        {
    //            colors.Add(Color32.Lerp(bottomColor, topColor, (vertexList[i].y - bottomY) / uiElementHeight));
    //        }
    //        mesh.SetColors(colors);
    //    }
    //}






    [SerializeField]
    private Color32 topColor = Color.white;
    [SerializeField]
    private Color32 bottomColor = Color.black;

    public override void ModifyMesh(VertexHelper vh)
    {
        List<UIVertex> vertexList = new List<UIVertex>();
        vh.GetUIVertexStream(vertexList);

        if (!IsActive())
        {
            return;
        }

        int count = vertexList.Count;
        if (count > 0)
        {
            float bottomY = vertexList[0].position.y;
            float topY = vertexList[0].position.y;

            for (int i = 1; i < count; i++)
            {
                float y = vertexList[i].position.y;
                if (y > topY)
                {
                    topY = y;
                }
                else if (y < bottomY)
                {
                    bottomY = y;
                }
            }

            float uiElementHeight = topY - bottomY;

            for (int i = 0; i < count; i++)
            {
                UIVertex uiVertex = vertexList[i];
                uiVertex.color = Color32.Lerp(bottomColor, topColor, (uiVertex.position.y - bottomY) / uiElementHeight);
                vertexList[i] = uiVertex;
            }
        }
    }
}
