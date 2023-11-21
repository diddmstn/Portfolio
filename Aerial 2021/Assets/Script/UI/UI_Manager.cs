using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class UI_Manager : MonoBehaviour
{
    [System.Serializable]
    public class UI_Sound
    {
        public AudioClip UI_turnOn;
        public AudioClip ButtonClick;
        public AudioClip PlayerDie;
        public AudioClip SpeechBubble_Open;
        public AudioClip SpeechBubble_Close;

    }
    public UI_Sound uI_Sound;

    [System.Serializable]
    public class UI_CavnasGroup
    {
        public CanvasGroup GameClear_canvasGroup;
        public CanvasGroup GameOver_canvasGroup;
        public CanvasGroup Title_canvasGroup;
        public CanvasGroup Option_canvasGroup;
        public CanvasGroup Inventory_canvasGroup;
    }
    public UI_CavnasGroup uI_CavnasGroup;


    GraphicRaycaster gr;
    PointerEventData ped;

    public Canvas UI_Canvas;

    public GameObject Ability;
    public Image HealthyGage;


    [SerializeField] public GameObject GameOver;
    [SerializeField] public Image GameOver_After;

    public GameObject GameClear;
    public GameObject GameClear_After;

    public GameObject Title;

    public GameObject Light;



    bool ActiveUI = false;

    public GameObject Option;

    GameObject UI_button = null;
    GameObject button1 = null;
    GameObject button2 = null;


    AudioSource audioSource;
    public Image Fade_image;

    public Image TitleQuit;
    static public string NextScene;

    // public GameObject StageInventory;
    //Slot slot;
    [SerializeField] public float Cogwheel_Speed = 0f;

    public Animator Cogewheel_Big;
    public Animator Cogewheel_Small;

    public GameObject Hint_Text;
    public GameObject Hint_Point;
    public GameObject Hint;

    public GameObject AbilityIcon;

    bool SpeechSound;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gr = UI_Canvas.GetComponent<GraphicRaycaster>();
        ped = new PointerEventData(null);
        //  slot = null;

    }
    private void Start()
    {
        Color color = Fade_image.color;
        StartCoroutine(Fade_In(Fade_image, 0.01f));
    }

    private void Update()
    {
        //Inventory_Active();
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Settings_Active();
        }

        Cogewheel_Big.SetFloat("Speed", Cogwheel_Speed);
        Cogewheel_Small.SetFloat("Speed", Cogwheel_Speed);

        UIRaycast();

    }

    void UIRaycast()
    {
        ped.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(ped, results);


        if (results.Count > 0)
        {
            if (results[0].gameObject.CompareTag("UI_Button"))//타이틀 버튼 감지시 이미지 변경
            {

                if (UI_button != null)
                {
                    button1.SetActive(true);
                    button2.SetActive(false);
                }
                UI_button = results[0].gameObject.transform.parent.gameObject;


                button1 = UI_button.transform.GetChild(0).gameObject;
                button2 = UI_button.transform.GetChild(1).gameObject;

                UI_button.transform.GetChild(0).gameObject.SetActive(false);
                UI_button.transform.GetChild(1).gameObject.SetActive(true);

            }
            else if ((results[0].gameObject.CompareTag("Hint")))
            {
                if (!audioSource.isPlaying && SpeechSound == false)
                {
                    SpeechSound = true;
                    audioSource.PlayOneShot(uI_Sound.SpeechBubble_Open);

                }

                Hint_Text.SetActive(true);
                Hint_Point.SetActive(false);

            }
            else
            {
                if (UI_button != null)
                {
                    UI_button.transform.GetChild(0).gameObject.SetActive(true);
                    UI_button.transform.GetChild(1).gameObject.SetActive(false);

                }


            }

        }
        else
        {
            //ItemDescription.SetActive(false);
            //StageInventory.transform.localPosition = new Vector2(0, -180);
            if (UI_button != null)
            {
                UI_button.transform.GetChild(0).gameObject.SetActive(true);
                UI_button.transform.GetChild(1).gameObject.SetActive(false);

                // Debug.Log(UI_button.transform.GetChild(1).name);
            }
            if (!audioSource.isPlaying && SpeechSound == true)
            {
                SpeechSound = false;
                audioSource.PlayOneShot(uI_Sound.SpeechBubble_Close);

            }

            Hint_Text.SetActive(false);
            Hint_Point.SetActive(true);
        }
    }

    //void Description(Slot slot)
    //{

    //    ItemName.text=slot.item.itemName;
    //    ItemExplain.text = slot.item.itemExplain;
    //}

    public void Game_Over()
    {
        GameOver.SetActive(true);
        audioSource.Stop();
        audioSource.PlayOneShot(uI_Sound.PlayerDie);

        StartCoroutine(CanvasGroup_Fade_Out(uI_CavnasGroup.GameOver_canvasGroup));
        Time.timeScale = 0;

        ActiveUI = true;
    }

    public void Game_Clear()
    {
        GameClear.SetActive(true);

        for (int i = 0; i < Player.circle; i++)
        {
            Light.transform.GetChild(i).gameObject.SetActive(true);

        }
        Time.timeScale = 0;

        StartCoroutine(CanvasGroup_Fade_Out(uI_CavnasGroup.GameClear_canvasGroup));
    }


    public void Title_Active()
    {
        Title.SetActive(true);
    }



    public void TutorialStart()//튜토리얼 들어가기
    {
        NextScene = "Tutorial";
        //  Debug.Log("튜토리얼 시작");
        audioSource.PlayOneShot(uI_Sound.ButtonClick);
        StartCoroutine(Fade_Out(Fade_image, 0.01f));


    }

    public void Settings_Active()
    {
        //audioSource.PlayOneShot(uI_Sound.ButtonClick);

        if (uI_CavnasGroup.Option_canvasGroup.alpha == 1)
        {
            Time.timeScale = 1;
            uI_CavnasGroup.Option_canvasGroup.alpha = 0;
            uI_CavnasGroup.Option_canvasGroup.blocksRaycasts = false;
            ActiveUI = false;
            // audioSource.PlayOneShot(uI_Sound.UI_turnOn);

        }
        else if (ActiveUI == false)
        {
            Time.timeScale = 0;

            uI_CavnasGroup.Option_canvasGroup.alpha = 1;
            uI_CavnasGroup.Option_canvasGroup.blocksRaycasts = true;

            Option.SetActive(true);
            ActiveUI = true;
            audioSource.PlayOneShot(uI_Sound.UI_turnOn);

        }


    }
    //void Inventory_Active()
    //{
    //    if (Input.GetKeyUp(KeyCode.I))
    //    {
    //        if (uI_CavnasGroup.Inventory_canvasGroup.alpha == 1)
    //        {
    //            Time.timeScale = 1;
    //            uI_CavnasGroup.Inventory_canvasGroup.alpha = 0;
    //            uI_CavnasGroup.Inventory_canvasGroup.blocksRaycasts = false;
    //            ActiveUI = false;
    //            audioSource.PlayOneShot(uI_Sound.UI_turnOff);


    //        }
    //        else if (ActiveUI == false)
    //        {
    //            Time.timeScale = 0;
    //            uI_CavnasGroup.Inventory_canvasGroup.alpha = 1;
    //            uI_CavnasGroup.Inventory_canvasGroup.blocksRaycasts = true;
    //            StageInventory.transform.localPosition = new Vector2(0, -180);
    //            ActiveUI = true;
    //            audioSource.PlayOneShot(uI_Sound.UI_turnOn);
    //        }
    //    }

    //}

    public void Credits_Acitve()//아직없음
    {
        audioSource.Stop();
        audioSource.PlayOneShot(uI_Sound.ButtonClick);
        Debug.Log("x");
    }
    public void Quit_Acitve()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(uI_Sound.ButtonClick);
        Application.Quit();
    }

    


    public void BackToTitle()
    {
        Player.AbilityActive = false;
        Player.isAbility = false;
        AbilityIcon.SetActive(false);
        Cogwheel_Speed = 0f;



        audioSource.PlayOneShot(uI_Sound.ButtonClick);
        Clean_Scene();
       
        Ability.SetActive(false);
        NextScene = "Title";
        StartCoroutine(Fade_Out(Fade_image,0.01f));

    }
    void Clean_Scene()
    {
        //if(NextScene!="Retry")
        //{
        //    if (GameObject.Find("GameManager") != null)
        //    {
        //        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //        gameManager.destroy();

        //    }
        //}
       
        if (uI_CavnasGroup.Option_canvasGroup.alpha == 1)//옵션끄기
        {
            uI_CavnasGroup.Option_canvasGroup.alpha = 0;
            uI_CavnasGroup. Option_canvasGroup.blocksRaycasts = false;
            ActiveUI = false;
        }
        if(ActiveUI==true)
        {
            //Debug.Log("UI창 끄기");
            GameClear.SetActive(false);
            GameOver.SetActive(false);

            ActiveUI = false;
        }
        HealthyGage.fillAmount = 1f;
    }
    IEnumerator CanvasGroup_Fade_Out(CanvasGroup canvasGroup)//게임클리어 게임오버 UI창
    {
        canvasGroup.alpha = 0;

        if(SceneManager.GetActiveScene().name!="Title")
        {
            //Debug.Log("UI창 클릭");
            while (Input.touchCount < 1 && !Input.anyKey) yield return null;
            while (canvasGroup.alpha < 1.0f)
            {
                canvasGroup.alpha += 0.05f;
                yield return new WaitForSecondsRealtime(0.01f);
            }



            StartCoroutine(Fade_Out(Fade_image,0.01f));

        }
        else
        {
            while (canvasGroup.alpha < 1.0f)
            {
                canvasGroup.alpha += 0.01f;
                yield return new WaitForSecondsRealtime(0.01f);
            }
        }



        yield return null;
    }
    
    public IEnumerator Fade_Out(Image fade,float FadeSpeed)
    {
        ActiveUI = true;
        Time.timeScale = 0;

        fade.enabled = true;

        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSecondsRealtime(FadeSpeed);
            Fade_image.color = new Color(0, 0, 0, fadeCount);
        }
        if (Player.isAbility == true)
        {
            Cogwheel_Speed = 1f;
            AbilityIcon.SetActive(true);
            StartCoroutine(Fade_In(Fade_image,FadeSpeed));
        }
        else   if (Player.isAbility != true)
        {
            if (NextScene == "Retry")
            {
                //UI창과 피통
                Clean_Scene();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                StartCoroutine(Fade_In(Fade_image,0.01f));
                Player.Die = false;


            }
            else
            {
                Ability.SetActive(false);
                GameClear.SetActive(false);
                Clean_Scene();

                if (NextScene == "Tutorial")
                {
                    SceneManager.LoadScene("Loading");
                    Player.Respawn = new Vector3(0f, 0f, 0);

                    yield break;
                }
                else if (NextScene == "CircuitStage1")
                {
                    Player.Respawn = new Vector3(-5f, -2f, 0);
                }
                else if (NextScene == "Title")
                {
                    Title.SetActive(true);

                }

                SceneManager.LoadScene("Loading");

            }
        }
    
      
        //StartCoroutine(Fade_In(Fade_image));


    }
    public IEnumerator Fade_In(Image fade,float FadeSpeed)
    {
        //Player.GameTime = 0;
        fade.enabled = true;

        float fadeCount = 1f;
        if (Player.isAbility == true)
        {
            if (Player.AbilityActive == false)
            {
                Cogwheel_Speed = 0f;
                AbilityIcon.SetActive(false);

            }
            else
            {
                AbilityIcon.SetActive(true);

            }
           
        }
         while (fadeCount >= 0f)
        {
            fadeCount -= 0.05f;
            //WaitForSecondsRealtime
            //if(Player.isAbility != true)
            //{
            //    //if (fadeCount <= 0.5f)
            //    //{
            //    //    if (NextScene == "Tutorial"  || NextScene == "Retry")
            //    //    {
            //    //        Ability.SetActive(true);
            //    //        //Hint.SetActive(true);

            //    //    }
            //    //    else
            //    //    {
            //    //        Ability.SetActive(false);
            //    //        Hint.SetActive(false);


            //    //    }
            //    //}
            //}
           
            yield return new WaitForSecondsRealtime(FadeSpeed);
            Fade_image.color = new Color(0, 0, 0, fadeCount);
        }
       
        if(Player.isAbility == true)
        {
            if (Player.AbilityActive == false)
            {
                Player.isAbility = false;

            }
            Time.timeScale = 1;
           
          //  Player.AbilityActive = false;
        }
        ActiveUI = false;
        fade.enabled = false;

    }


}
