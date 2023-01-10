using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuibitestScript : MonoBehaviour
{
    public GameObject FireObj;
    private Transform target; //prefab������Obj�̏ꍇ����̏����͈ʒu��Transform�����Ƃ�Ȃ����瓮�I��Player�̈ʒu�������ł���悤��Tag�Â����Ă���9/5
    private GameObject tag;
    public GameObject head;
    SoundManagerScript soundscript;

    public GameObject gamemanager;

    private GameObject Fobj;
    private Rigidbody Rb;
    public bool Tracking = true;

    // Start is called before the first frame update
    void Start()
    {
        // Fobj = this.gameObject;

        tag = GameObject.FindWithTag("DrAtkObj");�@�@

        Rb = this.gameObject.GetComponent<Rigidbody>();

        //Fobj.transform.LookAt(Player, Vector3.forward);

        // Rigidbody rb_Fobj = Fobj.GetComponent<Rigidbody>();

        // rb_Fobj.AddForce(transform.forward * 1000f);      
        // Destroy(Fobj, 10f);


    }

    // Update is called once per frame
    void Update()
    {
        target = tag.transform;

        if (Tracking)
        {
            this.transform.LookAt(target, Vector3.forward);
            Rb.AddForce(transform.forward * 35f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "TrackingOnArea")
        {
            Tracking = false;
        }

        if (other.tag == "DestroyArea")
        {
            soundscript.Gimmick(1);
            Destroy(this.gameObject);
        }
    }
}
