using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleScript : MonoBehaviour
{


    // è„â∫à⁄ìÆóp
    //[SerializeField] public GameObject Front_X;
    [SerializeField] public GameObject To_X;

    // ç∂âEà⁄ìÆóp
    //[SerializeField] public GameObject Front_Z;
    [SerializeField] public GameObject To_Z;

    //[SerializeField] public GameObject Front_Plane;
    [SerializeField] public GameObject To_Plane1;
    [SerializeField] public GameObject To_Plane2;

    public float Dif_X;
    public float Dif_Z;

    public float Start_X;
    public float Start_Z;

    // Start is called before the first frame update
    void Start()
    {
        Start_X = To_Plane1.gameObject.transform.position.y - To_X.gameObject.transform.position.y;
        Start_X = float.Parse(Start_X.ToString("f2")) * 100.0f;

        Start_Z = To_Plane2.gameObject.transform.position.y - To_Z.gameObject.transform.position.y;
        Start_Z = float.Parse(Start_Z.ToString("f2")) * 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // XÇ∆ZÇÃç∑ï™ÇéÊìæ
        //Dif_X = To_X.gameObject.transform.position.y - Front_X.gameObject.transform.position.y;
        Dif_X = To_Plane1.gameObject.transform.position.y - To_X.gameObject.transform.position.y;
        Dif_X = float.Parse(Dif_X.ToString("f2")) * 100.0f;

        //Dif_Z = To_Z.gameObject.transform.position.y - Front_Z.gameObject.transform.position.y;
        Dif_Z = To_Plane2.gameObject.transform.position.y - To_Z.gameObject.transform.position.y;
        Dif_Z = float.Parse(Dif_Z.ToString("f2")) * 100.0f;

       // Debug.Log("Dif_X:" + Dif_X);
       // Debug.Log("Dif_Z:" + Dif_Z);
    }
}
