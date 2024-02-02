using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    RaycastHit2D rayHit;
    Rigidbody2D rb2D;
    GameObject player;
    public float Speed = 5f;
    float y;
    Vector2 direction;
    Vector2 PlayerPosition;
    Vector2 bomb;
    bool flip=false;
    bool aaa;
    bool bbb;//코루틴 한번만 들어가기
    bool isIDEL;//코루틴 한번만 들어가기
    Animator ani;

    GameObject movingPlatform;
    bool inPlatform;


    // Start is called before the first frame update
    void Start()
    {
        y = this.transform.position.y;
        direction = Vector2.right;
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        ani = gameObject.transform.GetChild(2).GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        ani.SetBool("isIDEL", isIDEL);

        if (Vector2.Distance(new Vector2(this.transform.position.x,0), new Vector2(player.transform.position.x, 0)) >= 4f)
        {
            isIDEL = false;

            if (player.transform.position.x > this.transform.position.x)
            {
                rb2D.velocity = new Vector2(direction.x * Speed, rb2D.velocity.y);

                // rb2D.velocity = direction * Speed;
                this.transform.localScale = new Vector3(-1, 1, 1);//좌우반전

            }
            else
            {
                rb2D.velocity = new Vector2(-direction.x * Speed, rb2D.velocity.y);
                this.transform.localScale = new Vector3(1, 1, 1);//좌우반전
            }
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            isIDEL = true;
            //idle
        }

    }
    //void Move()
    //{
    //    rb2D.velocity = direction * Speed;

    //    if ( rayHit.collider != null)
    //    {

    //        if (rayHit.collider.CompareTag("Player"))
    //        {
    //            if( aaa == true)
    //            {
    //                Speed = 0;
    //                if (bbb == false)
    //                {
    //                    bbb = true;
    //                    StartCoroutine(Attack());
    //                }
    //            }

               
    //        }
    //        else if (rayHit.collider != this.gameObject)
    //        {
    //            if (rayHit.distance <= 0.3f)
    //            {
    //                flip = !flip;

    //                switch (flip)
    //                {
    //                    case true:
    //                        direction = Vector2.left;
    //                        this.transform.localScale = new Vector3(1, 1, 1);//좌우반전
    //                        break;
    //                    case false:
    //                        direction = Vector2.right;
    //                        this.transform.localScale = new Vector3(-1, 1, 1);//좌우반전
    //                        break;
    //                }
    //            }
    //        }

    //    }
    //}

    //IEnumerator Attack()
    //{
    //    yield return new WaitForSeconds(3.0f);
    //    Debug.Log("공격중");



    //}
    //void AttackEnd()
    //{
    //    Debug.Log("공격끝");

    //    bbb = false;
    //    Speed = 5f;
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Player"))
    //    {
    //        aaa = true;
    //    }
       
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Bullet") && bbb == true)
        {
            Invoke("AttackEnd", 3);

        }
        if (collision.gameObject.name == "MovingPlatform")
        {
            inPlatform = true;
            movingPlatform = collision.gameObject;
            transform.SetParent(movingPlatform.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aaa = false;
        }
        if (collision.gameObject.name == "MovingPlatform")
        {
            transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
            inPlatform = false;
        }
    }
}
