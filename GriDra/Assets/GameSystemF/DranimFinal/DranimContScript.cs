using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DranimContScript : MonoBehaviour
{
    public Animator animator;

    SoundManagerScript soundscript;

    public GameObject gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        soundscript = gamemanager.GetComponent<SoundManagerScript>();
        
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
            soundscript.DragonSound(4);
        }
        else if(s == "roar")
        {
            animator.SetTrigger("roarTrigger");
            soundscript.DragonSound(2);
        }
        else if(s == "tail")
        {
            animator.SetTrigger("Tail");
            soundscript.DragonSound(3);
        }
        else if(s == "end")
        {
            animator.SetTrigger("End");
            //soundscript.DragonSound(5);
            soundscript.BGMS(3);
        }

        if(s == "yarare")

        if (s == "kouhan")
        {
            soundscript.DragonSound(5);
        }
    }
}
