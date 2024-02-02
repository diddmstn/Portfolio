using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public int a, b, c, d = 0;

    public Text a_text;
    public Text b_text;
    public Text c_text;
    public Text d_text;

    Obj_Interaction obj;

    void Start()
    {
        obj = GameObject.Find("GameManager").GetComponent<Obj_Interaction>();

        
    }
    void Update()
    {
        a_text.text = a.ToString();
        b_text.text = b.ToString();
        c_text.text = c.ToString();
        d_text.text = d.ToString();

    }

    public void a_Button()
    {
        a++;
        if (a > 2)
        {
            a = 0;
        }

    }
    public void b_Button()
    {
        b++;
        if (b > 9)
        {
            b = 0;
        }

    }
    public void c_Button()
    {
        c++;
        if (c > 6)
        {
            c = 0;
        }

    }
    public void d_Button()
    {
        d++;
        if (d > 9)
        {
            d = 0;
        }

    }
    public void Enter_Button()
    {
        
        if (a == 0 && b == 7 && c == 0 && d == 0)
        {
            GameObject.Find("GameManager").GetComponent<SceneManger>().TimeScene();
            obj.ClockUI.SetActive(false);
        }
        else if (a == 1 && b == 1 && c == 2 && d == 4)
        {
            GameObject.Find("GameManager").GetComponent<SceneManger>().TimeScene();
            obj.ClockUI.SetActive(false);
        }
        else if (a == 1 && b == 5 && c == 0 && d == 0)
        {
            GameObject.Find("GameManager").GetComponent<SceneManger>().TimeScene();
            obj.ClockUI.SetActive(false);
        }
        else if (a == 1 && b == 9 && c == 3 && d == 1)
        {
            GameObject.Find("GameManager").GetComponent<SceneManger>().TimeScene();
           obj.ClockUI.SetActive(false);
        }
        else if (a == 2 && b == 0 && c == 5 && d == 2)
        {
            GameObject.Find("GameManager").GetComponent<SceneManger>().TimeScene();
            obj.ClockUI.SetActive(false);
        } 
        else
        {
           // StartCoroutine("WaitForIt");
            obj.ClockUI.SetActive(false);
            obj.InteractionImage.SetActive(true);
            obj.InteractionMessage.text = "아무일도 일어나지 않았다.";
         
        }
       
    }
    //IEnumerator WaitForIt()
    //{
    //    yield return new WaitForSeconds(1f);
       
    //}
}
