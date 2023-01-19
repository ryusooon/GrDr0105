using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postestScript : MonoBehaviour
{
    public GameObject head;

    Vector3 headp;
    public Vector3 locp;
    // Start is called before the first frame update
    void Start()
    {
        locp = new Vector3(-5.0f, 11.0f, -2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        headp = head.transform.position + locp;

        this.transform.position = headp;
    }
}
