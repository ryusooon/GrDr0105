using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjimpactScript : MonoBehaviour
{
    // Start is called before the first frame update
    SoundManagerScript soundscript;

    public GameObject gamemanager;
    void Start()
    {
        soundscript = gamemanager.GetComponent<SoundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "stageobj")
        {
            soundscript.PlayerSound(2);
        }
    }

}
