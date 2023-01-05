using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;
    public bool lastbattle = false;

    CharacterStatus Dr;
    CharacterStatus Player;
    CharacterStatus Updatedate;

    private int shotDmg = 1;

    public GameObject Drtext;
    Text Statustext;

    //�ȉ�������
    /*����ManagerScript�ɂ��Ƃ肵�ăh���S���Ƃ��v���C���[�̏�Ԃ�����肷�邱�Ƃɂ��悤���Ȃ�
     StatusUpdate�̉ӏ��ɂ����Ă�int�^�̕ϐ��̎󂯓n�����ɂ��ꂪ0�Ȃ痼���̍X�V1�Ȃ�h���S���̂�2�Ȃ�v���C���[�݂̂ɂ��邱��*/
    public struct CharacterStatus
    {
        public int Hp;
        public int Headhp;
        public int Bodyhp;
        public int Rwinghp;
        public int Lwinghp;
        public int tailhp;
        public int Status;
        public bool active;

        //public DrStatus(int hp, int status, bool active)
        //{
        //    this.Hp = hp;
        //    this.
        //}
    }
    



    // Start is called before the first frame update
    void Start()
    {
        

        Dr.Hp = 100;

        Dr.Status = 0;  //0�Ȃɂ��Ȃ��@1Anim���@2����Anim���@3������
        Dr.active = false;//0����s�\�@1����\


        Dr.Headhp = 15;
        Dr.Bodyhp = 30; 
        Dr.Rwinghp = 15; 
        Dr.Lwinghp = 15; 
        Dr.tailhp = 15; 



        Player.Hp = 10000;
        Player.Status = 0;//0�Ȃɂ��Ȃ��@1Anim���s���� 2 �X�^����
        Player.active = false;//0����s�\�@1����\

        Updatedate.Hp = 0;
        Updatedate.Status = 0;//0�Ȃɂ��Ȃ��@1Anim���s���� 2 �X�^����
        Updatedate.active = false;//0����s�\�@1����\


        Statustext = Drtext.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        Statustext.text = string.Format("{00} Dr.Hp",Dr.Hp); //���t���[���Ăяo���Ȃ��Ă��ύX���Ɉ��Ăяo�������ł�����������Ȃ��A����Debug�p�Ȃ炱�̂܂܂ł���
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void DateMove(int bui)
    {
        if (bui == 1) Debug.Log("");
        
    }


    //private void StatusUpdate(CharacterStatus oldsta, CharacterStatus newsta, int pattern)//pattern����Ȃ���
   // {
    //    oldsta.Hp = newsta.Hp;
    //    oldsta.Status = newsta.Status;
   //     oldsta.active = newsta.active;
   // }


    public void HitAcceptance(int pate) 
    {
        Debug.Log(pate+"�ɂ�������");

        switch (pate)
        {
            case 1:
                Dr.Bodyhp--;
                Dr.Hp--;
                if (Dr.Bodyhp == 0) DateMove(pate);
                if (Dr.Headhp <= 0) Dr.Hp--;
                break;

            case 2:
                Dr.Headhp--;
                Dr.Hp--;
                if (Dr.Headhp == 0) DateMove(pate);
                if (Dr.Headhp <= 0) Dr.Hp--;
                break;

            case 3:
                Dr.Lwinghp--;
                Dr.Hp--;
                if (Dr.Lwinghp == 0) DateMove(pate);
                if (Dr.Lwinghp <= 0) Dr.Hp--;
                break;

            case 4:
                Dr.tailhp--;
                Dr.Hp--;
                if (Dr.tailhp == 0) DateMove(pate);
                if (Dr.tailhp <= 0) Dr.Hp--;
                break;

            case 5:
                Dr.Rwinghp--;
                Dr.Hp--;
                if (Dr.Rwinghp == 0) DateMove(pate);
                if (Dr.Rwinghp <= 0) Dr.Hp--;
                break;


            default:
                Debug.Log("�e�̔���ł͂Ȃ�");
                break;


        }

        //if(Dr.Headhp == 0)


        //Debug.Log("��HP" + Dr.Hp + "\n��Hp" + Dr.Headhp + "\n��Hp" + Dr.Bodyhp + "\n�E�HHp" + Dr.Rwinghp + "\n���HHp" + Dr.Lwinghp + "\n�K��Hp" + Dr.tailhp);
        Debug.Log("��HP" + Dr.Hp + "\n��Hp");


    }

    public void PrintEvent(string s,CharacterStatus st)
    {
        if(s == "linecheck")//�{�[�_�[���C��
        {
            if (st.Hp == 40) lastbattle = true;
        }
    }
}
