using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backfireScript : MonoBehaviour
{
    //Tagの動的な変更でtuibiScript側でまわしてTagetを狙うようにする　　Player相手の時は考えるけど若干追尾してたし大丈夫そ
    public GameObject FireObj;
    public Transform Player;
    public Transform Tower;

    public GameObject head;
    public GameObject TowerObj;

    Vector3 headp;
    Vector3 locp;

    private int pate = 0;
    private bool cons = false;

    private GameObject Fobj;
    private Rigidbody rb_Fobj;
    // Start is called before the first frame update
    void Start()
    {
        locp = new Vector3(0.0f, 3000.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if(pate == 1)
        {
            //rb_Fobj.AddForce(transform.forward * 100f);
           // Fobj.transform.LookAt(Player, Vector3.forward);
            
        }

        if(pate == 2)
        {
           // rb_Fobj.AddForce(transform.forward * 25f);
            //Fobj.transform.LookAt(Tower, Vector3.forward);
            
        }
    }


    public void PrintEvent(string s)
    {
        Debug.Log(s);
        if (s == "now")
        {


            Vector3 headp = head.transform.position;
            //Vector3 headp = transform.TransformPoint(head.transform.position);
            Instantiate(FireObj, headp, Quaternion.identity);

            Fobj = GameObject.Find("DrFire(Clone)"); //後でTagに変更

            rb_Fobj = Fobj.GetComponent<Rigidbody>();

            Destroy(Fobj, 5f);
            pate = 1;
        }

        if(s == "Tower")
        {
            Debug.Log("撃ち");

            TowerObj.tag = "DrAtkObj";
            
             headp = head.transform.position + locp;
            //Vector3 locp = new Vector3(0.0f,10.0f,5.0f);

            Instantiate(FireObj, headp, Quaternion.identity);


            Fobj = GameObject.FindWithTag("Drtama");

            rb_Fobj = Fobj.GetComponent<Rigidbody>();


            //Fobj.transform.LookAt(Tower, Vector3.forward);
            //rb_Fobj.AddForce(transform.forward * 25f);

            Destroy(Fobj, 5f);
            pate = 2;
            
        }
        //Fire();
        //Invoke("Fire", 2.0f);
    }


    void Fire()
    {
        GameObject Fobj = GameObject.Find("DrFire(Clone)");

        Fobj.transform.LookAt(Player, Vector3.forward);

        Rigidbody rb_Fobj = Fobj.GetComponent<Rigidbody>();
        
        rb_Fobj.AddForce(transform.forward * 100f);

        Destroy(Fobj, 10f);
    }

   

}
