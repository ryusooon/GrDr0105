using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] public Transform Mytransform;
    // PlaneのTransformを格納

    [SerializeField] Transform Trackertransform;
    // TrackerのTransformを格納

    [SerializeField] public Quaternion OffSetRotation;

    // Start is called before the first frame update
    void Start()
    {
        OffSetRotation = Quaternion.Inverse(Trackertransform.transform.rotation) * Mytransform.transform.rotation;
        // 差分のQuaternionを取得するために、逆のQuaternion(Inverse)を掛ける

    }


    // Update is called once per frame
    void Update()
    {
        Mytransform.transform.rotation = Trackertransform.rotation * OffSetRotation;
        // PlaneにTrackerのrotationのrotationと差分のQuaternionを掛ける

        //Debug.Log("x:" + Mytransform.transform.rotation.x.ToString());
        //Debug.Log("y:" + Mytransform.transform.rotation.y.ToString());
        //Debug.Log("z:" + Mytransform.transform.rotation.z.ToString());

    }

}
