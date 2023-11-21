using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdventureUI_Manager : MonoBehaviour
{
    
    public GameObject MenuButton;
    public Text CoinText;
    public GameObject ClearText;
    public GameObject PauseText;
    public int Coin;
    void Start()
    {
        Time.timeScale = 1;
        Coin = 0;
    }

    public void GetCoin()
    {
        Coin += 100;
        CoinText.text = ""+Coin;
    }
    
    public void MenuButtonActive()
    {
        ClearText.SetActive(false);
        if (MenuButton.activeSelf == true)
        {
            PauseText.SetActive(false);
            MenuButton.SetActive(false);
            Time.timeScale = 1;
           
        }
        else
        {
            Time.timeScale = 0;
            MenuButton.SetActive(true);
            PauseText.SetActive(true);
        }
           
            
    }

    public void Finish()
    {

        PauseText.SetActive(false);

        if (MenuButton.activeSelf == true)
        {
            ClearText.SetActive(false);
            MenuButton.SetActive(false);
            Time.timeScale = 1;

        }
        else
        {
            Time.timeScale = 0;
            MenuButton.SetActive(true);
            ClearText.SetActive(true);
        }
    }

    public void Home()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void Retry()
    {

        SceneManager.LoadScene("Stage1");
    }

}
