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

        if (Objname == "Body") pate = 1;
        if (Objname == "Head") pate = 2;
        if (Objname == "LeftWing") pate = 3;
        if (Objname == "Tail") pate = 4;
        if (Objname == "RightWing") pate = 5;
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

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log(other);

        if (other.gameObject.tag == "Level1Prehab")
        {
            Gman.shotDmg = 1;
            Gman.HitAcceptance(pate);
        }

        if (other.gameObject.tag == "Level2Prehab")
        {
            Gman.shotDmg = 2;
            Gman.HitAcceptance(pate);
        }

        if (other.gameObject.tag == "Level3Prehab")
        {
            Gman.shotDmg = 3;
            Gman.HitAcceptance(pate);
        }
    }
}
