using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsAnimation : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    public Type type;
    public enum Type
    {
        Right,
        Left
    }
 
    // Update is called once per frame
    void Update()
    {
        if(this.type==Type.Right)
        {
            if(this.transform.localPosition.x>=11)
            {
                this.transform.localPosition = new Vector2(-14,this.transform.localPosition.y);
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
        else if(this.type == Type.Left)
        {
            if (this.transform.localPosition.x <= -14)
            {
                this.transform.localPosition = new Vector2(11, this.transform.localPosition.y);
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
    }
}
