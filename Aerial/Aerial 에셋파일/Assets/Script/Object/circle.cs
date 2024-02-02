using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle: MonoBehaviour
{
    //public Transform player;//Life
    public bool Active=false;
    GameObject player;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    //private void Update()
    //{
    //    if (Active == true)//따라가기
    //    {
    //        this.transform.position = Vector2.MoveTowards(this.transform.localPosition, player.transform.localPosition, Speed*Time.deltaTime);
           
    //    }
          
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(audioSource.isPlaying!=true)
            {
                audioSource.Play();
            }
            player = collision.gameObject;
            if (Active == false)
            {
                Active = true;
                Player.circle++;
                Destroy(this.gameObject,1f);
            }
        }
       
    }

}
