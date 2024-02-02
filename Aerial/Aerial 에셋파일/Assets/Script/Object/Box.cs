using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[3];
    SpriteRenderer spriteRenderer;
   // Rigidbody2D rb2D;

    AudioSource audioSrc;

    public BoxSE boxSE;
    public GameObject E=null;

    bool InWater;
    public bool CanMove;
    public bool affectedAbility;
    public bool DontDestroy;
    [System.Serializable]
    public class BoxSE
    {
        public AudioClip MovingBox;
        
    }
    private void Start()
    {
       // rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSrc = GetComponent<AudioSource>();

    }
    private void Update()
    {
        if(affectedAbility==true)
        {
            switch (Player.AbilityActive)
            {
                case true:
                    spriteRenderer.sprite = sprites[1];
                    CanMove = true;
                    break;
                case false:
                    spriteRenderer.sprite = sprites[0];
                    CanMove = false;
                    break;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")&& DontDestroy!=true)
        {
            if(this.gameObject.name=="Tree")
            {
                Destroy(this.gameObject);
            }
            else
            {
                spriteRenderer.sprite = sprites[2];
            }
            Destroy(this.gameObject, 2f);
        }
       
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (E != null)
        {
            if (collision.gameObject.CompareTag("Player") && CanMove == true)
            {
                E.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (E != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (transform.parent != null && transform.parent.name == "Player")
                {
                    E.SetActive(true);
                }
                else
                {
                    E.SetActive(false);
                }

            }
        }
       
    }

}
