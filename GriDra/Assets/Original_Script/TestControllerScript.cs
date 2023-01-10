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

    SoundManagerScript soundscript;

    public GameObject gamemanager;

    [SerializeField] public GameObject Controller;
    [SerializeField] VelocityEstimator VelEstim;
    [SerializeField] AccelerationScript Acceleration;
    [SerializeField] TrigerPullScript NowTriger;

    // Sphere関連
    [SerializeField] Transform SphereModel;
    SphereSize BlueSphere;
    Vector3 SphereUp;
    Vector3 SphereReset;
    [SerializeField] Material Red, Green, Blue;
    [SerializeField] MeshRenderer NowMaterial;

    [SerializeField] CollisionDetectionScript ColDetSc;

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

        soundscript = gamemanager.GetComponent<SoundManagerScript>();

        NowMaterial.material = Blue;
    }

    // Update is called once per frame
    void Update()
    {
        // スタン状態じゃない場合
        if (!ColDetSc.Stan)
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
                    //soundscript.PlayerSound(1);
                    // ↑をInstantiatePrehabScriptへ

                }

                // 確認用
                Debug.Log("トリガー入力中");
                Debug.Log("取得加速度→X:" + Get.X + " Y:" + Get.Y + " Z:" + Get.Z);
            }


            // 10秒間弾が膨らむ
            if (NowTime < 5)
            {
                PowerCharge();
                PowerCheck();
            }

            NowTime += Time.deltaTime;
            //Debug.Log("NowTime(経過時間):" + NowTime + " SpherePower(弾のサイズ):" + SpherePower);

            Debug.Log("スフィア：" + SpherePower / 20);

        }

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

        // マテリアルのリセット
        NowMaterial.material = Blue;

    }
    void GetAE()
    {
        // コントローラーの加速度を取得
        Get.X = VelEstim.GetAccelerationEstimate().x;
        Get.Y = VelEstim.GetAccelerationEstimate().y;
        Get.Z = VelEstim.GetAccelerationEstimate().z;
    }

    void PowerCheck()
    {
        // パワーの数値に合わせてマテリアルを変更する関数
        
        if (SpherePower / 20 < 8)
        {
            // パワーが300未満の場合

            if (NowMaterial != Blue)
            {
                // パワーが300未満の状態でマテリアルがBlueじゃない場合
                NowMaterial.material = Blue;
            }

        }
        else if (SpherePower / 20 >= 8 && SpherePower / 20 < 14)
        {
            // パワーが300以上600未満の場合
            
            if (NowMaterial != Green)
            {
                // パワーが300以上600未満の状態でマテリアルがGreenじゃない場合
                NowMaterial.material = Green;
            }

        }
        else if (SpherePower / 20 >= 14)
        {
            // パワーが600以上の場合

            if (NowMaterial != Red)
            {
                // パワーが600以上の状態でマテリアルがRedじゃない場合
                NowMaterial.material = Red;
            }

        }

    }

}
