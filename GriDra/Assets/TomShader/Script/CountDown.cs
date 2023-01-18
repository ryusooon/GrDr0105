using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

public class CountDown : MonoBehaviour
{
    public GameObject timer_object = null;
    public float countTime = 4.0f;
    int seconds;

    [SerializeField] Image Count;
    [SerializeField] Sprite three;
    [SerializeField] Sprite two;
    [SerializeField] Sprite one;
    [SerializeField] Sprite start;
    [SerializeField] Sprite menu;

    [SerializeField] Image Pauseimg;
    [SerializeField] Sprite pause;

    public GameObject countobj; //CountObject�ACountDownScript�̗L�����A������������̂Ɏg�p
    public GameObject countcanv; //CountDownCanvs�̕\���A��\���̐؂�ւ��Ɏg�p

    public GameObject closeButton;
    public GameObject buckButton;

    // ���z�ԒǋL
    [SerializeField] MovePointScript ToX1;
    [SerializeField] MovePointScript ToZ2;

    //public GameObject Righthand;            //��
    //private SteamVR_LaserPointer slScript;�@//��

    // Start is called before the first frame update
    void Start()
    {
        Count = GameObject.Find("Image").GetComponent<Image>();
        Count.enabled = false;
        countobj.GetComponent<CountDown>().enabled = false;

        ToX1.ReSet = !ToX1.ReSet;
        ToZ2.ReSet = !ToZ2.ReSet;

        //slScript = Righthand.GetComponent<SteamVR_LaserPointer>();//��
    }

    // Update is called once per frame
    void Update()
    {
        countTime -= Time.deltaTime * 100.0f; //�J�E���g���̓Q�[�������Ԃ�0.01�{���ɂȂ��Ă���̂�100��������
        seconds = (int)countTime;

        //�f�o�b�O�p�̃^�C�}�[�̃e�L�X�g�\��
        //Text timer_text = timer_object.GetComponent<Text>();
        //timer_text.text = seconds.ToString();

        //�^�C�}�[(countTime)��4�����̎��摜3��\��
        if (countTime < 4)
        {
            closeButton.SetActive(false);
            buckButton.SetActive(false);
            Pauseimg.enabled = false;
            Count.enabled = true;
            Count.sprite = three;
        }

        //�^�C�}�[(countTime)��3�����̎��摜2��\��
        if (countTime < 3)
        {
            Count.sprite = two;
        }

        //�^�C�}�[(countTime)��2�����̎��摜1��\��
        if (countTime < 2)
        {
            Count.sprite = one;
        }

        //�^�C�}�[(countTime)��1�����̎��摜start��\��
        if (countTime < 1)
        {
            Count.sprite = start;
        }

        //�^�C�}�[(countTime)��0��������0�����ɂȂ������ACountObject�ACountDownScript�𖳌�������Canvas���\���ɂ��Q�[�������Ԃ�ʏ�ɖ߂��ăQ�[�����ĊJ�����AcountTime��4.0�ɂ���
        if (countTime <= 0)
        {
            countobj.GetComponent<CountDown>().enabled = false;
            countcanv.SetActive(false);
            Time.timeScale = 1.0f;
            countTime = 4.0f;

            
        }

        //�^�C�}�[(countTime)��4�̎�pause��\������
        {
            if (countTime == 4)
            {
                Count.enabled = true;
                Count.sprite = menu;
                Pauseimg.enabled = true;
                Pauseimg.sprite = pause;
            }
        }
    }
}
