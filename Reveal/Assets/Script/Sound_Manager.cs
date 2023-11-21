using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
   

    GameObject BackgroundMusic;
    AudioSource backmusic;
   


    // Start is called before the first frame update




    void Start()
    {
        BackgroundMusic = GameObject.Find("불안한 너의 눈동자");
        

        backmusic = BackgroundMusic.GetComponent<AudioSource>();
       

        if (Input.GetMouseButtonDown(0))
        {
          
        }


        if (backmusic.isPlaying)
        {
            DontDestroyOnLoad(BackgroundMusic);
            return;
        }
        //배경음악이 재생되고 있다면 패스
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(BackgroundMusic);
            //배경음악 계속 재생하기
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

   



}
    
