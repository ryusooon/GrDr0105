using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DranimContScript : MonoBehaviour
{
    public Animator animator;

        // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //animator.SetBool("Firebool", true);
            animator.SetTrigger("Fire");
            //Debug.Log("‚¨‚µ‚½");
        }
    }

    public void PrintEvent(string s)
    {
        //Debug.Log(s);
        if(s == "fire")
        {
            animator.SetTrigger("Fire");
        }
        else if(s == "roar")
        {
            animator.SetTrigger("roarTrigger");
        }
        else if(s == "tail")
        {
            animator.SetTrigger("Tail");
        }
        else if(s == "end")
        {
            animator.SetTrigger("End");
        }
    }
}
