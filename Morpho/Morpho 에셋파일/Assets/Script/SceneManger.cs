using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[System.Serializable]
public class Controll_Light
{
    public Light light1, light2, light3, light4, light5;
    public ParticleSystem fire1, fire2, fire3, fire4, fire5, fire6, fire7;

}
public class SceneManger : MonoBehaviour
{
   

    public string SceneToLoad;
    public GameObject FadeIn;

    Image Fade_image;
    // public GameObject FadeOut;
    GameObject obj_player;
    GameObject obj_camera;
    GameObject obj_audio;
    GameObject obj_gamemanager;
    GameObject obj_canvas;
    GameObject obj_obj;
   
    Clock clock;
    Obj_Interaction obj_interaction;

    public Controll_Light controll_light;
    private static SceneManger mInstance;
    public static SceneManger instance
    {
        get
        {
            if (instance == null)
            {
                mInstance = FindObjectOfType<SceneManger>();
            }
            return mInstance;
        }
    }
  
    void Start()
    {       
        Fade_image = FadeIn.GetComponent<Image>();
        obj_player = GameObject.Find("Player");
        obj_camera = GameObject.Find("Main Camera");
        obj_audio = GameObject.Find("AudioManager");
        obj_canvas = GameObject.Find("Canvas");
        obj_obj = GameObject.Find("d.obj");
        obj_gamemanager = GameObject.Find("GameManager");
        

    }

    void Update()
    {
        Scene();
    }


     public void Scene()
    {
        //작동중인 신 이름 확인
        if (SceneManager.GetActiveScene().name == "Title")
        {
            Time.timeScale = 1;
            if (Input.GetButtonDown("Submit"))
            {
                StartCoroutine(Fade_Out());
            }
        }

        else if (SceneManager.GetActiveScene().name == "Time0700")
        {
            StartCoroutine(Fade_In());

            LightOff();
            controll_light.fire7.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            controll_light.light5.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "Time1124")
        {
            LightOff();
            controll_light.fire7.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            controll_light.light5.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "Time1500")
        {
            LightOn();
            controll_light.fire7.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            controll_light.light5.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "Time1931")
        {
            LightOn();
            if (obj_interaction.usewater == false)
            {
                controll_light.fire7.Play();
                controll_light.light5.enabled = true;

            }
            else if (obj_interaction.usewater == true)
            {
                controll_light.fire7.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                controll_light.light5.enabled = false;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Time2052")
        {
            LightOn();
            controll_light.fire7.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            controll_light.light5.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "Ending")
        {
            StartCoroutine(Fade_In());
            if (Input.GetButtonDown("Submit"))
            {
                Destroy(obj_audio);
                SceneManager.LoadScene("Title");
            }
        }
        
    }
    
    public void TimeScene()
    {
        obj_interaction = GameObject.Find("GameManager").GetComponent<Obj_Interaction>();
        clock = GameObject.Find("Clock").GetComponent<Clock>();
       

        if (clock.a == 0&& clock.b == 7 && clock.c == 0 && clock.d == 0)
        {
          
            SceneManager.LoadScene("Time0700");
            StartCoroutine(Fade_In());

        }
        else if (clock.a == 1 && clock.b == 1 && clock.c == 2 && clock.d == 4)
        {
            SceneManager.LoadScene("Time1124");
           
        }
        else if (clock.a == 1 && clock.b == 5 && clock.c == 0 && clock.d == 0)
        {
            SceneManager.LoadScene("Time1500");
        }
        else if(clock.a == 1 && clock.b == 9 && clock.c == 3 && clock.d == 1)
        {
            SceneManager.LoadScene("Time1931");

        }
        else if (clock.a == 2 && clock.b == 0 && clock.c == 5 && clock.d == 2)
        {         
            SceneManager.LoadScene("Time2052");
           
        }
      
        Time.timeScale = 1;
    }
    public void Back_to_Title()
    {
        Destroy(obj_player);
        Destroy(obj_camera);
        Destroy(obj_audio);
        Destroy(obj_canvas);
        Destroy(obj_obj);
        Destroy(obj_gamemanager);
      
        SceneManager.LoadScene("Title");
      
  
    }
    public void Ending()
    {
        Destroy(obj_player);
        Destroy(obj_camera);
        Destroy(obj_canvas);
        Destroy(obj_obj);
        Destroy(obj_gamemanager);
        SceneManager.LoadScene("Ending");
    }

    IEnumerator Fade_Out()
    {
     
        Color color = Fade_image.color;

        for (int i = 0; i <= 255; i++)
        {
            color.a += Time.deltaTime * 1f;

            Fade_image.color = color;
            yield return new WaitForSeconds(0.001f);
        }
        SceneManager.LoadScene(SceneToLoad);
        

        yield return null;
    }
    IEnumerator Fade_In()
    {
        Color color = Fade_image.color;

        for (int i = 255; i >= 0; i--)
        {
            color.a -= Time.deltaTime * 1f;

            Fade_image.color = color;
            yield return new WaitForSeconds(0.001f);

        }
       
        yield return null;
    }


    void LightOn()
    {
        controll_light.light1.enabled = true;
        controll_light.light2.enabled = true;
        controll_light.light3.enabled = true;
        controll_light.light4.enabled = true;
        
        controll_light.fire1.Play();
        controll_light.fire2.Play();
        controll_light.fire3.Play();
        controll_light.fire4.Play();
        controll_light.fire5.Play();
        controll_light.fire6.Play();
       
    }
    void LightOff()
    {
        controll_light.light1.enabled = false;
        controll_light.light2.enabled = false;
        controll_light.light3.enabled = false;
        controll_light.light4.enabled = false;
       
        controll_light.fire1.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        controll_light.fire2.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        controll_light.fire3.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        controll_light.fire4.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        controll_light.fire5.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        controll_light.fire6.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
       
    }
}
