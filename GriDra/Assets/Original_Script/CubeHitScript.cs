using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHitScript : MonoBehaviour
{
    [SerializeField] Renderer YCube1;
    [SerializeField] Renderer YCube2;
    [SerializeField] Renderer XCube1;
    [SerializeField] Renderer XCube2;
    [SerializeField] Renderer ZCube1;
    [SerializeField] Renderer ZCube2;

    // Start is called before the first frame update
    void Start()
    {
        // 最初に全キューブを非表示にする
        YCube1.enabled = false;
        YCube2.enabled = false;
        ZCube1.enabled = false;
        ZCube2.enabled = false;
        XCube1.enabled = false;
        XCube2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {

        if (other.name == "YCube1")
        {
            YCube1.enabled = true;
        }

        if (other.name == "YCube2")
        {
            YCube2.enabled = true;
        }

        if (other.name == "ZCube1")
        {
            ZCube1.enabled = true;
        }

        if (other.name == "ZCube2")
        {
            ZCube2.enabled = true;
        }

        if (other.name == "XCube1")
        {
            XCube1.enabled = true;
        }

        if (other.name == "XCube2")
        {
            XCube2.enabled = true;
        }

    }

    void OnTriggerExit(Collider other)
    {

        if (other.name == "YCube1")
        {
            YCube1.enabled = false;
        }

        if (other.name == "YCube2")
        {
            YCube2.enabled = false;
        }

        if (other.name == "ZCube1")
        {
            ZCube1.enabled = false;
        }

        if (other.name == "ZCube2")
        {
            ZCube2.enabled = false;
        }

        if (other.name == "XCube1")
        {
            XCube1.enabled = false;
        }

        if (other.name == "XCube2")
        {
            XCube2.enabled = false;
        }

    }

}
