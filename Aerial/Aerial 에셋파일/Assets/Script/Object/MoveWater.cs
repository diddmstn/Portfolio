using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWater : MonoBehaviour
{
    public Type type;


    public PushButton pushButton;
    public float moveSpeed;
    [SerializeField]
    public GameObject EndPosition;
    bool end;

    public enum Type
    {
        Up,
        Down

    }
    // Update is called once per frame
    void Update()
    {
        if(pushButton.Active==true&&end==false)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, EndPosition.transform.localPosition, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.localPosition, EndPosition.transform.localPosition) <=1f)
            {
                end = true;
                if(this.type==Type.Down)
                {
                    Destroy(this.gameObject,2f);
                }
            }
        }
    }
}
