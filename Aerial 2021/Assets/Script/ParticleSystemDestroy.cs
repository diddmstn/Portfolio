using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemDestroy : MonoBehaviour
{
    ParticleSystem particle;
    PolygonCollider2D Water;
   
    // Start is called before the first frame update
    void Start()
    {
        Water = Player_Controller.Water;
        particle = GetComponent<ParticleSystem>();
        particle.trigger.SetCollider(0,Water.GetComponent<PolygonCollider2D>());

    }

    // Update is called once per frame
    void Update()
    {
        if (!particle.IsAlive())
        {
            Destroy(this.gameObject);
        }
       
    }
   

}