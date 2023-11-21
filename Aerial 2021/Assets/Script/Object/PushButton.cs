using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    Vector3 ButtonMove = new Vector3(0, 0.076f, 0);
    public Type type;
    [HideInInspector] public  bool Active = false;
     public float Heigh=0;
     public int Sequence = 0;
    public GameObject ActiveObject=null;
    AudioSource audioSource;
    public ButtonSound buttonSound;

    public bool ButtonReturn= false ;

    public int ReturnCount;
    public int Count ;

    public List<Animator> ActiveAnimator = new List<Animator>();


    [System.Serializable]
    public class ButtonSound
    {
        public AudioClip ButtonAcive;
       // public AudioClip OilActive;
       

    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Count = 1;

    }
   
    public enum Type
    {
        LeftRight,
        LeftRight_Reverse,
        UpDown_Reverse,
        UpDown,
        massButton
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (this.type == Type.massButton)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("Box"))
            {

                if (Active == false)
                {
                    if (ActiveObject != null)
                    {
                        ActiveObject.SetActive(true);
                    }
                     this.transform.localPosition += new Vector3(0, -0.15f, 0f);
                    Active = true;
                }

            }
        }
        if (collision.gameObject.CompareTag("Player")&& this.type != Type.massButton)
        {
            if(Active==false)
            {
                switch (type)
                {
                    case Type.LeftRight:
                        this.transform.localScale = new Vector3(-1, -1, 1);
                        break;
                    case Type.LeftRight_Reverse:
                        this.transform.localScale = new Vector3(1, -1, 1);
                        break;
                    case Type.UpDown_Reverse:
                        this.transform.position -= ButtonMove;
                        break;
                    case Type.UpDown:
                        this.transform.position += ButtonMove;
                        break;
                 
                        
                }
                Active = true;
                audioSource.PlayOneShot(buttonSound.ButtonAcive);

                if (ActiveAnimator != null)
                {
                    for (int i = 0; i < ActiveAnimator.Count;i++)
                    {
                        if(ActiveAnimator[i].enabled == true)
                        {
                            ActiveAnimator[i].enabled = false;

                        }
                        else
                        {
                            ActiveAnimator[i].enabled = true;

                        }
                    }
                }
              

                if (ActiveObject!=null)
                {
                    if( ButtonReturn != true)
                    {
                        if (ActiveObject.CompareTag("Oil"))
                        {
                           // audioSource.PlayOneShot(buttonSound.OilActive);

                            Destroy(ActiveObject, 3f);
                        }
                        if (ActiveObject.activeSelf == false)
                        {
                            ActiveObject.SetActive(true);
                        }
                        else
                        {
                            ActiveObject.SetActive(false);

                        }
                    }
                    else
                    {
                        ActiveObject.SetActive(true);

                    }

                }
            }
            if (ButtonReturn == true)
            {
                //버튼 클릭반복
                if (ReturnCount > Count)
                {
                    Count++;
                    Invoke("Return", 2f);

                }
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.type == Type.massButton)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("Box"))
            {

                if (Active == false)
                {
                    this.transform.localPosition += new Vector3(0, -0.15f, 0f);
                    Active = true;
                }

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.type == Type.massButton)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("Box"))
            {
                if(Active==true)
                {
                    this.transform.localPosition += new Vector3(0, 0.15f, 0);
                    Active = false;
                }
              

            }
        }
    }
    public void Return()
    {

        if (Active == true)
        {
            switch (type)
            {
                case Type.LeftRight:
                    this.transform.localScale = new Vector3(-1, 1, 1);
                    break;
                case Type.UpDown_Reverse:
                    this.transform.position += ButtonMove;
                    break;
                case Type.UpDown:
                    this.transform.position -= ButtonMove;
                    break;
                
            }
            Sequence = 0;
            Active = false;


        }

        if (ActiveAnimator != null)
        {
            for (int i = 0; i < ActiveAnimator.Count; i++)
            {
                if (ActiveAnimator[i].enabled == true)
                {
                    ActiveAnimator[i].enabled = false;

                }
                else
                {
                    ActiveAnimator[i].enabled = true;

                }
            }
        }
    }

    
}
