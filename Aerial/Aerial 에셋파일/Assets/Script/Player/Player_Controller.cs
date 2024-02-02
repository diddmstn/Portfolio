using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]
     public BuoyancyEffector2D buoyancy;
    static public PolygonCollider2D Water;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Oil"))
        {
            Water = collision.GetComponent<PolygonCollider2D>();
            buoyancy = collision.GetComponent<BuoyancyEffector2D>();
            Player.inWater = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Oil"))
        {
            Player.inWater = false;
            buoyancy.surfaceLevel = 2.5f;


        }
    }


}
