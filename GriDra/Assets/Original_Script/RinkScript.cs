using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinkScript : MonoBehaviour
{
    [SerializeField] GameObject Tracker;
    [SerializeField] GameObject Broom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Broom.transform.localEulerAngles = Tracker.transform.localEulerAngles;
    }
}
