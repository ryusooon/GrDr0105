using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{

    public bool Up;
    public bool Down;

    [SerializeField] PlayerScript PlayScri;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("aaaaa");

        if (other.name == "UpZone1")
        {
            //Debug.Log("うえだよおおおおおおおおおおおおお1");
            PlayScri.MoveSpeed1 = 5.0f;
            Up = true;
        }

        if (other.name == "UpZone2")
        {
            //Debug.Log("うえだよおおおおおおおおおおおおお2");
            PlayScri.MoveSpeed1 = 12.0f;
            Up = true;
        }

        if (other.name == "DownZone1")
        {
            //Debug.Log("したｄふぁどおおお1");
            PlayScri.MoveSpeed1 = 5.0f;
            Down = true;
        }

        if (other.name == "DownZone2")
        {
           // Debug.Log("したｄふぁどおおお2");
            PlayScri.MoveSpeed1 = 12.0f;
            Down = true;
        }

        if (other.name == "ZeroZone")
        {
           // Debug.Log("ゼロ地点だお");
            PlayScri.MoveSpeed1 = 0.0f;
            Down = false;
            Up = false;
        }

    }


    void OnTriggerExit(Collider other)
    {
        if (other.name == "UpZone1")
        {
           // Debug.Log("うえ当たってない1");
            PlayScri.MoveSpeed1 = 2.5f;
            Up = false;
        }

        if (other.name == "UpZone2")
        {
           // Debug.Log("うえ当たってない2");
            PlayScri.MoveSpeed1 = 5.0f;
            Up = false;
        }

        if (other.name == "DownZone1")
        {
          //  Debug.Log("した当たってない1");
            PlayScri.MoveSpeed1 = 2.5f;
            Down = false;
        }

        if (other.name == "DownZone2")
        {
           // Debug.Log("した当たってない2");
            PlayScri.MoveSpeed1 = 5.0f;
            Down = false;
        }

    }

}
