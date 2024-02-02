using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Character character;

    bool touch = false;
    public GameObject E_Text;
    DialogueManager dialogueManager;

    public int StartNum;
    public int EndNum;

    public static bool Event=false;
    public static bool FieldEvent=false;
    public static bool FieldEvent2=false;
    AudioSource audioSource;

    bool end;
    public GameObject GuideUI=null;
    public GameObject Character_Image;

    public GameObject Arrow = null;
    public enum Character
    {
        Cavel,//기사
        Chariot,//말
        Vnickle,//장로
        Drone
    }
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("Hints").transform.Find("Hint").transform.Find("Image").transform.Find("Text").transform.Find("HintText").GetComponent<Text>();
        GuideUI = GameObject.Find("Hints").transform.Find("Hint").gameObject;
        audioSource = GetComponent<AudioSource>();
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Arrow!=null&&Event==true)
        {
            Arrow.SetActive(true);
            
        }
        if(Player.PlayerActive==true)
        {
            Character_Image.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.E) && touch == true&&Player.PlayerActive==true)
        {
            if(dialogueManager.isDialogue == false)
            {
                switch (this.character)
                {
                    case Character.Cavel:
                        Cavel();
                        break;
                    case Character.Chariot:
                        Chariot();
                        break;
                    case Character.Vnickle:
                        Vnickle();
                        break;
                    case Character.Drone:
                        Drone();
                        break;

                }
            }
            
        }
    }
    void Cavel()//기사
    {
       if(FieldEvent2==true && StartNum < 24)
        {
            StartNum = 24;
            EndNum = 24;

        }
        else if (FieldEvent == true&&StartNum<16)
        {
            StartNum=15;
            EndNum=15;
        }
        else if (Event == true && StartNum == 5)
        {
            StartNum++;
            EndNum++;
        }
        

        ChatActive();
        if(StartNum==24)
        {
            StartNum++;
            EndNum++;
        }
        else if (StartNum ==6)
        {
            StartNum++;
            EndNum++;
        }
        else if (FieldEvent == true&& StartNum == 15)
        {
            StartNum++;
            EndNum++;
        }

    }
    void Chariot()//말
    {
        if(FieldEvent2==true && StartNum < 23)
        {
            StartNum = 22;
            EndNum = 22;
        }
        else if (FieldEvent == true&&StartNum<14)//13
        {
            StartNum = 13;
            EndNum = 13;
        }
        ChatActive();
        if (StartNum == 22)
        {
            Debug.Log(1);
            StartNum++;
            EndNum++;
        }
        else if (StartNum==1)
        {
            StartNum++;
            EndNum++;
        }
        else if (FieldEvent == true && StartNum == 13)
        {
            StartNum++;
            EndNum++;
        }

    }
    void Vnickle()//장로
    {
        if(FieldEvent2==true && StartNum < 21)
        {
            StartNum = 20;
            EndNum = 20;
        }
        else if (FieldEvent == true && StartNum < 18)
        {
            StartNum = 17;
            EndNum = 17;
        }
        else if (Event == true && StartNum == 3)
        {
            StartNum++;
            EndNum++;
        }
       
        ChatActive();
        if(StartNum == 20)
        {
            StartNum++;
            EndNum++;
        }
        else if (Event == false )
        {
            Event = true;

        }
         if(FieldEvent == true && StartNum == 17)
        {
            StartNum++;
            EndNum++;
        }

    }
    void Drone()
    {
       

    }
    void ChatActive()
    {
        audioSource.Play();
        InteractionEvent.DialogueStartNum = StartNum;
        InteractionEvent.DialogueEndNum = EndNum;

        dialogueManager.ActiveDialogue_UI();
        if (Character_Image != null)
        {
            Character_Image.SetActive(true);
        }
    }
  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.name == "Drone")
            {
                if (end == false)
                {
                    GuideUI.SetActive(true);
                    ChatActive();
                    Destroy(this.gameObject,1f);
                    end = true;

                }

            }
            else
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
