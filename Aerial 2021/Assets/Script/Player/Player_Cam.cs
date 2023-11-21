using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player_Cam : MonoBehaviour
{
   
    private CinemachineVirtualCamera vcam;
    Transform Transform_Player;

    private void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        //Player = GameObject.Find("Player").transform;
        //vcam.Follow = Player;
       
    }

    private void Update()
    {
        if(vcam.Follow==null&&Player.PlayerActive==true && GameObject.Find("Player")==true)
        {
            Transform_Player = GameObject.Find("Player").transform;
            vcam.Follow = Transform_Player;
        }
      
    }


}
