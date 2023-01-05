using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class TrackerTestScript : MonoBehaviour
{

    //トラッカーの位置座標格納用
    public Vector3 Tracker1Posision;

    //トラッカーの回転座標格納用（クォータニオン）
    public Quaternion Tracker1RotationQ;
    //トラッカーの回転座標格納用（オイラー角）
    public Vector3 Tracker1Rotation;

    //トラッカーのpose情報を取得するためにtracker1という関数にSteamVR_Actions.default_Poseを固定
    public SteamVR_Action_Pose tracker1 = SteamVR_Actions.default_Pose;

    //1フレーム毎に呼び出されるUpdateメゾット
    void Update()
    {
        //位置座標を取得
        Tracker1Posision = tracker1.GetLocalPosition(SteamVR_Input_Sources.Waist);
        //回転座標をクォータニオンで値を受け取る
        Tracker1RotationQ = tracker1.GetLocalRotation(SteamVR_Input_Sources.Waist);
        //取得した値をクォータニオン → オイラー角に変換
        Tracker1Rotation = Tracker1RotationQ.eulerAngles;
    }

}