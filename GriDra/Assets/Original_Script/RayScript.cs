using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    [SerializeField] Vector3 Plane;
    [SerializeField] Vector3 To;

    // Start is called before the first frame update
    void Start()
    {
        Plane = GameObject.Find("To_Plane2").transform.position;
        To = GameObject.Find("To_Z2").transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = new Ray(Plane, To);
        int Dis = 10;

        RaycastHit Hit;

        Debug.DrawLine(ray.origin, ray.direction * Dis, Color.blue);

        //if (Physics.Raycast(ray, out Hit, Dis))
        //{
        //    Debug.Log(Hit);
        //}

    }

    void FixedUpdate()
    {

        //Ray ray = new Ray(Plane, To);
        //int Dis = 10;

        //RaycastHit Hit;

        //Debug.DrawLine(ray.origin, ray.direction * Dis, Color.blue);

        //if (Physics.Raycast(ray, out Hit, Dis))
        //{
        //    Debug.Log(Hit);
        //}

    }

}
