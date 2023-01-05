using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCheckScript : MonoBehaviour
{
    [SerializeField] Renderer MyMesh;

    // Start is called before the first frame update
    void Start()
    {
        MyMesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnCollisionStay(Collision collision)
    void OnTriggerStay(Collider other)
    {

        //if (collision.gameObject.name == "[CameraRig]")
        if (other.name == "[CameraRig]")
        {
            MyMesh.enabled = true;
        }
    }

    //void OnCollisionExit(Collision collision)
    void OnTriggerExit(Collider other)
    {

        //if (collision.gameObject.name == "[CameraRig]")
        if (other.name == "[CameraRig]")
        {
            MyMesh.enabled = false;
        }
    }

}
