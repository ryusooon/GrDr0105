using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrehabManagementScript : MonoBehaviour
{
    public PrehabScript PreSc;
    public DragonGravityScript DraGraSc;

    float NowTime = 0f;
    int Now = 0;

    // Start is called before the first frame update
    void Start()
    {
        PreSc = this.GetComponent<PrehabScript>();
        DraGraSc = this.GetComponent<DragonGravityScript>();

        PreSc.enabled = true;
        DraGraSc.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        NowTime += Time.deltaTime;
        Now = (int)Mathf.Ceil(NowTime);

        if (Now >= 3)
        {
            PreSc.enabled = false;
            DraGraSc.enabled = true;
            Debug.Log("Change!");
        }

        Debug.Log("NowTime:" + NowTime);
        Debug.Log("Now:" + Now);

    }
}
