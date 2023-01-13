using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript2 : MonoBehaviour
{
    string HitName;

    public bool Left;
    public bool Right;

    [SerializeField] PlayerScript PlayScri;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Left || Right)
        {
            LeftRightCheck();
        }

    }

    void LeftRightCheck()
    {
        if (HitName == "LeftZone1" || HitName == "RightZone1")
        {
            PlayScri.MoveSpeed2 = 6.0f;
        }
        else if (HitName == "LeftZone2" || HitName == "RightZone2")
        {
            PlayScri.MoveSpeed2 = 12.0f;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Debug.Log("weeeeeee");

        if (other.name == "LeftZone1" || other.name == "LeftZone2")
        {
            HitName = other.name;
            Left = true;
        }
        else if (other.name == "RightZone1" || other.name == "RightZone2")
        {
            HitName = other.name;
            Right = true;
        }
        else
        {
            HitName = "null";
            PlayScri.MoveSpeed2 = 0.0f;
            Left = false;
            Right = false;
        }

    }

}
