using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShotScript : MonoBehaviour
{

    [SerializeField] float Speed = 8.0f;

    [SerializeField] GameObject Preahab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }

    }


    void Shot()
    {

        GameObject Ball = Instantiate(Preahab, this.transform.position, transform.rotation);

        Vector3 Direction = -Ball.transform.forward;

        Ball.GetComponent<Rigidbody>().AddForce(Direction * Speed, ForceMode.Impulse);

        Destroy(Ball, 1.5f);

    }

}
