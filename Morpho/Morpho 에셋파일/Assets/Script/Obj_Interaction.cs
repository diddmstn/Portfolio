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

  
    void Awake()//start�� �ٲ��� ����
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

        //Ŭ�� �����̰� �������̸� e��ư Ŭ�����ϰ�
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
                InteractionMessage.text = "â������ �ذ� �ߴ� ���� ���δ�.";
            }
            else if (SceneManager.GetActiveScene().name == "Time1124")
            {
                InteractionMessage.text = "�ٶ��� �δ°� ��������.";
            }
            else if (SceneManager.GetActiveScene().name == "Time1500")
            {
                InteractionMessage.text = "�ۿ� �� �����°� ���δ�.";
            }
            else if (SceneManager.GetActiveScene().name == "Time1931")
            {
                InteractionMessage.text = "���� ���� ��ο����� �ִ�.";
            }
            else if (SceneManager.GetActiveScene().name == "Time2052")
            {
                InteractionMessage.text = "�ۿ� ���� �ߴ� ���� ���δ�.";
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
            InteractionMessage.text = "���� ���� �� ����Ѱ� ���� �⸧���̴�. ���� �⸧�� �����ִ�.";
            for (int i = 0; i < inventory.items.Count; i++)
            {
                if (inventory.items[i].itemName == "���� ��")
                {
                    inventory.items[i].itemName = "�⸧�� �� ���� ��";
                    inventory.SetSlot();
                    InteractionMessage.text = "���� ���� �� ����Ѱ� ���� �⸧���̴�. �������ִ� ���� ���� �⸧�� ��Ҵ�.";

                    //������ ��ƼŬ ���� 
                }
                else if (inventory.items[i].itemName == "�⸧�� �� ���� ��")
                {
                    InteractionMessage.text = "���� ���� �� ����Ѱ� ���� �⸧���̴�. ���� �⸧�� �̹� ���� ��Ҵ�.";

                }
                else if (inventory.items[i].itemName == "��� �� ��")
                {
                    InteractionMessage.text = "���� ���� �� ����Ѱ� ���� �⸧���̴�. ���� �⸧�� �̹� ���� ��Ҵ�.";

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
            InteractionMessage.text = "��������� ������ �콽� �� �� ����.";
            for (int i = 0; i < inventory.items.Count; i++)
            {
                if (inventory.items[i].itemName == "�⸧�� �� ���� ��")
                {
                    inventory.items[i].itemName = "��� �� ��";
                    inventory.SetSlot();
                    InteractionMessage.text = "�콼 ���ڸ� �������ִ� �⸧ ������ ���� 20:52�� �����ִ� ������ �����.";

                    //������ ��ƼŬ ���� 
                }
                else if (inventory.items[i].itemName == "��� �� ��")
                {
                    InteractionMessage.text = "�콼 ���ڸ� �������ִ� �⸧ ������ ���� 20:52�� �����ִ� ������ �����.";

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
            InteractionMessage.text = "å�� �׿��ִ�. ���� �߿��Ѱ� ���� �� ����.";
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
            InteractionMessage.text = "����Ҽ� ���� �� ���� ���� �絿�̴�. ��������?";

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
            InteractionMessage.text = "����ִ�.";
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
            InteractionMessage.text = "���� �ð��. �ð��� �ٲܱ�?";

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
            InteractionMessage.text = "��ٵ��� �޸�,����� ����,1931.";
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
            InteractionMessage.text = "����� �ð�����̴�.";
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
            InteractionMessage.text = "���� ���̴�. ��������?";

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
                    InteractionMessage.text = "�׾Ƹ��� �ű�� ����.";
                   
                }
                else if (GameObject.Find("Pots").transform.position == new Vector3(17f, 11f, 18f))
                {
                    InteractionImage.SetActive(true);
                    InteractionMessage.text = "������ �񰡻����� �Űܵ� �׾Ƹ��� ���� ���ִ�.";

                    for (int i = 0; i < inventory.items.Count; i++)
                    {
                        if (inventory.items[i].itemName == "���� �絿��")
                        {
                            InteractionMessage.text = "���� �絿�̷� ���� �ۼ� ���� �� �絿�̸� �����.";
                       
                            inventory.items[i].itemName = "���� �� �絿��";
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
                    InteractionMessage.text = "���� �׾Ƹ����� ���ֽ��ϴ�. �ű�ðڽ��ϱ�?";
                }
                if (GameObject.Find("Pots").transform.position == new Vector3(17f, 11f, 18f))
                {
                    Time.timeScale = 0;
                    InteractionImage.SetActive(true);
                    YesorNo.SetActive(true);
                    InteractionMessage.text = "�׾Ƹ����� �ٽ� ���ڸ��� �ű�ðڽ��ϱ�?";
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

                InteractionMessage.text = "���̻� �ٰ����� ���� �� ����. ���� ���� ���� ���� �� ����.";
                for (int i = 0; i < inventory.items.Count; i++)
                {
                    if (inventory.items[i].itemName == "���� �� �絿��")
                    {
                        inventory.items[i].itemName = "�� �絿��";
                        inventory.SetSlot();
                        InteractionMessage.text = "�������ִ� ���� �� �絿�̷� ���� ���� 11:24���̶� �����ִ� ������ �����.";
                        usewater = true;

                        //������ ��ƼŬ ���� 
                    }
                    else if(inventory.items[i].itemName == "�� �絿��")
                    {
                        InteractionMessage.text = "�������ִ� ���� �� �絿�̷� ���� ���� 11:24���̶� �����ִ� ������ �����.";
                       
                    }
                   
                }
               
            }
           else if(SceneManager.GetActiveScene().name != "Time1931")
            {
                Time.timeScale = 0;
                InteractionImage.SetActive(true);
                InteractionMessage.text = "�����δ�.";
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
            InteractionMessage.text = "15:00 ��� �����ִ�";
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
