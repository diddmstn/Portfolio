using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Mechanism mechanism;
    public PushButton Button=null;
    Rigidbody2D rig2D;

    [HideInInspector]public bool Active=false;

    AudioSource audioSource;

    public List<Animator> ActiveAnimator = new List<Animator>();

    public enum Mechanism
    {
        Drop,
        Rotation
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rig2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (this.mechanism==Mechanism.Drop)
        {
            if (Button.Active == true)
            {
                DropPipe();
            }
        }
        
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.mechanism == Mechanism.Rotation)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                RotationPipe();
                if (ActiveAnimator != null)
                {
                    for (int i = 0; i < ActiveAnimator.Count; i++)
                    {
                        if (ActiveAnimator[i].enabled == true)
                        {
                            ActiveAnimator[i].enabled = false;

                        }
                        else
                        {
                            ActiveAnimator[i].enabled = true;

                        }
                    }
                }
            }
        }
    }

   
    void DropPipe()
    {
        rig2D.gravityScale = 10;
        rig2D.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        Destroy(this.gameObject, 3);
    }

    void RotationPipe()
    {
        audioSource.Play();
        this.transform.rotation = Quaternion.Euler(0,0, 0);
        Active = true;
    }

    


}
