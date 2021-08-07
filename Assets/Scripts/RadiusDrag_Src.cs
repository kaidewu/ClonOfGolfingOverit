using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusDrag_Src : MonoBehaviour
{
     SphereCollider sc;
     float radiusDrag;
    Vector3 endPointDrag;
    // Start is called before the first frame update
    public void Start()
    {
        sc = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndPointDrag()
    {
        radiusDrag = sc.radius + sc.radius;
        endPointDrag = new Vector3(radiusDrag, radiusDrag, radiusDrag);
    }
}
