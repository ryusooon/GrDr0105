using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public AudioClip Magicsound;  //ここに使う種類だけ音を追加していく
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

    public GameObject body; //wingの音の発生源は胴体に持ってくるつもり
    public GameObject head; //ブレスの出始めとか吠えるとかは頭から
    public GameObject tail; //尻尾後でスペル確認

    public GameObject Righthand;

    public GameObject PlayerHead;

    private GameObject berakhouse;
    private GameObject breakstone;  //tempして動的に切り替える？













    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void DragonSound(int type)  //一応書いたけどドラゴンはドラゴン側に音源持たせるべきかも
    {
        audioSource = Righthand.GetComponent<AudioSource>();  //対応したgameobjectに関してとる
        switch (type)
        {
            case 1:
                audioSource.PlayOneShot(wing); //ここらへんはループでやっとく感じになりそう(playoneshotの書き方で何とかなるならそうする)
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

    public void PlayerSound(int type)//動的にGetComponentすると処理毎度毎度はあれかも、Startで一括？
    {
        if(type == 1)
        {
            audioSource = Righthand.GetComponent<AudioSource>();
            audioSource.PlayOneShot(Magicsound);
        }


        audioSource = Righthand.GetComponent<AudioSource>();  //対応したgameobjectに関してとる
        switch (type)
        {
            case 1:
                audioSource.PlayOneShot(Magicsound);  //杖
                break;
            case 2:
                audioSource.PlayOneShot(impact); //衝撃音(ゴーグル)  <ーだからここではGetcomponentをゴーグルからするようにする
                break;
            case 3:
                //audioSource.PlayOneShot(avoid);  //回避音(ゴーグル)  
                break;

            default: break;
        }


    }

    public void Gimmick(int type)
    {
        switch (type)
        {
            case 1:
                audioSource = Righthand.GetComponent<AudioSource>();  //上での宣言においてintだけでなくgameobjもやって通るか否か
                audioSource.PlayOneShot(house);  //家倒壊
                break;
            case 2:
                audioSource.PlayOneShot(impact);　//石崩壊
                break;

            default: break;
        }
    }


}
