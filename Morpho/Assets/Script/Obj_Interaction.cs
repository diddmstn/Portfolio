using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Obj_Interaction : MonoBehaviour
{

    public Animator Cage_animator;

    Player player;
    Inventory inventory;

    public bool usewater = false;

    public Text InteractionMessage;
    public GameObject InteractionImage;
    public GameObject YesorNo;
    public GameObject ClockUI;

    public GameObject E;

  
    void Awake()//start로 바꾸지 말것
    {
        Cage_animator.SetBool("Check", false);

    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        inventory=GameObject.Find("Canvas").GetComponent<Inventory>();
        inventory.SetSlot();
    }


    public void Interaction()
    {

        //클락 유아이가 실행중이면 e버튼 클릭못하게
        if (ClockUI.activeSelf)
        {
            InteractionImage.SetActive(false);
        }
        else if (player.objectName == "CageDoor")
        {
            Cage_Door();

        }
        else if (player.objectName == "ClockFace")
        {
            Clock();
        }
        else if (player.objectName == "doorWing")
        {
            Door();
        }
        else if (player.objectName == "picture1")
        {
            Picture1();
        }
        else if (player.objectName == "picture2")
        {
            Picture2();
        }
        else if (player.objectName == "Bottle")
        {
            Bottle();
        }
        else if (player.objectName == "Pot")
        {
            Pot();
        }
        else if (player.objectName == "FirePlace")
        {
            FirePlace();
        }
        else if (player.objectName == "Bucket")
        {
            Bucket();
        }
        else if (player.objectName == "Paper1500")
        {
            Paper1500();
        }
        else if (player.objectName == "Books")
        {
            Books();
        }
        else if (player.objectName == "Chest")
        {
            Chest();
        }
        else if (player.objectName == "Barrel")
        {
            Barrel();
        }
        else if (player.objectName=="Window")
        {
           Window();
        }
        // Debug.Log(player.objectName);
    }
    void Window()
    {
        if (!InteractionImage.activeSelf)
        {
            Time.timeScale = 0;
            InteractionImage.SetActive(true);
            if (SceneManager.GetActiveScene().name == "Time0700")
            {
                InteractionMessage.text = "창문으로 해가 뜨는 것이 보인다.";
            }
            else if (SceneManager.GetActiveScene().name == "Time1124")
            {
                InteractionMessage.text = "바람이 부는게 느껴진다.";
            }
            else if (SceneManager.GetActiveScene().name == "Time1500")
            {
                InteractionMessage.text = "밖에 비가 내리는게 보인다.";
            }
            else if (SceneManager.GetActiveScene().name == "Time1931")
            {
                InteractionMessage.text = "점점 날이 어두워지고 있다.";
            }
            else if (SceneManager.GetActiveScene().name == "Time2052")
            {
                InteractionMessage.text = "밖에 달이 뜨는 것이 보인다.";
            }
        }
        else if (InteractionImage.activeSelf)
        {
            Time.timeScale = 1;
            InteractionImage.SetActive(false);

        }
    }
    void Barrel()
    {
        if (!InteractionImage.activeSelf)
        {
            Time.timeScale = 0;
            InteractionImage.SetActive(true);
            InteractionMessage.text = "불을 붙일 때 사용한것 같은 기름통이다. 조금 기름이 남아있다.";
            for (int i = 0; i < inventory.items.Count; i++)
            {
                if (inventory.items[i].itemName == "작은 병")
                {
                    inventory.items[i].itemName = "기름이 든 작은 병";
                    inventory.SetSlot();
                    InteractionMessage.text = "불을 붙일 때 사용한것 같은 기름통이다. 가지고있던 작은 병에 기름을 담았다.";

                    //벽난로 파티클 끄기 
                }
                else if (inventory.items[i].itemName == "기름이 든 작은 병")
                {
                    InteractionMessage.text = "불을 붙일 때 사용한것 같은 기름통이다. 남은 기름은 이미 병에 담았다.";

                }
                else if (inventory.items[i].itemName == "사용 한 병")
                {
                    InteractionMessage.text = "불을 붙일 때 사용한것 같은 기름통이다. 남은 기름은 이미 병에 담았다.";

                }
            }
        }
        else if (InteractionImage.activeSelf)
        {
            Time.timeScale = 1;
            InteractionImage.SetActive(false);

        }

    }
    void Chest()
    {
        if (!InteractionImage.activeSelf)
        {
            Time.timeScale = 0;
            InteractionImage.SetActive(true);
            InteractionMessage.text = "잠겨있지는 않지만 녹슬어서 열 수 없다.";
            for (int i = 0; i < inventory.items.Count; i++)
            {
                if (inventory.items[i].itemName == "기름이 든 작은 병")
                {
                    inventory.items[i].itemName = "사용 한 병";
                    inventory.SetSlot();
                    InteractionMessage.text = "녹슨 상자를 가지고있던 기름 병으로 열고 20:52라 쓰여있는 쪽지를 얻었다.";

                    //벽난로 파티클 끄기 
                }
                else if (inventory.items[i].itemName == "사용 한 병")
                {
                    InteractionMessage.text = "녹슨 상자를 가지고있던 기름 병으로 열고 20:52라 쓰여있는 쪽지를 얻었다.";

                }

            }

        }
        else if (InteractionImage.activeSelf)
        {
            Time.timeScale = 1;
            InteractionImage.SetActive(false);

        }
        
    }
    void Books()
    {
        if (!InteractionImage.activeSelf)
        {
            Time.timeScale = 0;
            InteractionImage.SetActive(true);
            InteractionMessage.text = "책이 쌓여있다. 딱히 중요한건 없을 것 같다.";
        }
        else if (InteractionImage.activeSelf)
        {
            Time.timeScale = 1;
            InteractionImage.SetActive(false);

        }
    }
    void Bucket()
    {
        if(!InteractionImage.activeSelf)
        {
            Time.timeScale = 0;
            InteractionImage.SetActive(true);
            YesorNo.SetActive(true);
            InteractionMessage.text = "사용할수 있을 것 같은 나무 양동이다. 가져갈까?";

        }
        else if (InteractionImage.activeSelf)
        {
            Time.timeScale = 1;
            InteractionImage.SetActive(false);
            YesorNo.SetActive(false);
        }
    }
    void Cage_Door()
    {
        Time.timeScale = 1;
        Cage_animator.SetBool("Check", true);
    }

    void Door()
    {
        if (!InteractionImage.activeSelf)
        {
            Time.timeScale = 0;
            InteractionImage.SetActive(true);
            InteractionMessage.text = "잠겨있다.";
        }
        else if (InteractionImage.activeSelf)
        {
            Time.timeScale = 1;
            InteractionImage.SetActive(false);

        }
    }
    void Clock()
    {
        
        if (!InteractionImage.activeSelf)
        {
            Time.timeScale = 0;
            InteractionImage.SetActive(true);
            YesorNo.SetActive(true);
            InteractionMessage.text = "낡은 시계다. 시간을 바꿀까?";

        }
        else if (InteractionImage.activeSelf)
        {
            Time.timeScale = 1;
            InteractionImage.SetActive(false);
            YesorNo.SetActive(false);
        }


    }
    void Picture1()
    {
        if (!InteractionImage.activeSelf)
        {
            Time.timeScale = 0;
            InteractionImage.SetActive(true);
            InteractionMessage.text = "살바도르 달리,기억의 지속,1931.";
        }
        else if (InteractionImage.activeSelf)
        {
            Time.timeScale = 1;
            InteractionImage.SetActive(false);

        }
    }
    void Picture2()
    {
        if (!InteractionImage.activeSelf)
        {
            Time.timeScale = 0;
            InteractionImage.SetActive(true);
            InteractionMessage.text = "평범한 시계사진이다.";
        }
        else if (InteractionImage.activeSelf)
        {
            Time.timeScale = 1;
            InteractionImage.SetActive(false);

        }
    }
    void Bottle()
    {
        if (!InteractionImage.activeSelf)
        {
            Time.timeScale = 0;
            InteractionImage.SetActive(true);
            YesorNo.SetActive(true);
            InteractionMessage.text = "작은 병이다. 가져갈까?";

        }
        else if (InteractionImage.activeSelf)
        {
            Time.timeScale = 1;
            InteractionImage.SetActive(false);
            YesorNo.SetActive(false);
        }
    }
    void Pot()
    {
        if (!InteractionImage.activeSelf)
        {
            Time.timeScale = 0;
            if (SceneManager.GetActiveScene().name == "Time1500")
            {
                if (GameObject.Find("Pots").transform.position != new Vector3(17f, 11f, 18f))
                {
                    InteractionImage.SetActive(true);
                    InteractionMessage.text = "항아리를 옮길수 없다.";
                   
                }
                else if (GameObject.Find("Pots").transform.position == new Vector3(17f, 11f, 18f))
                {
                    InteractionImage.SetActive(true);
                    InteractionMessage.text = "벽에서 비가새는지 옮겨둔 항아리에 물이 고여있다.";

                    for (int i = 0; i < inventory.items.Count; i++)
                    {
                        if (inventory.items[i].itemName == "나무 양동이")
                        {
                            InteractionMessage.text = "나무 양동이로 물을 퍼서 물이 든 양동이를 얻었다.";
                       
                            inventory.items[i].itemName = "물이 든 양동이";
                            inventory.SetSlot();
                            
                        }
                       

                    }
                }
            }
            else if (SceneManager.GetActiveScene().name != "Time1500")
            {
                if (GameObject.Find("Pots").transform.position != new Vector3(17f, 11f, 18f))
                {
                    Time.timeScale = 0;
                    InteractionImage.SetActive(true);
                    YesorNo.SetActive(true);
                    InteractionMessage.text = "낡은 항아리들이 모여있습니다. 옮기시겠습니까?";
                }
                if (GameObject.Find("Pots").transform.position == new Vector3(17f, 11f, 18f))
                {
                    Time.timeScale = 0;
                    InteractionImage.SetActive(true);
                    YesorNo.SetActive(true);
                    InteractionMessage.text = "항아리들을 다시 제자리로 옮기시겠습니까?";
                }
            }
               

        }
        else if (InteractionImage.activeSelf)
        {
            Time.timeScale = 1;
            InteractionImage.SetActive(false);
            YesorNo.SetActive(false);
        }
    }
    void FirePlace()
    {
        if (!InteractionImage.activeSelf)
        {
            if(SceneManager.GetActiveScene().name=="Time1931")
            {
                Time.timeScale = 0;
                InteractionImage.SetActive(true);

                InteractionMessage.text = "더이상 다가가기 힘들 것 같다. 물로 불을 끌수 있을 것 같다.";
                for (int i = 0; i < inventory.items.Count; i++)
                {
                    if (inventory.items[i].itemName == "물이 든 양동이")
                    {
                        inventory.items[i].itemName = "빈 양동이";
                        inventory.SetSlot();
                        InteractionMessage.text = "가지고있던 물이 든 양동이로 불을 끄고 11:24분이라 적혀있는 쪽지를 얻었다.";
                        usewater = true;

                        //벽난로 파티클 끄기 
                    }
                    else if(inventory.items[i].itemName == "빈 양동이")
                    {
                        InteractionMessage.text = "가지고있던 물이 든 양동이로 불을 끄고 11:24분이라 적혀있는 쪽지를 얻었다.";
                       
                    }
                   
                }
               
            }
           else if(SceneManager.GetActiveScene().name != "Time1931")
            {
                Time.timeScale = 0;
                InteractionImage.SetActive(true);
                InteractionMessage.text = "벽난로다.";
            }
          

        }
        else if (InteractionImage.activeSelf)
        {
            Time.timeScale = 1;
            InteractionImage.SetActive(false);
            YesorNo.SetActive(false);
        }
    }
    void Paper1500()
    {
        if (!InteractionImage.activeSelf)
        {
            Time.timeScale = 0;
            InteractionImage.SetActive(true);
            InteractionMessage.text = "15:00 라고 적혀있다";
        }
        else if (InteractionImage.activeSelf)
        {
            Time.timeScale = 1;
            InteractionImage.SetActive(false);

        }
    }
    public void Yes_Button()
    {
        InteractionImage.SetActive(false);
        YesorNo.SetActive(false);
        if (player.objectName == "ClockFace")
        {
            ClockUI.SetActive(true);
           
        }
        else if (player.objectName == "Bottle")
        {
            Item Bottle = GameObject.Find("Bottle").GetComponent<Item>();
            inventory.items.Add(Bottle);
            inventory.SetSlot();
            Bottle.GetComponent<Item>().DestroyItem();

            Time.timeScale = 1;

        }
        else if(player.objectName == "Pot")
        {
            if (SceneManager.GetActiveScene().name != "Time1500")
            {
                if (GameObject.Find("Pots").transform.position != new Vector3(17f, 11f, 18f))
                {
                    GameObject.Find("Pots").transform.position = new Vector3(17f, 11f, 18f);
                }
                else if (GameObject.Find("Pots").transform.position == new Vector3(17f, 11f, 18f))
                {
                    GameObject.Find("Pots").transform.position = new Vector3(18.42f, 11f, 40.15f);
                }
            }
           
            Time.timeScale = 1;
        }
        else if(player.objectName=="Bucket")
        {
            Item Bucket = GameObject.Find("Bucket").GetComponent<Item>();
            inventory.items.Add(Bucket);
            inventory.SetSlot();
            Bucket.GetComponent<Item>().DestroyItem();

            Time.timeScale = 1;
        }
    }
    public void No_Button()
    {
        Time.timeScale = 1;
        InteractionImage.SetActive(false);

        YesorNo.SetActive(false);
    }

  
  
}
