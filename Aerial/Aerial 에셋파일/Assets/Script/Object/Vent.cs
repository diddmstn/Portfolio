using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public GameObject bomb;
    public GameObject cart;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject==bomb)
        {
            Destroy(collision.gameObject);
        }
         if(collision.gameObject == cart)
        {
            Destroy(collision.gameObject);

        }


    }
   
}
