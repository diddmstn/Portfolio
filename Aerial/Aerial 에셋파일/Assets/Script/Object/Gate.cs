using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public  Logic logic;
    public List<GameObject> GateObjects = new List<GameObject>();
    List<PushButton> TimerObjects = new List<PushButton>();
    Animator ani;

    public Pipe pipe = null;
    public PushButton Button = null;

    AudioSource audioSource;
    public GateSound gateSound;

    [SerializeField]
    public bool Solve=false;

    [System.Serializable]
    public class GateSound
    {
        public AudioClip TimerSound;
        public AudioClip GateOpen;
        public AudioClip TimerBuzzer;
       

    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ani = GetComponent<Animator>();
        ani.keepAnimatorControllerStateOnDisable = true;

        switch (logic)
        {
            case Logic.Timer:
                TimerActive();
                break;
            case Logic.ObjectDestroy:
                StartCoroutine(ObjectDestroyActive());
                break;
            case Logic.ButtonCheck:
                StartCoroutine(ButtonCheckActive());
                break;
        }
    }
    public enum Logic
    {
        Timer,
        Operate,
        Close,
        ObjectDestroy,
        ButtonCheck,
        AbilityOpen
    }
    private void Update()
    {
        if (Player.Die==true)
        {
            audioSource.Stop();
        }
        if(this.logic==Logic.Operate&&Solve==false)
        {
            if(pipe!=null)
            {
                if (pipe.Active == true)
                {
                    GateOpen();
                }
            }
            else if(Button!=null)
            {
                if (Button.Active == true)
                {
                    GateOpen();
                    
                }
            }

        }
        else if(this.logic==Logic.AbilityOpen==true&&Solve==false)
        {
            if(Player.AbilityActive==true)
            {
                GateOpen();
            }
        }

    }
    IEnumerator ButtonCheckActive()
    {
        List<PushButton> ButtonCheckObj = new List<PushButton>();

        for (int i = 0; i < GateObjects.Count; i++)
        {
            ButtonCheckObj.Add(GateObjects[i].GetComponent<PushButton>());
            yield return null;
        }
        int count;

        while (true)
        {
            count = 0;
            for (int i = 0; i < GateObjects.Count; i++)
            {
                if (ButtonCheckObj[i].Active==true)
                {
                    count ++;
                }
            }
            if (count == GateObjects.Count)
            {
                GateOpen();
                break;
            }
            yield return null;
        }
    }
    IEnumerator ObjectDestroyActive()
    {
        int count = GateObjects.Count;
        while(true)
        {
            int Check = count;
            for(int i=0; i<count;i++)
            {
                if (GateObjects[i] == null)
                {
                    Check--;
                }
            }
            if(Check==0)
            {
                GateOpen();
                break;
            }
            yield return null;

        }
        yield return null;
    }


    private void OnEnable()
    {
        switch (logic)
        {
            case Logic.Timer:
                StartCoroutine(Timer());
                break;
         
        }
    }
   
    void GateOpen()
    {

        //gate 애니메이션 열리는거 실행
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(gateSound.GateOpen);

        }
        Solve = true;
        ani.Play("Gate_Open");
    }
    

    void TimerActive()
    {
        int i;
        for (i = 0; i < GateObjects.Count; i++)
        {
            TimerObjects.Add(GateObjects[i].GetComponent<PushButton>());
        }
    }
    IEnumerator Timer()
    {
        int i;

        for (i = 0; i < GateObjects.Count; i++)
        {
            TimerObjects.Add(GateObjects[i].GetComponent<PushButton>());
        }
        //Debug.Log(TimerObjects[0].Active);

        for ( i = 0; i < GateObjects.Count;)//받은 오브젝트가 하나라도 작동하는지 확인
        {
       // Debug.Log(TimerObjects.Count);

            if (TimerObjects[i].Active== true)
            {
                if(audioSource.isPlaying==false)
                {
                    audioSource.PlayOneShot(gateSound.TimerSound);

                }
                break;
            }
             i++;
            if (i == GateObjects.Count)
            {
                i = 0;
            }
            yield return null; //없으면 유니티 죽음
        }

        yield return new WaitForSeconds(5f);
        int count = 0;
        for ( i = 0; i < GateObjects.Count;)//5초지난후 오브젝트 모두 작동했는지 확인
        {
            if (TimerObjects[i].Active == true)
            {
                count++;
            }
            i++;
        }

        if (count == GateObjects.Count)
        {
            Debug.Log("성공");
            audioSource.Stop();
            GateOpen();

            yield break;

        }
        else
        {
            audioSource.PlayOneShot(gateSound.TimerBuzzer);
            Debug.Log("실패");
            for (i = 0; i < GateObjects.Count; i++)
            {
                if (TimerObjects[i].Active==true)
                {
                    TimerObjects[i].Return();
                }
              
            }
            StartCoroutine(Timer());
           audioSource.Stop();
            yield break;
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ani.Play("Gate_Close");
        }
       
    }
}
