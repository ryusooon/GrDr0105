using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtestScript : MonoBehaviour
{
    SoundManagerScript soundscript;

    public GameObject gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        soundscript = gamemanager.GetComponent<SoundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            soundscript.PlayerSound(1);
           // soundscript.DragonSound(1);
            //soundscript.DragonSound(5);
        }
    }
}
