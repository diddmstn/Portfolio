using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public  GameObject player;
   
    void Update()
    {
        Vector3 playPos;
        playPos = this.player.transform.position;
        transform.position = new Vector3(transform.position.x, playPos.y+3, transform.position.z);
    }
}
