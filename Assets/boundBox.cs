using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundBox : MonoBehaviour
{
    DragonBones.BoundingBoxData bound;
    PolygonBoundingBoxData polygon;
    UnityArmatureComponent ani;
    List<float> a = new List<float> { };
    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<UnityArmatureComponent>();
        polygon = (PolygonBoundingBoxData)ani.armature.GetSlot("shangbanshen_boundingBox").boundingBoxData;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        a = polygon.vertices;

        foreach (var i in a)
        {
            Debug.Log(i);
        }
    }
}
