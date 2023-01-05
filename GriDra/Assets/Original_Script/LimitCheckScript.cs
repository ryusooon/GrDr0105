using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitCheckScript : MonoBehaviour
{
    [SerializeField] Renderer LimiteRendere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //トリガーオブジェクトに侵入した瞬間の処理
    void OnTriggerEnter(Collider other)
    {

        if (other.name == "[CameraRig]")
        {
            LimiteRendere.enabled = false;
        }
    }

    //// トリガーオブジェクトに侵入している間の処理
    void OnTriggerStay(Collider other)
    {

    }

    //// トリガーオブジェクトから脱出した瞬間の処理
    void OnTriggerExit(Collider other)
    {
        if (other.name == "[CameraRig]")
        {
            LimiteRendere.enabled = true;
        }
    }

}
