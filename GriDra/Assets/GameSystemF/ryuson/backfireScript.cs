using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backfireScript : MonoBehaviour
{
    //Tag�̓��I�ȕύX��tuibiScript���ł܂킵��Taget��_���悤�ɂ���@�@Player����̎��͍l���邯�ǎ኱�ǔ����Ă������v��
    public GameObject FireObj;
    public Transform Player;
    public Transform Tower;

    public GameObject head;
    public GameObject TowerObj;

    Vector3 headpos;

    private int pate = 0;
    private bool cons = false;

    private GameObject Fobj;
    private Rigidbody rb_Fobj;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (s == "back")
        {
           

            Vector3 headp = head.transform.position;

            Instantiate(FireObj, headp, Quaternion.identity);

            Fobj = GameObject.Find("DrFire(Clone)"); //���Tag�ɕύX

            rb_Fobj = Fobj.GetComponent<Rigidbody>();

            Destroy(Fobj, 10f);
            pate = 1;
        }

        if(s == "Tower")
        {
            Debug.Log("����");

            TowerObj.tag = "DrAtkObj";
            
            Vector3 headp = head.transform.position;

            Instantiate(FireObj, headp, Quaternion.identity);


            Fobj = GameObject.FindWithTag("Drtama");

            rb_Fobj = Fobj.GetComponent<Rigidbody>();


            //Fobj.transform.LookAt(Tower, Vector3.forward);
            //rb_Fobj.AddForce(transform.forward * 25f);

            Destroy(Fobj, 10f);
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