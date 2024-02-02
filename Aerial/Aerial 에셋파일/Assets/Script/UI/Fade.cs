using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    Image Fade_image;


    // Start is called before the first frame update
    void Awake()
    {
        Fade_image = GetComponent<Image>();

    }
    private void Start()
    {
        StartCoroutine(Fade_In());
        Color color = Fade_image.color;
    }


    public IEnumerator Fade_In()
    {
        //Time.timeScale = 0;
        Player.PlayerActive=false;
        Fade_image.enabled = true;

        float fadeCount = 1f;
        while (fadeCount >= 0f)
        {
            fadeCount -= 0.01f;
            //WaitForSecondsRealtime
            yield return new WaitForSecondsRealtime(0.01f);
            Fade_image.color = new Color(0, 0, 0, fadeCount);
        }
        //  Time.timeScale = 1;
        if(SceneManager.GetActiveScene().name != "Title")//Titdle에 입력감지 못하게
        {
            Player.PlayerActive = false;
        }

        Fade_image.enabled= false;

    }
    public IEnumerator Fade_Out()
    {
        Time.timeScale = 0;

        Fade_image.enabled = true;

        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
            Fade_image.color = new Color(0, 0, 0, fadeCount);
        }


    }
}
