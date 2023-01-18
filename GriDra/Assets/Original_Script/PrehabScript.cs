using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrehabScript : MonoBehaviour
{

    [SerializeField]  GameObject NewPrehab;
    [SerializeField]  Rigidbody PrehabRb;

    GameObject Dragon;
    Vector3 Direction;

    public float ChangeTime;
    public float DestryTime;
    float PrehabTime;

    public float Max = 300f, Mim = 150;

    float Power;
    bool ChangeOn;

    [SerializeField] GameObject This;

    // Start is called before the first frame update
    void Start()
    {
        Dragon = GameObject.FindWithTag("Dragon");
        Direction = Dragon.transform.position - NewPrehab.transform.position;

        Power = Random.Range(Mim, Max);

        ChangeOn = false;
        Invoke("ChangeDirection", ChangeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Direction = Dragon.transform.position - NewPrehab.transform.position;
        PrehabTime += Time.deltaTime;

        if (ChangeOn)
        {
            PrehabRb.AddForce(Direction * Power);
        }

        //Debug.Log("Direction:" + Direction);

        Destroy(this.gameObject, DestryTime);

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
        Destroy(this.gameObject);
    }

    void OnParticleCollision(GameObject other)
    {
        Destroy(this.gameObject);
    }

}
