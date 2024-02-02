using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CraneMachine : MonoBehaviour
{
    public GameObject Crane;
    public GameObject CraneCamera;
    public GameObject Guide_UI;

    CinemachineVirtualCamera vcam;
    CinemachineBrain brain;

    Rigidbody2D rb2D;

    public float moveSpeed;
   
    bool CraneActive;
    bool InputActive;


    
    public GameObject E_Text;
    void Start()
    {
        rb2D = Crane.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InputActive == true)
        {
            CraneMachineActive();
        }
        if(CraneActive == false)
        {
            rb2D.velocity = new Vector2(0, 0);

        }
    }
    private void FixedUpdate()
    {
        if (CraneActive == true && Player.PlayerActive == false)
        {
            Move();
        }

    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            E_Text.SetActive(true);

            brain = CinemachineCore.Instance.GetActiveBrain(0);
            vcam = brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
            InputActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            E_Text.SetActive(false);

            InputActive = false;
           
        }
    }

    
    void CraneMachineActive()
    {
        if (CraneActive == true)
        {
            Guide_UI.SetActive(false);
            Player.PlayerActive = true;
            CraneActive = false;
            vcam.Follow = GameObject.Find("Player").transform;
        }
        else
        {
            Guide_UI.SetActive(true);
            Player.PlayerActive = false;
            CraneActive = true;
            vcam.Follow = CraneCamera.transform;
        }
      
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float y = Input.GetAxis("Vertical") * moveSpeed;


        if (Time.timeScale == 1 && Player.PlayerActive == false)
        {
            if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                  rb2D.velocity = new Vector2(x,0);
            }
            else if (!Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) )
            {
                    rb2D.velocity = new Vector2(x, 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow)&&Crane.transform.localPosition.y<=0f)
            {
                  rb2D.velocity = new Vector2(0,y);
            }
            else if (Input.GetKey(KeyCode.DownArrow) && Crane.transform.localPosition.y >= -5f)
            {
                  rb2D.velocity = new Vector2(0,y);
            }
            else
            {
                rb2D.velocity = new Vector2(0, 0);

            }



        }


    }
}
