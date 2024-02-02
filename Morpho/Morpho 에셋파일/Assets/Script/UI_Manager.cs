using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject MenuScreen;
    [SerializeField]
    GameObject OptionScreen;
    [SerializeField]
    GameObject InventoryScreen;
    [SerializeField]
    GameObject ManualScreen;

    
    Obj_Interaction obj_interaction;
    public Toggle mousetoggle;
    
    static public UI_Manager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
       
    }
    void Update()
     {
        MenuActive();
        InventoryActive();
        MouseVisuable();
      
        
    }
     void Start()
    {
        obj_interaction = GameObject.Find("GameManager").GetComponent<Obj_Interaction>();
       
    }

    public  void MenuActive()
    {
        if(!obj_interaction.InteractionImage.activeSelf&&!obj_interaction.ClockUI.activeSelf)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (MenuScreen.activeSelf)
                {
                    Time.timeScale = 1;
                    MenuScreen.SetActive(false);
                }
                else
                {
                    Time.timeScale = 0;
                    MenuScreen.SetActive(true);

                }
            }
        }
    }
    void MouseVisuable()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (Cursor.visible == true)
            {
                Cursor.visible = false;
                mousetoggle.isOn = false;
            }
           else
            {
                Cursor.visible =true;
                mousetoggle.isOn = true;
            }
        }
       
    }

    public void InventoryActive()
    {
        if (!obj_interaction.InteractionImage.activeSelf && !obj_interaction.ClockUI.activeSelf)
        {
            if(Input.GetKeyUp(KeyCode.I))
            {
                if (InventoryScreen.activeSelf)
                {
                    Time.timeScale = 1;
                    InventoryScreen.SetActive(false);
                }
                else
                {
                    Time.timeScale = 0;
                    InventoryScreen.SetActive(true);

                }
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        MenuScreen.SetActive(false);
    }


    public void Game_Exit()
    {
        Application.Quit();
    }

    public void MouseDown(Toggle toggle)
    {
        if (toggle.isOn)
        {   
            Cursor.visible = true;
        }
        else 
        {
            //마우스를 보이기
            Cursor.visible = false;

        }
    }
   
    public void FullScreen(Toggle toggle)
    {
        if(Screen.fullScreen==true)
        {
            toggle.isOn = false;
            Screen.fullScreen = false;
        }
        else
        {
            toggle.isOn = true;
            Screen.fullScreen = true;
        }

    }

    public void GameOption()
    {
        if (OptionScreen.activeSelf)
        {
         
            OptionScreen.SetActive(false);
        }
        else
        {
            ManualScreen.SetActive(false);
            OptionScreen.SetActive(true);
         
        }
    }
    public void Manual()
    {
        if (ManualScreen.activeSelf)
        {
            ManualScreen.SetActive(false);
        }
        else
        {
            OptionScreen.SetActive(false);
            ManualScreen.SetActive(true);

        }
    }
   
}
