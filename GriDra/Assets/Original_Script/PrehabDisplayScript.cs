using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrehabDisplayScript : MonoBehaviour
{
    [SerializeField] GameObject RedSphere;
    [SerializeField] GameObject BlueSphere;

    Renderer Red;
    Renderer Blue;

    [SerializeField] ControllerScript Controller;

    // Start is called before the first frame update
    void Start()
    {
        Red = RedSphere.GetComponent<Renderer>();
        Blue = BlueSphere.GetComponent<Renderer>();

        Red.enabled = false;
        Blue.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Controller.Charge >= 1)
        {
            Blue.enabled = true;

            if (Controller.Charge >= 150)
            {
                Blue.enabled = false;
                Red.enabled = true;
            }

        }
        else
        {
            Red.enabled = false;
            Blue.enabled = false;
        }

    }
}
