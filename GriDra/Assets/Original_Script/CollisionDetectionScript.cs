using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionScript : MonoBehaviour
{

    public bool Stan;
    public int StanTime;

    SoundManagerScript soundscript;

    public GameObject gamemanager;

    int Time;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("PlayArea"))  // 制限壁以外にぶつかったら
        {
            Stan = true;
            soundscript.PlayerSound(2);

        }

    }

}
