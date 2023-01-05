using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] public Transform Mytransform;
    // Plane‚ÌTransform‚ğŠi”[

    [SerializeField] Transform Trackertransform;
    // Tracker‚ÌTransform‚ğŠi”[

    [SerializeField] public Quaternion OffSetRotation;

    // Start is called before the first frame update
    void Start()
    {
        OffSetRotation = Quaternion.Inverse(Trackertransform.transform.rotation) * Mytransform.transform.rotation;
        // ·•ª‚ÌQuaternion‚ğæ“¾‚·‚é‚½‚ß‚ÉA‹t‚ÌQuaternion(Inverse)‚ğŠ|‚¯‚é

    }


    // Update is called once per frame
    void Update()
    {
        Mytransform.transform.rotation = Trackertransform.rotation * OffSetRotation;
        // Plane‚ÉTracker‚Ìrotation‚Ìrotation‚Æ·•ª‚ÌQuaternion‚ğŠ|‚¯‚é

        //Debug.Log("x:" + Mytransform.transform.rotation.x.ToString());
        //Debug.Log("y:" + Mytransform.transform.rotation.y.ToString());
        //Debug.Log("z:" + Mytransform.transform.rotation.z.ToString());

    }

}
