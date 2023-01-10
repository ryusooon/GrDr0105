using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrehabScript : MonoBehaviour
{
    // プレハブを生成するためのスクリプト

    [SerializeField] GameObject Prehab;
    [SerializeField] GameObject ShotPrehab;

    [SerializeField] Transform StartPos;
    [SerializeField] Transform TargetPos1;

    Vector3 Direction1;

    [SerializeField] Material Red, Green, Blue;

    public bool PrehabOn;
    public bool ChargeUp;

    public float Power = 90.0f;

    float NowTime = 0f;
    int Now = 0;

    public int ScaleCount;

    // Start is called before the first frame update
    void Start()
    {
        PrehabOn = false;

        Direction1 = TargetPos1.position - StartPos.position;
    }

    // Update is called once per frame
    void Update()
    {

        Direction1 = TargetPos1.position - StartPos.position;

        if (PrehabOn)
        {
            GameObject NewPrehab;
            Vector3 PrehabVec;

            MeshRenderer NewMaterial;

            if (ChargeUp)
            {
                NewPrehab = Instantiate(ShotPrehab, StartPos.position, Quaternion.identity);
                NewPrehab.transform.localScale = new Vector3(ScaleCount, ScaleCount, ScaleCount);

                ChargeUp = false;
            }
            else 
            {
                NewPrehab = Instantiate(Prehab, StartPos.position, Quaternion.identity);
                ChargeUp = false;
            }

            NewMaterial = NewPrehab.GetComponent<MeshRenderer>();
            NewMaterial.material = CreateMaterial();

            ChangeTag(NewPrehab, NewMaterial.material);

            PrehabScript PrehabSc = NewPrehab.GetComponent<PrehabScript>();
            Rigidbody PrehabRb = NewPrehab.GetComponent<Rigidbody>();

            PrehabRb.AddForce(Direction1 * Power);
       
            PrehabOn = false;
        }

    }

    Material CreateMaterial()
    {

        Material ChangeMaterial = null;

        // マテリアルを変更する関数

        if (ScaleCount < 8)
        {
            ChangeMaterial = Blue;

        }
        else if (ScaleCount >= 8 && ScaleCount < 14)
        {
            ChangeMaterial = Green;

        }
        else if (ScaleCount >= 14)
        {
            ChangeMaterial = Red;
        }


        return ChangeMaterial;


    }


    void ChangeTag(GameObject newPrehab, Material newMaterial)
    {

        if (newMaterial == Blue)
        {
            newPrehab.tag = "Level1Prehab";
        }
        else if (newMaterial == Green)
        {
            newPrehab.tag = "Level2Prehab";
        }
        else if (newMaterial == Red)
        {
            newPrehab.tag = "Level3Prehab";
        }

    
    }


}
