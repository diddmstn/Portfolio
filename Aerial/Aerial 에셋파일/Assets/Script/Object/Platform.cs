using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool playerCheck;
    PlatformEffector2D platformObject;
    // Start is called before the first frame update
    void Start()
    {
        playerCheck = false;
        platformObject = GetComponent<PlatformEffector2D>();
    }
    void Update()//한칸씩 내려가는거 생각
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)&&playerCheck)
        {
            platformObject.rotationalOffset = 180f;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            platformObject.rotationalOffset = 0f;
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerCheck =true ;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCheck = false;
        }
           
    }
}
