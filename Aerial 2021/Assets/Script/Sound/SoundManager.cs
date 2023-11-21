using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public Slider BGM_Volume;
    AudioSource sound;

    float backVol = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.CompareTag("BGM"))
        {
            BGM_Volume = GameObject.Find("OptionOperate").transform.Find("Sound").transform.Find("BGMGage").GetComponent<Slider>();

        }
        else
        {
            BGM_Volume = GameObject.Find("OptionOperate").transform.Find("Sound").transform.Find("SEGage").GetComponent<Slider>();

        }
        sound = GetComponent<AudioSource>();
       // backVol = PlayerPrefs.GetFloat("backvol", 1f);

       // BGM_Volume.value = backVol;
        sound.volume = BGM_Volume.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
        sound.volume = BGM_Volume.value/10;
        backVol = BGM_Volume.value;
      //  PlayerPrefs.SetFloat("backvol", backVol);
    }

    public void SoundStart()
    {
        sound.Stop();
        sound.Play();
    }
}
