using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XtoZnoYScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Obj;
    //public Vector3 Obb;
    float X;
    float Y;
    float Z;
    private Transform wd;

    public float w = -7.0f;

    [SerializeField] RotateScript To_Plane;

    float MyPlaneY_Now;
    float MyPlaneY_Before;

    float Now;

    void Start()
    {
        Y = Obj.transform.position.y;

        MyPlaneY_Now = 0.0f;
        MyPlaneY_Before = 0.0f;

        Now = Obj.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {

        // Obb = new Vector3(Obj);
        //var xx = transform.TransformPoint(Obb);

        //X = Obb.x;
        //Z = Obb.z;
        X = Obj.transform.position.x;
        Z = Obj.transform.position.z;

        Quaternion Qua = Obj.localRotation;

        Vector3 localPos = Obj.localPosition;

        //this.transform.position = new Vector3(Z,Y,Z);
        //this.transform.position = new Vector3(localPos.z,localPos.y, localPos.z);

        //if (Qua.y > 0.0f)
        //{
        //    Qua.y *= -1.0f;
        //}

        MyPlaneY_Now = To_Plane.Mytransform.transform.rotation.y;

        if (MyPlaneY_Now > MyPlaneY_Before)
        {
            Now++;
        }
        else if (MyPlaneY_Now < MyPlaneY_Before)
        {
            Now--;
        }

        MyPlaneY_Before = MyPlaneY_Now;

        this.transform.rotation = new Quaternion(0, Now, 0, w); 
        //this.transform.position = localPos; //new Vector3(Z, Y, Z);
    }
}
