using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleRotate : MonoBehaviour
{
    public GameObject rubble;
    public float x = 0.5f;
    public float y = 0.5f;
    public float z = 0;

    public float deleteTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x, y, z);
    }

    private void OnTriggerEnter(Collider other)
    {
         if(other.tag == "target")
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
