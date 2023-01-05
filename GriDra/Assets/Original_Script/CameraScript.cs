using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] public Transform Front_Plane;
    [SerializeField] public Transform VR_Camera;

    private Quaternion OffsetRota;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Front_Plane.transform.rotation.y =VR_Camera.transform.rotation;

    }
}
