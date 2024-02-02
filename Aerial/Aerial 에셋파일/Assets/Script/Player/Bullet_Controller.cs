using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    Rigidbody2D bulletRigidbody;
    public float speed;
    ParticleSystem particle;
    bool hit=false;

    private void Update()
    {
        if (!particle.IsAlive()&&hit==true)
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        particle = transform.GetChild(1).GetComponent<ParticleSystem>();

        particle.Stop();

        if(Player.x_flip==false)
        {
            bulletRigidbody.velocity = transform.right * speed;

        }
        else
        {
            bulletRigidbody.velocity = -transform.right * speed;

        }
        Invoke("BulletDestroy",3f);
    }
    private void BulletDestroy()
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bulletRigidbody.velocity = new Vector2(0, 0);
        //Debug.Log(collision.gameObject.name);
        hit = true;
        particle.Play();
        Invoke("BulletDestroy", 0.1f);
    }
}
