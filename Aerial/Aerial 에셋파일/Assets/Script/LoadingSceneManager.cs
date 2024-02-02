using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    UI_Manager ui;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("UIManager").GetComponent<UI_Manager>();


      // Time.timeScale = 1;

        ui.Title.SetActive(false);

        StartCoroutine(Test());
        
    }
   
    IEnumerator Test()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(UI_Manager.NextScene);
        asyncLoad.allowSceneActivation = false;
        if (GameObject.Find("GameManager") != null)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.destroy();

        }

        while (!asyncLoad.isDone)
        {
            if(asyncLoad.progress<0.9f)
            {
                if (UI_Manager.NextScene == "Town" || UI_Manager.NextScene == "Title")//Town, Title
                {
                    ui.Ability.SetActive(false);
                    ui.Hint.SetActive(false);
                    Player.inWater = false;

                    if (UI_Manager.NextScene == "Title")
                    {
                        ui.Title.SetActive(true);

                    }
                    Player.PlayerFuntion = 0;
                }
                else//tutorial, Field_1, retry
                {
                    ui.Ability.SetActive(true);
                    Player.PlayerFuntion = 3;
                    if(UI_Manager.NextScene == "Tutorial")
                    {
                        Player.PlayerFuntion = 0;

                    }
                    else
                    {
                        ui.Hint.SetActive(true);
                    }

                }

            }
            else
            {
                asyncLoad.allowSceneActivation = true;
               ui.StartCoroutine(ui.Fade_In(ui.Fade_image,0.01f));
                Time.timeScale = 1;

                yield break;
               

            }
            yield return null;

        }


    }


}
