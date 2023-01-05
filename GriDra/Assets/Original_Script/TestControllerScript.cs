using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public struct GetAccel
{
    public float X;
    public float Y;
    public float Z;
}

struct SphereSize
{
    public float X;
    public float Y;
    public float Z;
}

public class TestControllerScript : MonoBehaviour
{

    [SerializeField] public GameObject Controller;
    [SerializeField] VelocityEstimator VelEstim;
    [SerializeField] AccelerationScript Acceleration;
    [SerializeField] TrigerPullScript NowTriger;

    // Sphere関連
    [SerializeField] Transform SphereModel;
    SphereSize BlueSphere;
    Vector3 SphereUp;
    Vector3 SphereReset;

    public int SpherePower;

    public int CutTime = 30;
    public float UpSpeed = 2f;

    public float ShotValue;

    float NowTime;

    GetAccel Get;

    // Start is called before the first frame update
    void Start()
    {
        // 初期のSphereのサイズを記録
        BlueSphere.X = SphereModel.transform.localScale.x;
        BlueSphere.Y = SphereModel.transform.localScale.y;
        BlueSphere.Z = SphereModel.transform.localScale.z;

        SphereUp = new Vector3(UpSpeed, UpSpeed, UpSpeed);
        SphereReset = new Vector3(BlueSphere.X, BlueSphere.Y, BlueSphere.Z);
    }

    // Update is called once per frame
    void Update()
    {
        // トリガー入力中の処理
        if (NowTriger.PullRight == 1)
        {
            // 加速度取得
            GetAE();

            // トリガー入力中にコントローラーを振り下ろしたら
            if (Get.X > ShotValue && Get.Y > ShotValue && SpherePower > 0)
            {
                Debug.Log("NowTime(経過時間):" + NowTime + " SpherePower(弾のサイズ):" + SpherePower);

                // 弾の生成
                SphereMove();
            }

            // 確認用
            Debug.Log("トリガー入力中");
            Debug.Log("取得加速度→X:" + Get.X + " Y:" + Get.Y + " Z:" + Get.Z);
        }


        // 10秒間弾が膨らむ
        if (NowTime < 10)
        {
            PowerCharge();
        }

        NowTime += Time.deltaTime;
        //Debug.Log("NowTime(経過時間):" + NowTime + " SpherePower(弾のサイズ):" + SpherePower);

    }

    // チャージの処理
    void PowerCharge()
    {
        // 弾の威力を増やす
        SpherePower += 1;

        // モデルの弾を大きくする
        SphereModel.transform.localScale += SphereUp;
    }

    // 弾の生成および発射処理
    void SphereMove()
    {
        // 発射させる弾は一発
        //Acceleration.PrehabCount = 1;

        // 生成する弾のサイズをチャージ分にして膨らませる
        //Acceleration.ChargeCount = SpherePower / 80;


        Acceleration.PrehabCount = SpherePower / CutTime;
        Acceleration.ChargeCount = SpherePower / 20;

        // リセット
        ReSet();

    }

    // リセットの処理
    void ReSet()
    {
        // 威力の数値をゼロにする
        SpherePower = 0;

        // 弾のサイズを初期状態にリセット
        SphereModel.transform.localScale = SphereReset;

        // 経過時間ゼロ
        NowTime = 0;

    }

    void GetAE()
    {
        // コントローラーの加速度を取得
        Get.X = VelEstim.GetAccelerationEstimate().x;
        Get.Y = VelEstim.GetAccelerationEstimate().y;
        Get.Z = VelEstim.GetAccelerationEstimate().z;
    }

}
