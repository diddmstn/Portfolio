using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    UI_Manager UI;
    bool touch = false;
    public string clearScene;
    public GameObject E_Text;
    private void Start()
    {
        UI = GameObject.Find("UIManager").GetComponent<UI_Manager>();

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)&&touch==true&&Time.timeScale==1)
        {
            UI_Manager.NextScene = clearScene;
            //능력끄기
            Player.AbilityActive = false;
            UI.AbilityIcon.SetActive(false);
            UI.Cogwheel_Speed = 0f;
            Player.isAbility = false;
            if (SceneManager.GetActiveScene().name=="Tutorial")//튜토리얼에 클리어UI 없음
            {
                UI.StartCoroutine(UI.Fade_Out(UI.Fade_image,0.01f));
            }
            else if (SceneManager.GetActiveScene().name == "Town")
            {
                UI.StartCoroutine(UI.Fade_Out(UI.Fade_image,0.01f));
            }
            else
            {
                if(SceneManager.GetActiveScene().name == "Field_1")
                {
                    NPC.FieldEvent = true;
                }
                else if(SceneManager.GetActiveScene().name == "Field_2")
                {
                    NPC.FieldEvent2 = true;

                }
                UI.Game_Clear();
            }
          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           
            if(SceneManager.GetActiveScene().name == "Town"&&NPC.Event==true)
            {
                if(NPC.FieldEvent2==true)
                {
                    clearScene = "Title";
                }
                else if(NPC.FieldEvent==true)
                {
                    Player.circle = 0;
                    clearScene = "Field_2";
                }
                
                E_Text.SetActive(true);
                touch = true;
            }
            else if (SceneManager.GetActiveScene().name == "Field_1"|| SceneManager.GetActiveScene().name == "Field_2")
            {
                E_Text.SetActive(true);
                touch = true;
            }
            else if (SceneManager.GetActiveScene().name == "Tutorial")
            {
                E_Text.SetActive(true);
                touch = true;

            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            E_Text.SetActive(false);
            touch = false;
        }
    }
}
