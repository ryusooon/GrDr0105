using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    string HitName;

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

        if (Up || Down)
        {
            UpDownCheck();
        }

    }

    void UpDownCheck()
    {
        if (HitName == "UpZone1" || HitName == "DownZone1")
        {
            PlayScri.MoveSpeed1 = 6.0f;
        }
        else if (HitName == "UpZone2" || HitName == "DownZone2")
        {
            PlayScri.MoveSpeed1 = 12.0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("aaaaa");

        if (other.name == "UpZone1" || other.name == "UpZone2")
        {
            HitName = other.name;
            Up = true;
        }
        else if (other.name == "DownZone1" || other.name == "DownZone2")
        {
            HitName = other.name;
            Down = true;
        }
        else
        {
            HitName = "null";
            PlayScri.MoveSpeed1 = 0.0f;
            Up = false;
            Down = false;
        }

    }

}
