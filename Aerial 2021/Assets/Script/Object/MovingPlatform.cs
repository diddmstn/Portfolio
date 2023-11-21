using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Type type;

    public List<Transform> Point = new List<Transform>();
    int PointCount=0;
    
    public float moveSpeed;
    public bool AbilityMove;
    float Moving;

    bool Check = false;
    public enum Type
    {
        Normal,
        Ability
       
    }
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        Move();
       //Debug.Log(PointCount);

    }
    private void Start()
    {
        Moving = moveSpeed * Time.deltaTime;
    }

    public void Move()
    {
        if(this.type== Type.Normal)
        {
           // transform.Translate(new Vector2(0, Moving));
            transform.localPosition = Vector2.MoveTowards(transform.localPosition,Point[PointCount].transform.localPosition, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.localPosition, Point[PointCount].transform.localPosition) <= 0f)//À§
            {
                PointCount++;
            }
            if(PointCount>=Point.Count)
            {
                PointCount = 0;
            }
           
        }
        else if(this.type == Type.Ability)
        {
            switch(Player.AbilityActive)
            {
                case true:
                 
                    if(AbilityMove==true)
                    {
                        if (Check == false)
                        {
                            PointCount--;
                            if (PointCount == -1)//0 4
                            {
                                PointCount = Point.Count - 1;
                            }

                            Check = true;
                        }
                    }
                    transform.localPosition = Vector2.MoveTowards(transform.localPosition, Point[PointCount].transform.localPosition, moveSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.localPosition, Point[PointCount].transform.localPosition) <= 0f)//À§
                    {
                        PointCount--;// -1
                        if( PointCount==-1)
                        {
                            PointCount = Point.Count-1;
                        }
                    }

                    break;

                case false:
                   
                    if (AbilityMove==true)
                    {
                        if (Check == true)//3
                        {
                            PointCount++;
                            if (PointCount == Point.Count)
                            {
                                PointCount = 0;
                            }

                            Check = false;
                        }

                        transform.localPosition = Vector2.MoveTowards(transform.localPosition, Point[PointCount].transform.localPosition, moveSpeed * Time.deltaTime);

                        if (Vector2.Distance(transform.localPosition, Point[PointCount].transform.localPosition) <= 0f)//À§
                        {
                            PointCount++;
                        }
                        if (PointCount >= Point.Count) 
                        {
                            PointCount = 0;
                        }
                        //if (PointCount <0)
                        //{
                        //    PointCount = Point.Count;
                        //}
                    }
                        break;

            }
        }
         
    }
}
