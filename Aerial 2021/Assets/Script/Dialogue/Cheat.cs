using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
     UI_Manager UI;
    private void Start()
    {
        UI = GameObject.Find("UIManager").GetComponent<UI_Manager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl)&&Input.GetKeyUp(KeyCode.F1))
        {
            NPC.Event = true;
            UI_Manager.NextScene = "Field_1";
            UI.StartCoroutine(UI.Fade_Out(UI.Fade_image, 0.01f));

        }
        else if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.F2))
        {
            NPC.Event = true;
            NPC.FieldEvent = true;
            UI_Manager.NextScene = "Field_2";
            UI.StartCoroutine(UI.Fade_Out(UI.Fade_image, 0.01f));
        }
    }
}
