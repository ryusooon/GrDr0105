using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public AudioClip Magicsound;  //�����Ɏg����ނ�������ǉ����Ă���
    public AudioClip BGM;
    public AudioClip impact;
    //public AudioClip avoid;
    public AudioClip tailatk;

    public AudioClip wing;  
    public AudioClip bark;
    //public AudioClip fear;
   // public AudioClip final;

    public AudioClip fireball;
    //public AudioClip firebless;
    //public AudioClip collapse;

    public AudioClip house;
   // public AudioClip stone;


    //public AudioClip sea;
    //public AudioClip river;

    AudioSource audioSource;

    public GameObject body; //wing�̉��̔������͓��̂Ɏ����Ă������
    public GameObject head; //�u���X�̏o�n�߂Ƃ��i����Ƃ��͓�����
    public GameObject tail; //�K����ŃX�y���m�F

    public GameObject Righthand;

    public GameObject PlayerHead;

    private GameObject berakhouse;
    private GameObject breakstone;  //temp���ē��I�ɐ؂�ւ���H













    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void DragonSound(int type)  //�ꉞ���������ǃh���S���̓h���S�����ɉ�����������ׂ�����
    {
        audioSource = Righthand.GetComponent<AudioSource>();  //�Ή�����gameobject�Ɋւ��ĂƂ�
        switch (type)
        {
            case 1:
                audioSource.PlayOneShot(wing); //������ւ�̓��[�v�ł���Ƃ������ɂȂ肻��(playoneshot�̏������ŉ��Ƃ��Ȃ�Ȃ炻������)
                break;
            case 2:
                audioSource.PlayOneShot(bark);
                break;
            case 3:
                audioSource.PlayOneShot(tailatk);
                break;
            case 4:
                audioSource.PlayOneShot(fireball);
                break;

            default: break;
        }
    }

    public void PlayerSound(int type)//���I��GetComponent����Ə������x���x�͂��ꂩ���AStart�ňꊇ�H
    {
        if(type == 1)
        {
            audioSource = Righthand.GetComponent<AudioSource>();
            audioSource.PlayOneShot(Magicsound);
        }


        audioSource = Righthand.GetComponent<AudioSource>();  //�Ή�����gameobject�Ɋւ��ĂƂ�
        switch (type)
        {
            case 1:
                audioSource.PlayOneShot(Magicsound);  //��
                break;
            case 2:
                audioSource.PlayOneShot(impact); //�Ռ���(�S�[�O��)  <�[�����炱���ł�Getcomponent���S�[�O�����炷��悤�ɂ���
                break;
            case 3:
                //audioSource.PlayOneShot(avoid);  //�����(�S�[�O��)  
                break;

            default: break;
        }


    }

    public void Gimmick(int type)
    {
        switch (type)
        {
            case 1:
                audioSource = Righthand.GetComponent<AudioSource>();  //��ł̐錾�ɂ�����int�����łȂ�gameobj������Ēʂ邩�ۂ�
                audioSource.PlayOneShot(house);  //�Ɠ|��
                break;
            case 2:
                audioSource.PlayOneShot(impact);�@//�Ε���
                break;

            default: break;
        }
    }


}
