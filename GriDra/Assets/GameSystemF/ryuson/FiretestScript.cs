using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiretestScript : MonoBehaviour
{
    public GameObject FireObj;
    public Transform Player;
    public GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 headp = head.transform.position;

            Instantiate(FireObj, headp, Quaternion.identity);

            //Fire();


            //Invoke("Fire", 2.0f);
        }
    }
    
    void Fire()
    {
        GameObject Fobj = GameObject.Find("DrFire(Clone)");

        Fobj.transform.LookAt(Player, Vector3.forward);

        Rigidbody rb_Fobj = Fobj.GetComponent<Rigidbody>();

        rb_Fobj.AddForce(transform.forward * 1000f);

        Destroy(Fobj, 10f);
    }
}
