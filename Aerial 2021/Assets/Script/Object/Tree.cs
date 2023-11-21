using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    Rigidbody2D rig2D;
    Animator ani;
    public GameObject BeforeTree;
    float Speed = 0f;

   // AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        rig2D = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
            ani.SetFloat("Speed", Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {

            BeforeTree.SetActive(false);
            Speed = 0.8f;
            rig2D.constraints = ~RigidbodyConstraints2D.FreezePositionY;


            Destroy(this.gameObject, 1f);
        }
    }
}
