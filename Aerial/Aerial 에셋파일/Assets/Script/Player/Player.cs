using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 500f;

    [HideInInspector]
    public bool isAttack = false;
    bool isJumping=false;
    bool isWalk=false;
    bool isLanding=false;
    bool isPush=false;
    bool isPull = false;
   
    bool jumpAction;
    Rigidbody2D rb2D;
    Animator ani;

    [HideInInspector] 
    public static Vector3 Respawn;

    public static int circle;
   // public static int GameTime;
    public static bool Die;

    BoxCollider2D Boxcol2D=null;

    AudioSource audioSorce;
    public PlayerSound playerSound;

    RaycastHit2D rayHit;
    public SpriteRenderer handMask;

    int count = 0;

    public static bool inWater;
    public static bool x_flip;
    public static bool PlayerActive=true;
    public static bool AbilityActive=false;
    public static bool isAbility =false;

    Player_Controller controller;
    public GameObject bulletPrefab;
    public GameObject bubblePrefab;
    bool bubblePlay;

    UnityEngine.Rendering.Universal.Light2D Ability_Light;
    bool inPlatform;
    bool inBox;
    bool movingBox;
    bool BoxRight;

    GameObject MoveObject=null;
    GameObject movingPlatform;
    bool CanMove =false;
     UI_Manager ui;

    public static int PlayerFuntion = 2;

    [System.Serializable]
    public class PlayerEffect
    {
        public GameObject Jump;
        public ParticleSystem Muzzles;
        //public GameObject Bubble;
    }
    public PlayerEffect playerEffect;

    [System.Serializable]
    public class PlayerSound
    {
       // public AudioClip GroundWalk;
        public AudioClip DoubleJumpSE;
        public AudioClip AbilityOn;
        public AudioClip Shoot;
        public AudioClip Water;

    }
    #region Singleton
    public static Player instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

       
        ani = GetComponentInChildren<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        Boxcol2D = GetComponent<BoxCollider2D>();
        audioSorce = GetComponent<AudioSource>();
        controller = GetComponentInChildren<Player_Controller>();
        ui = GameObject.Find("UIManager").GetComponent<UI_Manager>();
        Ability_Light = GameObject.Find("Global Light 2D").GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        isJumping = false;
        PlayerActive = true;
        Time.timeScale = 1;

        if (NPC.FieldEvent == true||NPC.FieldEvent2==true)
        {
            if (SceneManager.GetActiveScene().name == "Town")
            {
                this.transform.position = new Vector2(170f, -1.6f);
            }
        }
      

    }
    #endregion


    // Start is called before the first frame update

    private void FixedUpdate()
    {
        rayHit = Physics2D.BoxCast(Boxcol2D.bounds.center, Boxcol2D.bounds.size, 0f, Vector2.down);
        BoxCast(Boxcol2D.bounds.center, Boxcol2D.bounds.size, 0f, Vector2.down, 0.1f, 0);

        if(jumpAction==true)
        {
            Jump();
        }

    }
    private void Update()
    {
        ani.SetBool("isJumping", isJumping);
        ani.SetBool("isWalk", isWalk);
        ani.SetBool("isAttack", isAttack);
        ani.SetBool("isLanding", isLanding);
        ani.SetBool("isPush", isPush);
        ani.SetBool("isPull", isPull);
        //   Debug.Log(rayHit.collider.tag);
       /* 프레임때문에 fixedupdate를 사용해야하지만 입력이 씹히기 때문에 이런식으로 입력만 update에 넣음 
        */


      // && transform.localScale.x == 1
        if (rayHit.collider.CompareTag("Floor") || rayHit.collider.CompareTag("Box") || rayHit.collider.CompareTag("Pipe"))
        {

            /*BoxCast를 이용한 바닥 감지
           * Collider를 사용해 바닥을 감지할경우 플레이어의 머리만 닿아도 연속 점프되는 오류
           * 따라서 플레이어 발 아래에 BoxCast를 사용하여 바닥에 닿을때만 점프가 가능하도록 설정
           * !!주의사항!! 플레이어가 지나가는 곳 아래에는 안보일지라도 아래에 콜라이더가 있어야 함(없을시 NullReference와 점프 이동중 낙하하는 현상)
           * 아마 최대거리를 넘어버려 감지가 안되서 생기는 현상같다. (아마 trigger 없어야)
           */
            if (rayHit.distance <= 3f)
            {
                if (isJumping == true&&isLanding==false)
                {
                    isLanding = true;
                }
                //Debug.Log(rayHit.distance);

                if (rayHit.distance <= 1f && rb2D.velocity.y <= 1f)
                {
                    if (isJumping == true)
                    {
                        playerEffect.Jump.SetActive(false);
                        isJumping = false;
                        jumpAction = false;
                        isLanding = false;

                        count = 0;
                    }
                }
            }
               
           
        }

        if (inWater == true && bubblePlay == false)
        {
           
                bubblePlay = true;

            StartCoroutine(Bubble());
        }
       
      
        if(Input.GetKeyUp(KeyCode.E)&& CanMove==true&& jumpAction==false)
        {
            if (inBox == true)
                movingBox = !movingBox;//true
            if (movingBox == true && MoveObject != null)
            {
                if(BoxRight==true)
                {
                    this.transform.position = new Vector2(MoveObject.transform.position.x- 1.7f, MoveObject.transform.position.y - 2.3f);
                    this.transform.localScale = new Vector3(1, 1, 1);//좌우반전
                }
                else
                {
                    this.transform.position = new Vector2(MoveObject.transform.position.x +1.7f, MoveObject.transform.position.y - 2.3f);

                    this.transform.localScale = new Vector3(-1, 1, 1);//좌우반전

                }
                MoveObject.transform.SetParent(this.transform);
           
            }
            else if(movingBox== false && MoveObject != null)
            {
                MoveObject.transform.SetParent(null);
             
                isPush = false;
                isPull = false;

            }

        }
       
        if (movingBox==true)
        {
            BoxMove();
        }
        else if(movingBox == false)
        {
            Move();
            if (Input.GetKeyDown(KeyCode.Space) && inWater == false && PlayerActive == true)
            {
                jumpAction = true;
                count++;
            }
            if (Input.GetKeyDown(KeyCode.Q) && isAttack == false && PlayerActive == true && PlayerFuntion >= 1)
            {
                isAttack = true;
                handMask.maskInteraction = SpriteMaskInteraction.None;
                ani.Play("attack");
            }
            if (Input.GetKeyUp(KeyCode.R) && PlayerActive == true && Time.timeScale == 1 && PlayerFuntion >= 2)//
            {
                Ability();
            }
        }

    }
   
    IEnumerator Bubble()
    {
        yield return new WaitForSeconds(1f);

        if (!audioSorce.isPlaying)
        {
            audioSorce.PlayOneShot(playerSound.Water);
        }
        for (int i=0; i<6; i++)
        {
            yield return new WaitForSeconds(0.2f);
            if(x_flip == false)
            {
                Instantiate(bubblePrefab, transform.position + new Vector3(0.4f, 2.9f, 0), Quaternion.Euler(-90f, 0, 0));
            }
            else
            {
                Instantiate(bubblePrefab, transform.position + new Vector3(-0.4f, 2.9f, 0), Quaternion.Euler(-90f, 0, 0));
            }

        }
        // yield return new WaitForSeconds(1f);
        yield return null;
        bubblePlay = false;

    }
    public void ShootStart()
    {
        playerEffect.Muzzles.Play();
        audioSorce.Stop();
        audioSorce.PlayOneShot(playerSound.Shoot);
        if (x_flip == false)//생성위치 나중에 변경
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(1f, 2.5f, 0), transform.rotation);
        }
        else
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(-1f, 2.5f, 0), transform.rotation);
        }
    }
    public void ShootEnd()
    {
        if (x_flip == true)
        {
            handMask.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }

    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float y = Input.GetAxis("Vertical") * moveSpeed;


        if (Time.timeScale== 1)
        {
            if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && PlayerActive == true)
            {
                x_flip = false;
                rb2D.velocity = new Vector2(x, rb2D.velocity.y);

                if (!Input.GetKey(KeyCode.LeftArrow))
                {
                    this.transform.localScale = new Vector3(1, 1, 1);//좌우반전
                    handMask.maskInteraction = SpriteMaskInteraction.None;
                }
                 isWalk = true;
            }
            else if (!Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) && PlayerActive == true)
            {
                x_flip = true;
                rb2D.velocity = new Vector2(x, rb2D.velocity.y);

                if (!Input.GetKey(KeyCode.RightArrow))
                {
                    this.transform.localScale = new Vector3(-1, 1, 1);//좌우반전
                    if (!ani.GetCurrentAnimatorStateInfo(0).IsName("attack"))
                    {
                        handMask.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                    }

                }
                isWalk = true;
            }
            else
            {
                if(isJumping==true)
                {
                    rb2D.velocity = new Vector2(0, rb2D.velocity.y);
                }
                else
                {
                   //if(inPlatform==true)
                   // {
                   //     transform.position = movingPlatform.transform.position - PlatformDistance;
                   // }
                    rb2D.velocity = new Vector2(0, rb2D.velocity.y);

                }
               
                isWalk = false;
            }
            if (Input.GetKey(KeyCode.UpArrow) && PlayerActive == true && isJumping == false)
            {
                if (inWater == true)
                {
                    rb2D.velocity = new Vector2(rb2D.velocity.x, y);
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow) && PlayerActive == true)
            {
                if (inWater == true)
                {

                    rb2D.velocity = new Vector2(rb2D.velocity.x, y);
                }
                if (controller.buoyancy != null)
                {
                    controller.buoyancy.surfaceLevel = -10f;

                }

            }
          
        }
      

     }
    void BoxMove()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float y = Input.GetAxis("Vertical") * moveSpeed;

        handMask.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

        if (Time.timeScale == 1)
        {
            if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && PlayerActive == true)
            {
                x_flip = false;
                rb2D.velocity = new Vector2(x, rb2D.velocity.y);

              
                if (BoxRight == true)
                {

                    isPush = true;
                    isPull = false;

                }
                else if (BoxRight == false)
                {
                    isPush = false;
                    isPull = true;
                }
            }
            else if (!Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) && PlayerActive == true)
            {
                x_flip = true;
                rb2D.velocity = new Vector2(x, rb2D.velocity.y);

              
                if (BoxRight == false)
                {
                    isPush = true;
                    isPull = false;

                }
                else if (BoxRight == true)
                {
                    isPush = false;
                    isPull = true;
                }
               
            }
            else
            {
                rb2D.velocity = new Vector2(0, rb2D.velocity.y);
                isPush = false;
                isPull = false;
                isWalk = false;
            }
         

        }
    }
    void Jump()
    {
        if(isJumping == false)
        {

            if (count==1)
            {
                if (controller.buoyancy!=null)
                controller.buoyancy.surfaceLevel = -10f;

                rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
                rb2D.AddForce(new Vector2(0, jumpForce));

            }

            isJumping = true;
        }
        else if(isJumping==true&&count==2)
        {
            audioSorce.Stop();
            audioSorce.PlayOneShot(playerSound.DoubleJumpSE);

            playerEffect.Jump.SetActive(true);
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(new Vector2(0, jumpForce));
            jumpAction = false;
        }
       

    }
   void Ability()
    {
        audioSorce.Stop();
        audioSorce.PlayOneShot(playerSound.AbilityOn);
        ui.StartCoroutine(ui.Fade_Out(ui.Fade_image, 0.01f));

        if (AbilityActive == false)
        {
            Ability_Light.intensity = 0.7f;
            AbilityActive = true;
            isAbility =true;
        }
        else
        {
            Ability_Light.intensity = 1f;
            AbilityActive = false;

        }


    }
   
    //boxcast 범위를 시각화
    static public RaycastHit2D BoxCast(Vector2 origen, Vector2 size, float angle, Vector2 direction, float distance, int mask)
    {
        RaycastHit2D hit = Physics2D.BoxCast(origen, size, angle, direction, distance, mask);

        //Setting up the points to draw the cast
        Vector2 p1, p2, p3, p4, p5, p6, p7, p8;
        float w = size.x * 0.5f;
        float h = size.y * 0.5f;
        p1 = new Vector2(-w, h);
        p2 = new Vector2(w, h);
        p3 = new Vector2(w, -h);
        p4 = new Vector2(-w, -h);

        Quaternion q = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
        p1 = q * p1;
        p2 = q * p2;
        p3 = q * p3;
        p4 = q * p4;

        p1 += origen;
        p2 += origen;
        p3 += origen;
        p4 += origen;

        Vector2 realDistance = direction.normalized * distance;
        p5 = p1 + realDistance;
        p6 = p2 + realDistance;
        p7 = p3 + realDistance;
        p8 = p4 + realDistance;


        //Drawing the cast
        Color castColor = hit ? Color.red : Color.green;
        Debug.DrawLine(p1, p2, castColor);
        Debug.DrawLine(p2, p3, castColor);
        Debug.DrawLine(p3, p4, castColor);
        Debug.DrawLine(p4, p1, castColor);

        Debug.DrawLine(p5, p6, castColor);
        Debug.DrawLine(p6, p7, castColor);
        Debug.DrawLine(p7, p8, castColor);
        Debug.DrawLine(p8, p5, castColor);

        Debug.DrawLine(p1, p5, Color.grey);
        Debug.DrawLine(p2, p6, Color.grey);
        Debug.DrawLine(p3, p7, Color.grey);
        Debug.DrawLine(p4, p8, Color.grey);
        if (hit)
        {
            Debug.DrawLine(hit.point, hit.point + hit.normal.normalized * 0.2f, Color.yellow);
        }

        return hit;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="MovingPlatform")
        {
            inPlatform = true;
            movingPlatform = collision.gameObject;
            transform.SetParent(movingPlatform.transform);
        }
        //else if(collision.gameObject.CompareTag("Box"))
        //{
        //   // MoveObject = collision.gameObject;
        //    //if(collision.gameObject.GetComponent<Box>()!=null)
        //    //CanMove = collision.gameObject.GetComponent<Box>().CanMove;
        //    //if (this.transform.position.x<collision.transform.position.x)
        //    //{
        //    //    BoxRight = true;
        //    //}
        //    //else
        //    //{
        //    //    BoxRight = false;
        //    //}
        //    //inBox = true;

        //}
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            MoveObject = collision.gameObject;
            if (collision.gameObject.GetComponent<Box>() != null)
                CanMove = collision.gameObject.GetComponent<Box>().CanMove;
            if (this.transform.position.x < collision.transform.position.x)
            {
                BoxRight = true;
            }
            else
            {
                BoxRight = false;
            }
            inBox = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name=="MovingPlatform")
        {
            transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
            inPlatform = false;
        }
        else if (collision.gameObject.CompareTag("Box"))
        {
          if(movingBox==false)
            {
                MoveObject = null;
                inBox = false;
               // boxRb2D.bodyType = RigidbodyType2D.Dynamic;


            }

        }


    }

    public void Cart()
    {
        PlayerFuntion = 0;
    }
    public void OutCart()
    {

        PlayerFuntion = 3;
    }
   

}
