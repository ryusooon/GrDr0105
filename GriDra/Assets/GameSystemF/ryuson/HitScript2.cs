using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript2 : MonoBehaviour
{

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
        
    }

    void OnTriggerStay(Collider other)
    {
       // Debug.Log("weeeeeee");

        if (other.name == "LeftZone1")
        {
           // Debug.Log("左へ受け流す1");  //応急処置
            PlayScri.MoveSpeed2 = 5.0f;
            Left = true;
        }

        if (other.name == "LeftZone2")
        {
           // Debug.Log("左へ受け流す2");  //応急処置
            PlayScri.MoveSpeed2 = 12.0f;
            Left = true;
        }

        if (other.name == "RightZone1")
        {
           // Debug.Log("右の頬をビンタ1");
            PlayScri.MoveSpeed2 = 5.0f;
            Right = true;
        }

        if (other.name == "RightZone2")
        {
            //Debug.Log("右の頬をビンタ2");
            PlayScri.MoveSpeed2 = 12.0f;
            Right = true;
        }

        if (other.name == "ZeroZone")
        {
           // Debug.Log("ゼロ地点だお");
            PlayScri.MoveSpeed2 = 0.0f;
            Right = false;
            Left = false;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "LeftZone1")
        {
           // Debug.Log("ひだり当たってない1");
            PlayScri.MoveSpeed2 = 2.5f;
            Left = false;
        }

        if (other.name == "LeftZone2")
        {
           // Debug.Log("ひだり当たってない2");
            PlayScri.MoveSpeed2 = 5.0f;
            Left = false;
        }


        if (other.name == "RightZone1")
        {
          //  Debug.Log("みぎ当たってない1");
            PlayScri.MoveSpeed2 = 2.5f;
            Right = false;
        }

        if (other.name == "RightZone2")
        {
          //  Debug.Log("みぎ当たってない2");
            PlayScri.MoveSpeed2 = 5.0f;
            Right = false;
        }

    }

}
