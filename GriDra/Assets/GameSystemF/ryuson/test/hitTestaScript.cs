using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitTestaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�Ȃ񂩓�������");

        if (other.tag == "norm")
        {
            Debug.Log("�����Ƃ��Ă�");
        }
    }
}
