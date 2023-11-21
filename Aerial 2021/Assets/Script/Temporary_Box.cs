using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary_Box : MonoBehaviour
{
    Rigidbody2D rb2D;
   
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Box"))
        {
            rb2D = collision.GetComponent<Rigidbody2D>();
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;

        }


    }
}
