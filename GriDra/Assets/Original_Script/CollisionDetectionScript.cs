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

        if (Stan) // �X�^����Ԃ̏ꍇ
        {

            if (Time <= StanTime)
            {
                // �X�^���^�C����莞�Ԍo�߂��Ă��Ȃ����
                Time++;
            }
            else
            {
                // �X�^���^�C�������Ԍo�߂�����
                Stan = false;
                Time = 0;

            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("PlayArea"))  // �����ǈȊO�ɂԂ�������
        {
            Stan = true;
            soundscript.PlayerSound(2);

        }

    }

}
