using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_Apk : MonoBehaviour
{
    public GameObject OperateMessage;
    public GameObject B_Message;
    public GameObject Guidance_Message;
    public GameObject Advertising_Message;
    public GameObject Teacher_Message;
   // public GameObject Message_Back;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Message()
    {
        OperateMessage.SetActive(true);
    }

    public void Back_Message()
    {
        B_Message.SetActive(false);
        Guidance_Message.SetActive(false);
        Advertising_Message.SetActive(false);
        Teacher_Message.SetActive(false);
    }

    public void Operate_Message_B()
    {
        B_Message.SetActive(true);
    }
    public void Operate_Message_Guidance()
    {
        Guidance_Message.SetActive(true);
    }

    public void Operate_Message_Teacher()
    {
        Teacher_Message.SetActive(true);
    }
    public void Operate_Message_Advertising()
    {
        Advertising_Message.SetActive(true);
    }


}
