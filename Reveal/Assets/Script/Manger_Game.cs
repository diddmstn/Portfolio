using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manger_Game : MonoBehaviour
{
    public Text MinTimeText;
    public Text MinTimeText2;
    public Text MaxTimeText;
    public Text PasswordText;
    public Text Note_PasswordText;
    public Text Gallery_PasswordText;


    public Text DayText;


    public GameObject MainLock;
    public GameObject MainScreen;
    public GameObject MenuScreen;
    public GameObject LockSolving;
    
    public GameObject ErrorText;
    public GameObject GalleryErrorText;
    public GameObject NoteErrorText;

    public GameObject Message_Apk;
    public GameObject Call_Apk;
    public GameObject Gallery_Apk;
    public GameObject Setting_Apk;
    public GameObject Note_Apk;

    public GameObject Album_LockSolving;
    public GameObject Note_LockSolving;

    public GameObject Operate_SecretAlbum;
    public GameObject Operate_7Note;

  


    // Start is called before the first frame update

    void Start()
    {
       

    }
    public class TimeUtils //현실 시간 가져오기
    {
        public string GetCurrentDate()
        {
            return DateTime.Now.ToString(("MM월dd일 HH:mm"));
        }

    }
    // Update is called once per frame
    void Update()
    {
        MinTimeText.text = DateTime.Now.ToString(("HH:mm"));
        MinTimeText2.text = DateTime.Now.ToString(("HH:mm"));
        MaxTimeText.text = DateTime.Now.ToString(("HH:mm"));
        DayText.text = DateTime.Now.ToString(("MM월dd일"));



    }

    public void Lock_Back()
    {
        LockSolving.SetActive(false);
    }
    //만약 잠금푸는중이 활성화가되면
    string[] Password = new string[4];
    string[] Gallery_Password = new string[4];
    string[] Note_Password = new string[4];
    int adsa = 0;
    int a = 0;
    int n = 0;
    

    //숫자 키보드 코드 따로빼야하는가
    public void Number1()
    {
        if(LockSolving.activeSelf)
        {
            if(adsa!=4)
            {
                Password[adsa] = "1";
                adsa++;
                PasswordText.text = Password[0] + Password[1] + Password[2] + Password[3];
            }
           
        }
        else if(Gallery_Apk.activeSelf)
        {
            if (a != 4)
            {
                Gallery_Password[a] = "1";
                a++;
                Gallery_PasswordText.text = Gallery_Password[0] + Gallery_Password[1] + Gallery_Password[2] + Gallery_Password[3];
            }
               
        }
        else if(Note_Apk.activeSelf)
        {
            if (n != 4)
            {
                Note_Password[n] = "1";
                n++;
                Note_PasswordText.text = Note_Password[0] + Note_Password[1] + Note_Password[2] + Note_Password[3];
            }
                
        }

    }
    public void Number2()
    {
        if (LockSolving.activeSelf)
        {
            if (adsa != 4)
            {
                Password[adsa] = "2";
                adsa++;
                PasswordText.text = Password[0] + Password[1] + Password[2] + Password[3];
            }
               
        }
        else if (Gallery_Apk.activeSelf)
        {
            if (a != 4)
            {
                Gallery_Password[a] = "2";
                a++;
                Gallery_PasswordText.text = Gallery_Password[0] + Gallery_Password[1] + Gallery_Password[2] + Gallery_Password[3];
            }
               

        }
        else if (Note_Apk.activeSelf)
        {
            if (n != 4)
            {
                Note_Password[n] = "2";
                n++;
                Note_PasswordText.text = Note_Password[0] + Note_Password[1] + Note_Password[2] + Note_Password[3];
            }
                
        }
    }
    public void Number3()
    {
        if (LockSolving.activeSelf)
        {
            if (adsa != 4)
            {
                Password[adsa] = "3";
                adsa++;
                PasswordText.text = Password[0] + Password[1] + Password[2] + Password[3];
            }
               
        }
        else if (Gallery_Apk.activeSelf)
        {
            if (a != 4)
            {
                Gallery_Password[a] = "3";
                a++;
                Gallery_PasswordText.text = Gallery_Password[0] + Gallery_Password[1] + Gallery_Password[2] + Gallery_Password[3];
            }
               
        }
        else if (Note_Apk.activeSelf)
        {
            if (n != 4)
            {
                Note_Password[n] = "3";
                n++;
                Note_PasswordText.text = Note_Password[0] + Note_Password[1] + Note_Password[2] + Note_Password[3];

            }
              
        }
    }
    public void Number4()
    {
        if (LockSolving.activeSelf)
        {
            if (adsa != 4)
            {
                Password[adsa] = "4";
                adsa++;
                PasswordText.text = Password[0] + Password[1] + Password[2] + Password[3];
            }
               
        }
        else if (Gallery_Apk.activeSelf)
        {
            if (a != 4)
            {
                Gallery_Password[a] = "4";
                a++;
                Gallery_PasswordText.text = Gallery_Password[0] + Gallery_Password[1] + Gallery_Password[2] + Gallery_Password[3];
            }
                
        }
        else if (Note_Apk.activeSelf)
        {
            if (n != 4)
            {
                Note_Password[n] = "4";
                n++;
                Note_PasswordText.text = Note_Password[0] + Note_Password[1] + Note_Password[2] + Note_Password[3];
            }
               
        }
    }
    public void Number5()
    {
        if (LockSolving.activeSelf)
        {
            if (adsa != 4)
            {
                Password[adsa] = "5";
                adsa++;
                PasswordText.text = Password[0] + Password[1] + Password[2] + Password[3];

            }
              
        }
        else if (Gallery_Apk.activeSelf)
        {
            if (a != 4)
            {
                Gallery_Password[a] = "5";
                a++;
                Gallery_PasswordText.text = Gallery_Password[0] + Gallery_Password[1] + Gallery_Password[2] + Gallery_Password[3];
            }
                
        }
        else if (Note_Apk.activeSelf)
        {
            if (n != 4)
            {
                Note_Password[n] = "5";
                n++;
                Note_PasswordText.text = Note_Password[0] + Note_Password[1] + Note_Password[2] + Note_Password[3];
            }
              
        }

    }
    public void Number6()
    {
        if (LockSolving.activeSelf)
        {
            if (adsa != 4)
            {
                Password[adsa] = "6";
                adsa++;
                PasswordText.text = Password[0] + Password[1] + Password[2] + Password[3];
            }

        }
        else if (Gallery_Apk.activeSelf)
        {
            if (a != 4)
            {
                Gallery_Password[a] = "6";
                a++;
                Gallery_PasswordText.text = Gallery_Password[0] + Gallery_Password[1] + Gallery_Password[2] + Gallery_Password[3];
            }

        }
        else if (Note_Apk.activeSelf)
        {
            if (n != 4)
            {
                Note_Password[n] = "6";
                n++;
                Note_PasswordText.text = Note_Password[0] + Note_Password[1] + Note_Password[2] + Note_Password[3];
            }
                
        }
    }
    public void Number7()
    {
        if (LockSolving.activeSelf)
        {
            if (adsa != 4)
            {
                Password[adsa] = "7";
                adsa++;
                PasswordText.text = Password[0] + Password[1] + Password[2] + Password[3];
            }
               
        }
        else if (Gallery_Apk.activeSelf)
        {
            if (a != 4)
            {
                Gallery_Password[a] = "7";
                a++;
                Gallery_PasswordText.text = Gallery_Password[0] + Gallery_Password[1] + Gallery_Password[2] + Gallery_Password[3];
            }
                
        }

        else if (Note_Apk.activeSelf)
        {
            if (n != 4)
            {
                Note_Password[n] = "7";
                n++;
                Note_PasswordText.text = Note_Password[0] + Note_Password[1] + Note_Password[2] + Note_Password[3];
            }
                
        }
    }
    public void Number8()
    {
        if (LockSolving.activeSelf)
        {
            if (adsa != 4)
            {
                Password[adsa] = "8";
                adsa++;
                PasswordText.text = Password[0] + Password[1] + Password[2] + Password[3];
            }
                
        }
        else if (Gallery_Apk.activeSelf)
        {
            if (a!= 4)
            {
                Gallery_Password[a] = "8";
                a++;
                Gallery_PasswordText.text = Gallery_Password[0] + Gallery_Password[1] + Gallery_Password[2] + Gallery_Password[3];
            }
                
        }
        else if (Note_Apk.activeSelf)
        {
            if (n != 4)
            {
                Note_Password[n] = "8";
                n++;
                Note_PasswordText.text = Note_Password[0] + Note_Password[1] + Note_Password[2] + Note_Password[3];
            }
               
        }
    }
    public void Number9()
    {
        if (LockSolving.activeSelf)
        {
            if (adsa != 4)
            {
                Password[adsa] = "9";
                adsa++;
                PasswordText.text = Password[0] + Password[1] + Password[2] + Password[3];
            }
                
        }
        else if (Gallery_Apk.activeSelf)
        {
            if (a != 4)
            {
                Gallery_Password[a] = "9";
                a++;
                Gallery_PasswordText.text = Gallery_Password[0] + Gallery_Password[1] + Gallery_Password[2] + Gallery_Password[3];
            }
                
        }
        else if (Note_Apk.activeSelf)
        {
            if (n != 4)
            {
                Note_Password[n] = "9";
                n++;
                Note_PasswordText.text = Note_Password[0] + Note_Password[1] + Note_Password[2] + Note_Password[3];
            }
               
        }
    }
    public void Number0()
    {
        if (LockSolving.activeSelf)
        {
            if (adsa != 4)
            {
                Password[adsa] = "0";
                adsa++;
                PasswordText.text = Password[0] + Password[1] + Password[2] + Password[3];
            }
                
        }
        else if (Gallery_Apk.activeSelf)
        {
            if (a != 4)
            {
                Gallery_Password[a] = "0";
                a++;
                Gallery_PasswordText.text = Gallery_Password[0] + Gallery_Password[1] + Gallery_Password[2] + Gallery_Password[3];
            }
                
        }

        else if (Note_Apk.activeSelf)
        {
            if (n != 4)
            {
                Note_Password[n] = "0";
                n++;
                Note_PasswordText.text = Note_Password[0] + Note_Password[1] + Note_Password[2] + Note_Password[3];
            }
        }
               
    }

    public void Lock()
    {
       

        if (MainLock.activeSelf)
        {
            LockSolving.SetActive(true);
        }
        if(Gallery_Apk.activeSelf)
        {
            Album_LockSolving.SetActive(true);

        }
        if (Note_Apk.activeSelf)
        {
            Note_LockSolving.SetActive(true);
        }

       

    }
    public void Enter()
    {
        if (LockSolving.activeSelf)
        {
            if (PasswordText.text == DateTime.Now.ToString(("1020")))
            {

                MainScreen.SetActive(true);
                Message_Apk.SetActive(false);

            }
            else if (PasswordText.text != "1020")
            {
                ErrorText.SetActive(true);

            }
        }
        if (Gallery_Apk.activeSelf)
        {
            if (Gallery_PasswordText.text == DateTime.Now.ToString("MMdd"))
            {

                Album_LockSolving.SetActive(false);
                Operate_SecretAlbum.SetActive(true);


            }
            else if (Gallery_PasswordText.text != DateTime.Now.ToString("MMdd")
            {

                GalleryErrorText.SetActive(true);

            }
        }
        if (Note_Apk.activeSelf)
        {
            if (Note_PasswordText.text == "1218")
            {

                Note_LockSolving.SetActive(false);
                Operate_7Note.SetActive(true);


            }
            else if (Note_PasswordText.text != "1218")
            {

                NoteErrorText.SetActive(true);

            }
        }


    }
   
    public void Backspace()
    {
        ErrorText.SetActive(false);
        GalleryErrorText.SetActive(false);
        NoteErrorText.SetActive(false);
      
        if (LockSolving.activeSelf)
        {
            if (PasswordText.text.Length > 0)
            {

                PasswordText.text = PasswordText.text.Substring(0, PasswordText.text.Length - 1);
                adsa--;
                Password[adsa] = " ";

            }
        }
        if (Gallery_Apk.activeSelf)
        {
            if (Gallery_PasswordText.text.Length > 0)
            {

                Gallery_PasswordText.text = Gallery_PasswordText.text.Substring(0, Gallery_PasswordText.text.Length - 1);
                a--;
                Gallery_Password[a] = " ";

            }
        }
        if (Note_Apk.activeSelf)
        {
            if (Note_PasswordText.text.Length > 0)
            {

                Note_PasswordText.text = Note_PasswordText.text.Substring(0, Note_PasswordText.text.Length - 1);
                n--;
                Note_Password[n] = " ";

            }
        }

    }

    public void Home()
    {

        MenuScreen.SetActive(false);
        Call_Apk.SetActive(false);
        Note_Apk.SetActive(false);
        Gallery_Apk.SetActive(false);
        Message_Apk.SetActive(false);
        MainScreen.SetActive(true);
    }
   
   

    public void Menu()
    {
        LockSolving.SetActive(false);
        MainLock.SetActive(false);
        MenuScreen.SetActive(true);
    }



}
