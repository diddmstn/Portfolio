using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    //스위치 순서에 맞게 넣기
    public Mechanism mechanism;

    public List<GameObject> LogicObjects = new List<GameObject>();
    List<PushButton> Buttons = new List<PushButton>();
    float Height;
    public LiquidSound liquidSound;
    AudioSource audioSource;

    [System.Serializable]
    public class LiquidSound
    {
        public AudioClip OilDown;
        public AudioClip OperateWrong;
       

    }
    public enum Mechanism
    {
        Height
    }
    private void Awake()
    {
        GetButton();
        audioSource = GetComponent<AudioSource>();
    }
    void GetButton()
    {
        int i;
        for (i = 0; i < LogicObjects.Count; i++)
        {
            Buttons.Add(LogicObjects[i].GetComponent<PushButton>());
        }
    }
   
    private void OnEnable()
    {
        if (this.mechanism == Mechanism.Height)
        {
            StartCoroutine(TransformHeigh_Active());

        }

    }
    
    void Clear()
    {
        //나중에 물내려가는 애니메이션
        audioSource.PlayOneShot(liquidSound.OilDown);
        Destroy(gameObject, 1.5f);
       // this.gameObject.des(false,1f);
    }

   

    IEnumerator TransformHeigh_Active()
    {
        // this.transform.position = new Vector3(108.5208f,, 0);
        Vector2 goal = new Vector2(108, -44.371f);
        while (true)
        {
            if (Vector2.Distance(transform.position, goal) == 0)
            {
                break;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, goal, 0.5f * Time.deltaTime);

            }
            yield return null;
        }

        int Sequence = 1;

        for (int i=0;i< LogicObjects.Count;)
        {
          //  Debug.Log("숫자부여 시작");

            if (Buttons[i].Active==true&&Buttons[i].Sequence==0)
            {
              //  Debug.Log("숫자부여");

                //높이조절
                Buttons[i].Sequence = Sequence;
              //  this.transform.position= new Vector2(108, Buttons[i].Heigh);
               goal= new Vector2(108, Buttons[i].Heigh);
                while(true)
                {
                    if(Vector2.Distance(transform.position,goal)==0)
                    {
                        break;
                    }
                    else
                    {
                        transform.position = Vector2.MoveTowards(transform.position, goal, 1f*Time.deltaTime);

                    }
                    yield return null;
                }

                // Debug.Log(Buttons[i].Sequence);
                Sequence++;
            }
          //  Debug.Log(transform.position.y);

            i++;
            if (i == LogicObjects.Count)
            {
                i = 0;
            }
            //모든 오브젝트가 숫자를 받으면 중단
            if(Sequence== LogicObjects.Count+1)
            {
                break;
            }
            //Debug.Log(Sequence);

            yield return null;
        }

        yield return null;



        for (int i = 0; i < LogicObjects.Count;)
        {
            if (Buttons[i].Sequence != i + 1)
            {
              //  this.transform.position = new Vector3(108,Height, 0);

                //모든 스위치 끄기,
                for (int j = 0; j < LogicObjects.Count;j++)
                {
                    Debug.Log("실패");
                    Buttons[j].Return();
                   // Debug.Log(Buttons[j].Active);
                  audioSource.PlayOneShot(liquidSound.OperateWrong);

                    yield return null;

                }
                StartCoroutine(TransformHeigh_Active());
                yield break;
            }
           
            i++;

           // yield break;
            yield return null;
        }
        goal = new Vector2(108, -47);
        while (true)
        {
            if (Vector2.Distance(transform.position, goal) == 0)
            {
                break;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, goal, 0.5f * Time.deltaTime);

            }
            yield return null;
        }
        Clear();
    }
}
