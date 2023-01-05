using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateDoScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform plane;

    private Transform thisBox;

    public Vector3 tmp;
    public Vector3 Rote;
    void Start()
    {
         Rote = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            Rote = new Vector3(plane.transform.localEulerAngles.x,0,0);

            this.gameObject.transform.eulerAngles = Rote;
        }
    }
}
