
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public GameObject Book;
    public GameObject Page2;
    public GameObject Page1;
    public GameObject Menu;
    public GameObject Adventure;
    public GameObject Inventory;
    public GameObject Shop;

    public  Text CoinText;


    public static int TotalCoin=0;
    
    void Start()
    {
        Time.timeScale = 1;
      //  CoinText = GameObject.Find("coin");
    }    
    void Update()
    {
       //TotalCoin += AdventureUI_Manager.Coin;
       CoinText.text = "" + TotalCoin;
    }
    public void BookActive()
    {
        Page2.SetActive(false);
        if (Book.activeSelf==true)
        {
            Book.SetActive(false);
        }
        else
        {
            Page1.SetActive(true);
            Book.SetActive(true);
        }
      
    }

    public void MenuActive()
    {
        if (Menu.activeSelf == true)
        {
            Menu.SetActive(false);
        }
        else
            Menu.SetActive(true);
    }

    public void AdventureActive()
    {
        if (Adventure.activeSelf == true)
        {
            Adventure.SetActive(false);
        }
        else
            Adventure.SetActive(true);
    }

    public void InventoryActive()
    {
        if (Inventory.activeSelf == true)
        {
            Inventory.SetActive(false);
        }
        else
            Inventory.SetActive(true);
    }

    //public static void GetCoin()
    //{
    //    TotalCoin += 100;
    // //   CoinText.text = "" + TotalCoin;
    //}

    public void Stage1Active()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void ShopActive()
    {
        if (Shop.activeSelf == true)
        {
            Shop.SetActive(false);
        }
        else
            Shop.SetActive(true);
    }

    public void Page2Active()
    {
        if (Page2.activeSelf == true)
        {
            Page1.SetActive(true);
            Page2.SetActive(false);
        }
        else
        {
          
            Page1.SetActive(false);
            Page2.SetActive(true);
        }
           

    }

   



}
