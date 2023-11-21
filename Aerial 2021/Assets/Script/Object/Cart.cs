using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{

    public GameObject E;
    bool touchCart;
    bool inCart;
    bool Operate;

    GameObject player;
    public BoxCollider2D boxColl;
    public  GameObject CartEvent;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyUp(KeyCode.E)&& touchCart == true)
        {
            if (inCart==false && Operate == false)
            {
                Operate = true;
                inCart = true;
                player.transform.SetParent(this.transform);
                boxColl.isTrigger = true;
                player.transform.localPosition = new Vector2(0.22f, -1.48f);
                Player.PlayerActive = false;
                CartEvent.SetActive(true);

            }
            else if(inCart==true&&CartEvent.activeSelf==false)
            {
                inCart = false;
                boxColl.isTrigger = false;
               Player.PlayerActive = true;
                player.transform.SetParent(null);

            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")&&Operate==false)
        {
            player = collision.gameObject;
            E.SetActive(true);
            touchCart = true;
        }
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            E.SetActive(false);
            touchCart = false;

        }
    }
}
