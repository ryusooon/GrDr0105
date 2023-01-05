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
            //Debug.Log("Ç§Ç¶ÇæÇÊÇ®Ç®Ç®Ç®Ç®Ç®Ç®Ç®Ç®Ç®Ç®Ç®Ç®1");
            PlayScri.MoveSpeed1 = 5.0f;
            Up = true;
        }

        if (other.name == "UpZone2")
        {
            //Debug.Log("Ç§Ç¶ÇæÇÊÇ®Ç®Ç®Ç®Ç®Ç®Ç®Ç®Ç®Ç®Ç®Ç®Ç®2");
            PlayScri.MoveSpeed1 = 12.0f;
            Up = true;
        }

        if (other.name == "DownZone1")
        {
            //Debug.Log("ÇµÇΩÇÑÇ”ÇüÇ«Ç®Ç®Ç®1");
            PlayScri.MoveSpeed1 = 5.0f;
            Down = true;
        }

        if (other.name == "DownZone2")
        {
           // Debug.Log("ÇµÇΩÇÑÇ”ÇüÇ«Ç®Ç®Ç®2");
            PlayScri.MoveSpeed1 = 12.0f;
            Down = true;
        }

        if (other.name == "ZeroZone")
        {
           // Debug.Log("É[Éçínì_ÇæÇ®");
            PlayScri.MoveSpeed1 = 0.0f;
            Down = false;
            Up = false;
        }

    }


    void OnTriggerExit(Collider other)
    {
        if (other.name == "UpZone1")
        {
           // Debug.Log("Ç§Ç¶ìñÇΩÇ¡ÇƒÇ»Ç¢1");
            PlayScri.MoveSpeed1 = 2.5f;
            Up = false;
        }

        if (other.name == "UpZone2")
        {
           // Debug.Log("Ç§Ç¶ìñÇΩÇ¡ÇƒÇ»Ç¢2");
            PlayScri.MoveSpeed1 = 5.0f;
            Up = false;
        }

        if (other.name == "DownZone1")
        {
          //  Debug.Log("ÇµÇΩìñÇΩÇ¡ÇƒÇ»Ç¢1");
            PlayScri.MoveSpeed1 = 2.5f;
            Down = false;
        }

        if (other.name == "DownZone2")
        {
           // Debug.Log("ÇµÇΩìñÇΩÇ¡ÇƒÇ»Ç¢2");
            PlayScri.MoveSpeed1 = 5.0f;
            Down = false;
        }

    }

}
