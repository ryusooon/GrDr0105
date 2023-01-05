using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    public Transform F;
    Rigidbody rb;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        //target = Transfor.Find.CompareTag("target");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(F, Vector3.forward);
        rb.AddForce(transform.forward * 1000f);
    }
}
