using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Audio_Manager : MonoBehaviour
{

    AudioSource Clock_BGM;
    // Start is called before the first frame update
    static public Audio_Manager Instance;
    private void Awake()
    {
        Clock_BGM = GetComponent<AudioSource>();
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if (Clock_BGM.isPlaying)
        {
            DontDestroyOnLoad(Clock_BGM);
            return;
        }
        //배경음악이 재생되고 있다면 패스
        else
        {
            Clock_BGM.Play();
            DontDestroyOnLoad(Clock_BGM);
            //배경음악 계속 재생하기
        }

    }

}
