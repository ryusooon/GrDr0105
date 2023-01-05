using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrigerPullScript : MonoBehaviour
{
    //トリガーがどれだけ押されているのかを取得するための変数
    public SteamVR_Action_Single TriggerPull;

    //結果の格納用floot型関数
    public float PullLeft, PullRight;

    // Start is called before the first frame update
    void Start()
    {
        //変数にSteamVR_Actions.default_Squeezeを固定
        TriggerPull = SteamVR_Actions.default_Squeeze;
    }

    // Update is called once per frame
    void Update()
    {
        //結果をGetLastAxisで取得して格納（左コントローラ版）
       　PullLeft = TriggerPull.GetLastAxis(SteamVR_Input_Sources.LeftHand);
        //中身の確認
        Debug.Log("Left:" + PullLeft);

        //結果をGetLastAxisで取得してpullrightに格納（右コントローラ版）
        PullRight = TriggerPull.GetLastAxis(SteamVR_Input_Sources.RightHand);
        //中身の確認
        Debug.Log("Right:" + PullRight);
    }
}
