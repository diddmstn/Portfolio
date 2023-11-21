using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;

    public float jumpForce;
    public float WalkForce;
    public float maxWalkSpeed;

   

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }
    void Move()
    {

        //jump(SpaceBar)
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //Movement
        int key = 0;

        if (Input.GetKey(KeyCode.D))
        {
            key = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            key = -1;
        }

        float speedx = 0.0f;
        speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * this.WalkForce * key);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }


        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("coin");

            UI_Manager.TotalCoin += 100;
            GameObject.Find("GameManager").GetComponent<AdventureUI_Manager>().GetCoin();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "finish")
        {
            GameObject.Find("GameManager").GetComponent<AdventureUI_Manager>().Finish();
        }
    }
   
    

}
