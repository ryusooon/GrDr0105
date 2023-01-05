using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] public Transform Mytransform;
    // Plane��Transform���i�[

    [SerializeField] Transform Trackertransform;
    // Tracker��Transform���i�[

    [SerializeField] public Quaternion OffSetRotation;

    // Start is called before the first frame update
    void Start()
    {
        OffSetRotation = Quaternion.Inverse(Trackertransform.transform.rotation) * Mytransform.transform.rotation;
        // ������Quaternion���擾���邽�߂ɁA�t��Quaternion(Inverse)���|����

    }


    // Update is called once per frame
    void Update()
    {
        Mytransform.transform.rotation = Trackertransform.rotation * OffSetRotation;
        // Plane��Tracker��rotation��rotation�ƍ�����Quaternion���|����

        //Debug.Log("x:" + Mytransform.transform.rotation.x.ToString());
        //Debug.Log("y:" + Mytransform.transform.rotation.y.ToString());
        //Debug.Log("z:" + Mytransform.transform.rotation.z.ToString());

    }

}
