using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleShot : MonoBehaviour
{
    public GameObject player;
    public GameObject rubble;
    public float rubbleSpeed = 10.0f;

    SoundManagerScript soundscript;

    public GameObject gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(player.transform);
        soundscript = gamemanager.GetComponent<SoundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dragon" || other.tag == "Drtama")
        {
            soundscript.Gimmick(1);
            var shot = Instantiate(rubble, transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody>().velocity = transform.forward.normalized * rubbleSpeed;
        }
    }
}
