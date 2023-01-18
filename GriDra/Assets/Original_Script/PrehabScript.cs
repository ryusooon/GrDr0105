using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrehabScript : MonoBehaviour
{

    [SerializeField] GameObject NewPrehab;
    [SerializeField] Rigidbody PrehabRb;

    GameObject Dragon;
    Vector3 Direction;

    public float ChangeTime;

    float PrehabTime;

    public float Max = 300f, Mim = 150;

    float Power;
    bool ChangeOn;

    [SerializeField] GameObject This;

    public float FalseTime;
    public float DestryTime;

    GameObject TargetObject;
    FindDragonScript FindSc;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Find = GameObject.Find("DragonSearch");
        FindSc = Find.GetComponent<FindDragonScript>();

        Dragon = GameObject.FindWithTag("Dragon");
        TargetObject = GameObject.FindWithTag("CameraTarget");

        Direction = Dragon.transform.position - NewPrehab.transform.position;

        Power = Random.Range(Mim, Max);

        ChangeOn = false;
        Invoke("ChangeDirection", ChangeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (FindSc.FindDragon)
        {
            Direction = Dragon.transform.position - NewPrehab.transform.position;
        }
        else
        {
            Direction = TargetObject.transform.position - NewPrehab.transform.position;
        }

        PrehabTime += Time.deltaTime;

        if (PrehabTime > FalseTime)
        {
            ChangeOn = false;
        }

        if (ChangeOn)
        {
            PrehabRb.AddForce(Direction * Power);
        }

        //Debug.Log("Direction:" + Direction);

        Destroy(this.gameObject, DestryTime);

        Debug.Log("Dragon:" + Dragon.gameObject.name);

    }

    void ChangeDirection()
    {
        ChangeOn = true;
        //Debug.Log("Change!"); 
    }

    void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトのタグが"Dragon"のとき
        if (other.CompareTag("Dragon"))
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "にぶつかった");
        Destroy(this.gameObject);
    }

    void OnParticleCollision(GameObject other)
    {
        Destroy(this.gameObject);
    }

}