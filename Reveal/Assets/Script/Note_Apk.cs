using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Apk : MonoBehaviour
{
    public GameObject OperateNote;
    public GameObject MenuScreen;

    public GameObject Twenty_Note;
    public GameObject Fifteen_Note;
    public GameObject Ten_Note;
    public GameObject Eight_Note;
    public GameObject Seven_Note;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Note()
    {
        OperateNote.SetActive(true);
    }

    public void Operate_Twenty_Note()
    {
        Twenty_Note.SetActive(true);
    }
    public void Operate_Fifteen_Note()
    {
        Fifteen_Note.SetActive(true);
    }
    public void Operate_Ten_Note()
    {
        Ten_Note.SetActive(true);
    }
    public void Operate_Eight_Note()
    {
        Eight_Note.SetActive(true);
    }
    public void Operate_Seven_Note()
    {
        Seven_Note.SetActive(true);
    }

    public void Back()
    {

        OperateNote.SetActive(false);
        MenuScreen.SetActive(true);
    }

    public void NoteBack()
    {
        Twenty_Note.SetActive(false);
        Seven_Note.SetActive(false);
        Eight_Note.SetActive(false);
        Fifteen_Note.SetActive(false);
        Ten_Note.SetActive(false);
    }


}
