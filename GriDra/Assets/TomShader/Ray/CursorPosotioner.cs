using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPosotioner : MonoBehaviour
{
    private float defaultPosZ;
    public Transform RayPos;
    private Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        defaultPosZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Transform camera = Camera.main.transform;
        pos = RayPos.transform;

        Ray ray = new Ray(pos.position, pos.rotation * Vector3.forward);
        //RaycastHit hit;

        //if(Physics.Raycast(ray,out hit))
        //{
        //    if(hit.distance <= defaultPosZ)
        //    {
        //        transform.localPosition = new Vector3(0, 0, hit.distance);
        //    }
        //    else
        //    {
        //        transform.localPosition = new Vector3(0, 0, defaultPosZ);
        //    }
        //}

        //Debug.DrawRay(ray.origin,ray.direction,Color.red,10f,true);
    }
}
