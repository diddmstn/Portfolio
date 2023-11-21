using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    


    public GameObject TrueEnding;
    public GameObject NormalEnding;
    public GameObject BadEnding;

    public GameObject TrueEndingOperate;
    public GameObject NormalEndingOperate;
    public GameObject BadEndingOperate;

    public GameObject Ending_BG;
    public GameObject TrueEnding_BG;
    public GameObject BadEnding_BG;
    public GameObject NormalEnding_BG;

    public GameObject ChooseEnding;

    public string TitleSceneToLoad;

    public Text TrueEndingText;
    public Text NormalEndingText;
    public Text BadEndingText;

    private string BadEnding_text1 = "\"A의 핸드폰을 찾아줘서 고마워 \n나한테 A는 정말 소중한 친구였어....\"\n\n\n\"근데 핸드폰 열어봤어?\"";
    private string BadEnding_text2 = "그제서야 무언가 잘못되었다는\n\n느낌이 들었다.";

    private string NormalEnding_text1 = "\n\"고맙다 이 핸드폰은 선생님이 \nA의 가족분들에게 잘 전달해줄게\"";
    private string NormalEnding_text2 = "선생님께 핸드폰을 드리면서도 \n찝찝한 기분을 지울수가 없다. \n\n\n좀더 핸드폰을 찾아봤어야했나?";

    private string TrueEnding_text1 = "A의 죽음에 대한 진실을 찾은 나는 \n핸드폰을 가지고 바로 경찰서로 갔다.";
    private string TrueEnding_text2 = "그리고...A의 핸드폰을 통해 숨겨졌던 \n진실이 세상에 밝혀졌다.";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator _Typing()
    {
         yield return new WaitForSeconds(1f);

        if(BadEnding.activeSelf)
        {
            for (int i = 0; i <= BadEnding_text1.Length; i++)
            {
                BadEndingText.text = BadEnding_text1.Substring(0, i);

                yield return new WaitForSeconds(0.15f);

            }
            yield return new WaitForSeconds(1f);

            for (int i = 0; i <= BadEnding_text2.Length; i++)
            {
                BadEndingText.text = BadEnding_text2.Substring(0, i);

                yield return new WaitForSeconds(0.15f);

            }
            yield return new WaitForSeconds(1f);

            BadEnding.SetActive(false);
            Ending_BG.SetActive(true);
            BadEndingOperate.SetActive(true);
            BadEnding_BG.SetActive(true);
        }

        if (NormalEnding.activeSelf)
        {
            for (int i = 0; i <= NormalEnding_text1.Length; i++)
            {
                NormalEndingText.text = NormalEnding_text1.Substring(0, i);

                yield return new WaitForSeconds(0.15f);

            }
            yield return new WaitForSeconds(1f);

            for (int i = 0; i <= NormalEnding_text2.Length; i++)
            {
                NormalEndingText.text = NormalEnding_text2.Substring(0, i);

                yield return new WaitForSeconds(0.15f);

            }

            yield return new WaitForSeconds(1f);

            NormalEnding.SetActive(false);
            Ending_BG.SetActive(true);
            NormalEndingOperate.SetActive(true);
            NormalEnding_BG.SetActive(true);
        }

        if (TrueEnding.activeSelf)
        {
            for (int i = 0; i <= TrueEnding_text1.Length; i++)
            {
                TrueEndingText.text = TrueEnding_text1.Substring(0, i);

                yield return new WaitForSeconds(0.15f);

            }
            yield return new WaitForSeconds(1f);

            for (int i = 0; i <= TrueEnding_text2.Length; i++)
            {
                TrueEndingText.text = TrueEnding_text2.Substring(0, i);

                yield return new WaitForSeconds(0.15f);

            }

            yield return new WaitForSeconds(1f);

            TrueEnding.SetActive(false);
            Ending_BG.SetActive(true);
            TrueEndingOperate.SetActive(true);
            TrueEnding_BG.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Operate_True_Ending()
    {
        ChooseEnding.SetActive(false);
        TrueEnding.SetActive(true);
        StartCoroutine(_Typing());

    }
    public void Operate_Normal_Ending()
    {
        ChooseEnding.SetActive(false);
        NormalEnding.SetActive(true);
        StartCoroutine(_Typing());

    }
    public void Operate_Bad_Ending()
    {
        ChooseEnding.SetActive(false);
        BadEnding.SetActive(true);
        StartCoroutine(_Typing());

    }

    public void Title()
    {
        SceneManager.LoadScene(TitleSceneToLoad);
    }

 

}
