using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoukiScript : MonoBehaviour
{
    // Tracker��Transform
    //[SerializeField] Transform TrackerTransform;

    // Plane��Transform
    //[SerializeField] Transform PlaneTransform;

    // �A�^�b�`���ꂽTo_Sphere��Transform
    //[SerializeField] Transform MyTransform;

    //Quaternion OffSetRotation;
    //Quaternion NewRotate;

    public Transform Box;
    public GameObject Pos;
    public Vector3 Posvec;
    public Vector3 tmp;

    public bool ReSet;

    bool InputKey, BeforeKey;

    // Start is called before the first frame update
    void Start()
    {
        // ��
        Box.transform.position = this.transform.position;

        //OffSetRotation = Quaternion.Inverse(TrackerTransform.transform.rotation) * MyTransform.transform.rotation;
        // ������Quaternion���擾���邽�߂ɁA�t��Quaternion(Inverse)���|����

        // Box.transform.rotation = TrackerTransform.rotation * OffSetRotation;
        //NewRotate = Quaternion.Euler(PlaneTransform.rotation.x * OffSetRotation.x, PlaneTransform.rotation.y * OffSetRotation.y, 0);

        ReSet = true;
    }

    // Update is called once per frame
    void Update()
    {
        Doki(Posvec);
        tmp = new Vector3(0, -Posvec.y, 0);
        Box.position = Posvec + tmp;

        //Box.transform.rotation = PlaneTransform.rotation * OffSetRotation;
    }

    Vector3 Doki(Vector3 x)
    {
        Posvec = this.gameObject.transform.position;
        Vector3 xPoint = transform.TransformPoint(Posvec);

        return xPoint;
    }

}
