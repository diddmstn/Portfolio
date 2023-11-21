using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{

    AudioSource audioSrc;

    public BGMs bgm;
    string CurrentBGM;
    [System.Serializable]
    public class BGMs
    {
        public AudioClip Stage1;
        public AudioClip Stage2;
        public AudioClip Stage3;

    }
    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioSrc.PlayOneShot(bgm.Stage1);
       // ChangeBGM();
    }
    public  void ChangeBGM()
    {
       switch(Potal.StageName)
        {
            case "Stage1":
                    audioSrc.Stop();
                    audioSrc.PlayOneShot(bgm.Stage1);
                break;
            case "Stage2":
                if (CurrentBGM != "Stage2")
                {
                    audioSrc.Stop();

                }
                CurrentBGM = "Stage2";
                //audioSrc.PlayOneShot(bgm.Stage2);
                audioSrc.clip = bgm.Stage2;
                audioSrc.Play();


                break;
            case "Stage3":
                audioSrc.Stop();
                audioSrc.clip = bgm.Stage3;
                audioSrc.Play();


                //audioSrc.PlayOneShot(bgm.Stage3);
                break;
        }
    }


}
