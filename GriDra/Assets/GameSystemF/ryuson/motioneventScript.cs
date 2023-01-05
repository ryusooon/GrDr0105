using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motioneventScript : MonoBehaviour
{
    [SerializeField] Animator FireAnim;
    [SerializeField] GameObject Dr;
    // Start is called before the first frame update
    void Start()
    {
        FireAnim = Dr.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PrintEvent(string s)
    {
        if (s == "FireOn") FireOn();
        if (s == "FiretoTow")towerFire();
        //FireOn();   //ë∂ç›ÇµÇƒÇ¢Ç»Ç¢Ç©ÇÁàÍíUçÌèú
        //Invoke("Fire", 2.0f);
    }
    void FireOn()
    {
        FireAnim.enabled = true;
        Invoke("FireOf", 11f);
    }

    void towerFire()
    {
        FireAnim.enabled = true;
        Invoke("towerFireOff", 11f);
    }

    void towerFireOff()
    {
        FireAnim.enabled = false;
    }

    void FireOf()
    {
        FireAnim.enabled = false;
    }
}
