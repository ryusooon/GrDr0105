using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CollisionDetectionScript : MonoBehaviour
{

    public bool Stan;
    public int StanTime;

    SoundManagerScript soundscript;

    public GameObject gamemanager;

    int Time;

    private SteamVR_Action_Single squeeze = SteamVR_Actions.default_Squeeze;
    private SteamVR_Action_Vibration vibration = SteamVR_Actions.default_Haptic;

    // Start is called before the first frame update
    void Start()
    {
        Stan = false;
        Time = 0;
        soundscript = gamemanager.GetComponent<SoundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Stan) // スタン状態の場合
        {

            if (Time <= StanTime)
            {
                // スタンタイムより時間経過していなければ
                vibration.Execute(0, 0.2f, 150, 0.5f, SteamVR_Input_Sources.RightHand);
                Time++;
            }
            else
            {
                // スタンタイム分時間経過したら
                Stan = false;
                Time = 0;

            }

        }

    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Cubes")
        {
            Stan = true;
            Debug.Log("ぶつかった！");
        }
        else
        {

            Debug.Log("制限壁にぶつかった！");
        }
    }

}
