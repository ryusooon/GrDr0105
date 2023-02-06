using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CollisionDetectionScript : MonoBehaviour
{

    public bool Stan;
    public float StanTime;

    SoundManagerScript soundscript;

    public GameObject gamemanager;

    float Time;

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
     void FixedUpdate()
    {

        if (Stan) // スタン状態の場合
        {

            if (Time < StanTime)
            {
                // スタンタイムより時間経過していなければ
                Time++;
            }
            else
            {
                // スタンタイム分時間経過したら
                Stan = false;
                Time = 0;
            }

        }

        Debug.Log("スタン時のタイム：" + Time);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Drtama" || other.gameObject.tag == "Rubble")
        {
            Stan = true;
            float VibrationTime = (StanTime / 100f) + 0.3f;

            /*Execute(float secondsFromNow：現在の時刻からアクションを実行するまでの時間0から設定可, float durationSeconds：どのぐらい振動が続くか（秒単位）, 
            　float frequency：どのぐらいの頻度で振動が発生するか（0 - 320hz）0がお勧めらしい, float amplitude：振動の強さ（0 - 1）) 各数値のあとのfはflootの宣言*/
            vibration.Execute(0, VibrationTime, 150f, 0.5f, SteamVR_Input_Sources.RightHand);

            //Debug.Log("ぶつかった！");
            Debug.Log(other.name + "にぶつかった！");
        }
        else
        {

            //Debug.Log("制限壁にぶつかった！");
        }

    }

}
