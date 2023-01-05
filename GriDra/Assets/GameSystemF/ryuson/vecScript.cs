using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vecScript : MonoBehaviour
{
    private Vector3 lPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = transform.position - lPos;
        lPos = transform.position;

        if(diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }
    }
}
