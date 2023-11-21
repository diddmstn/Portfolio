using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public string MainSceneToLoad;
    public GameObject Operate_Opening;
    public Text tx;

    private string Opening_text1= "학교에 깜박하고 중요한 물건을 두고온 나는 \n\n\n결국 밤늦게 교실을 방문하게 되었다.";
    private string Opening_text2= "아무도 없고 어두운 빈 교실에서\n\n희미한 불빛이 보였고\n\n그 빛은 얼마전 옥상에서 뛰어내린\n\n반 친구 A의 핸드폰이었다.";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator _Typing()
    {
        yield return new WaitForSeconds(2f);

        for (int i=0;i<= Opening_text1.Length;i++)
        {
            tx.text = Opening_text1.Substring(0, i);

            yield return new WaitForSeconds(0.15f);

        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i <= Opening_text2.Length; i++)
        {
            tx.text = Opening_text2.Substring(0, i);

            yield return new WaitForSeconds(0.15f);

        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(MainSceneToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void GameStart()
    {
        Operate_Opening.SetActive(true);
        StartCoroutine(_Typing());

    }

    public void SceneLoad()
    {
        SceneManager.LoadScene(MainSceneToLoad);
    }

    public void GameExit()
    {
        Application.Quit();
    }

}
