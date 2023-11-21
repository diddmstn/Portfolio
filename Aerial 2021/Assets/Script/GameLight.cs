using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLight : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D Olight;
    public float intensity;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Olight.intensity = intensity;
        }    
    }
}
