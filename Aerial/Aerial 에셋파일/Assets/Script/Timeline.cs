using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Timeline : MonoBehaviour
{
    public PushButton Button;
    public Gate gate;
    PlayableDirector director;
    public Event TimelineEvent;
    DialogueManager dialogueManager;

    AudioSource audioSorce;
    public GameObject speakerImage;

    public int StartNum;
    public int EndNum;

    // Start is called before the first frame update
    
    void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        director = GetComponent<PlayableDirector>();
        audioSorce = GetComponent<AudioSource>();
        if(this.TimelineEvent==Event.Circle)
        {
            StartCoroutine(ICircleDrop());
        }
    }
    public enum Event
    {
        Circle,
        PlayTimeline
    }
    public void Field1_Event()
    {
        //StartNum = 1;
        //EndNum = 1;
        PlyaDialogueEvent();
        Destroy(this.gameObject, 1f);
    }
   
    public void Sector1_EventActive()
    {
        speakerImage.SetActive(true);
       StartNum = 1;
        EndNum = 1;
        PlyaDialogueEvent();
        StartCoroutine(Sector1());

    }
    public void Sector2_EventActive()
    {
        Player.PlayerFuntion++;
        StartNum = 3;
        EndNum = 3;
        PlyaDialogueEvent();
        StartCoroutine(Sector2());


    }
    public void Sector3_EventActive()
    {

        StartNum = 5;
        EndNum = 5;
        PlyaDialogueEvent();
        StartCoroutine(Sector3());
    }
    public void Sector4_EventActive()
    {
        Player.PlayerFuntion++;

        StartNum = 7;
        EndNum = 7;
        PlyaDialogueEvent();
        StartCoroutine(Sector4());
    }

   
    IEnumerator ICircleDrop()
    {
        while(true)
        {
            if (Button.Active == true)
            {
               director.enabled = true;
                yield break;
            }

            yield return null;

        }

    }
    void PlyaDialogueEvent()
    {
        audioSorce.Play();

        InteractionEvent.DialogueStartNum = StartNum;
        InteractionEvent.DialogueEndNum = EndNum;

        dialogueManager.ActiveDialogue_UI();
    }
    IEnumerator Sector1()
    {
        
        while (true)
        {
            if (Button.Active == true)
            {
                StartNum = 2;
                EndNum = 2;
                PlyaDialogueEvent();
                audioSorce.Play();

                Destroy(this.gameObject, 1f);

                yield break;
            }
            yield return null;

        }
    }
    IEnumerator Sector2()
    {

        while (true)
        {
            if (gate.Solve == true)
            {
                StartNum = 4;
                EndNum = 4;
                PlyaDialogueEvent();
                audioSorce.Play();

                Destroy(this.gameObject, 1f);


                yield break;
            }
            yield return null;

        }
    }
    IEnumerator Sector3()
    {

        while (true)
        {
            if (gate.Solve == true)
            {
                StartNum = 6;
                EndNum = 6;
                PlyaDialogueEvent();
                audioSorce.Play();

                Destroy(this.gameObject,1f);

                yield break;
            }
            yield return null;

        }
    }
    IEnumerator Sector4()
    {

        while (true)
        {
            if (gate.Solve == true)
            {
                StartNum = 8;
                EndNum = 8;
                PlyaDialogueEvent();
                audioSorce.Play();

                Destroy(this.gameObject, 1f);


                yield break;
            }
            yield return null;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            director.enabled =true;
        }
    }
}
