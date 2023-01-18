using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDragonScript : MonoBehaviour
{
    public bool FindDragon;

    // Start is called before the first frame update
    void Start()
    {
        FindDragon = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider t)
    {
        if (t.gameObject.tag == "Dragon")
        {
            FindDragon = true;
            Debug.Log("ƒhƒ‰ƒSƒ“”­Œ©");
        }

    }

    void OnTriggerExit(Collider t)
    {
        if (t.gameObject.tag == "Dragon")
        {
            FindDragon = false;
            Debug.Log("ƒhƒ‰ƒSƒ“Œ©Ž¸‚¤");
        }
    }

}