using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFloating : MonoBehaviour
{
    Animator ani;

    bool Trigger;
    // Start is called before the first frame update
    void Awake()
    {
        ani = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        ani.SetBool("TriggerEnter", Trigger);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Trigger = true;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Trigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Trigger = false;
        }
    }


}
