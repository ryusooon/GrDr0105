using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHitScript : MonoBehaviour
{
    string Objname;
    string tamaname;

    public GameObject GameManager;
    private GameManagerScript Gman;
    private int pate =0;

    public Material red;
    // Start is called before the first frame update
    void Start()
    {
        Objname = this.gameObject.name;
        tamaname = "tama";

        Gman = GameManager.GetComponent<GameManagerScript>();

        if (Objname == "body") pate = 1;
        if (Objname == "head") pate = 2;
        if (Objname == "left wing") pate = 3;
        if (Objname == "tail") pate = 4;
        if (Objname == "right wing") pate = 5;
       // Debug.Log("‘Ì‚Ì•”ˆÊŠm”F"+ pate);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   // void MatChange()
  //  {
  //      this.GetComponent<Renderer>().material = red;
  //  }

    private void OnCollisionEnter(Collision col)
    {
        //Debug.Log("‚ ‚½‚Á‚½");

        if (col.gameObject.tag=="tama")
        {

            Gman.HitAcceptance(pate);
        }
    }
}
