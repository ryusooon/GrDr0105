using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokkScript : MonoBehaviour
{
    [SerializeField] public GameObject Dragon;
    [SerializeField] public GameObject MyObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MyObj.transform.LookAt(Dragon.transform);
    }
}
