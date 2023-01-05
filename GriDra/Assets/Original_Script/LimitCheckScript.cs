using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitCheckScript : MonoBehaviour
{
    [SerializeField] Renderer LimiteRendere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�g���K�[�I�u�W�F�N�g�ɐN�������u�Ԃ̏���
    void OnTriggerEnter(Collider other)
    {

        if (other.name == "[CameraRig]")
        {
            LimiteRendere.enabled = false;
        }
    }

    //// �g���K�[�I�u�W�F�N�g�ɐN�����Ă���Ԃ̏���
    void OnTriggerStay(Collider other)
    {

    }

    //// �g���K�[�I�u�W�F�N�g����E�o�����u�Ԃ̏���
    void OnTriggerExit(Collider other)
    {
        if (other.name == "[CameraRig]")
        {
            LimiteRendere.enabled = true;
        }
    }

}
