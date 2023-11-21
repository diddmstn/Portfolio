using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationActive : MonoBehaviour
{
    Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
        ani.keepAnimatorControllerStateOnDisable = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ani.enabled = true;
        }
    }
}
