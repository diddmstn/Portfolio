using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    public GameObject ExitPotal;
     BGM bgm;
    static public string StageName="Stage1";

    private void Awake()
    {
        StageName = "Stage1";
    }
    private void Start()
    {
        bgm = GameObject.Find("BGM").GetComponent<BGM>();
    }
    private void OnTriggerEnter2D(Collider2D collision)//나중에 fade 추가
    {
        if (collision.CompareTag("Box"))
        {
            Destroy(collision.gameObject,1.5f);
        }
        else if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.position = ExitPotal.transform.position;
            Potal.StageName = this.gameObject.name;
            bgm.ChangeBGM();
        }
    }
   
   

}
