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
        //��������� ����ǰ� �ִٸ� �н�
        else
        {
            Clock_BGM.Play();
            DontDestroyOnLoad(Clock_BGM);
            //������� ��� ����ϱ�
        }

    }

}
