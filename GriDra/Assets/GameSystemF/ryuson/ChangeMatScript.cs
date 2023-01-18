using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMatScript : MonoBehaviour
{

    public Material head;
    public Material tail;
    public Material Rwing;
    public Material Lwing;
    public Material body;
    private int pate = 0;
    string Objname;
    // Start is called before the first frame update
    void Start()
    {
        Objname = this.gameObject.name;

        if (Objname == "Body") pate = 1;
        if (Objname == "Head") pate = 2;
        if (Objname == "LeftWing") pate = 3;
        if (Objname == "Tail") pate = 4;
        if (Objname == "RightWing") pate = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMat(int bui)
    {
        Debug.Log(bui);
        Debug.Log("kita");
        switch (bui)
        {
            case 1:
                GetComponent<SkinnedMeshRenderer>().material = body; 
                break;

            case 2:
                Debug.Log("ì™Change");
                GetComponent<SkinnedMeshRenderer>().material = head;
                break;

            case 3:
                GetComponent<SkinnedMeshRenderer>().material = Lwing;
                break;

            case 4:
                GetComponent<SkinnedMeshRenderer>().material = tail;
                break;

            case 5:
                GetComponent<SkinnedMeshRenderer>().material = Rwing;
                break;


            default:
                Debug.Log("êîéöïœ");
                break;

        }
    }
}
