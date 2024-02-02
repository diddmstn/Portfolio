using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomCam : MonoBehaviour
{
    public GameObject Room;
    public GameObject cam;
    UI_Manager UI;
    UnityEngine.Rendering.Universal.Light2D Ability_Light;

    float i = 0;

    bool CorutineRoom = true;
    private void Start()
    {
        Ability_Light = GameObject.Find("Global Light 2D").GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        UI = GameObject.Find("UIManager").GetComponent<UI_Manager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Room.SetActive(true);
            cam.SetActive(true);

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            cam.SetActive(false); 
                   StartCoroutine(RoomTurnoff());
            if (Player.AbilityActive == true)
            {
                Player.AbilityActive = false;
                UI.AbilityIcon.SetActive(false);
                UI.Cogwheel_Speed = 0f;
                Player.isAbility = false;
                Ability_Light.intensity = 1f;
            }

        }
    }

    IEnumerator RoomTurnoff()//3√ µøæ» ƒ∑≤®¡¯∞≈ ¿Ø¡ˆ-> ¿Ã¿¸∏ Active false
    {
        i = 0;
        if(CorutineRoom == true)
        {
            CorutineRoom = false;
            for (i = 0; i < 2;)
            {
                //Debug.Log(i);
                yield return new WaitForSeconds(3f);
                if (cam.activeSelf == true)
                {
                    CorutineRoom = true;
                    yield break;
                }
                i += 1;

            }
            if (cam.activeSelf == false)
            {
                CorutineRoom = true;
                Room.SetActive(false);

            }
        }
        

    }
    
}
