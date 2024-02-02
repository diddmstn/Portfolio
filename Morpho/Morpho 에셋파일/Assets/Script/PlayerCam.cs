using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField]
    GameObject Player; // 플레이어 따라가기
    [SerializeField]
    Camera mainCamera; // 플레이어 따라가기

    float xmove = 0;  // X축 누적 이동량
    float ymove = 0;  // Y축 누적 이동량

    [SerializeField]
     float distance = 6f;

    RaycastHit rayhit;


    static public PlayerCam instance;
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject); // 게임 오브젝트 파괴금지
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void LateUpdate()
    {   
        Cam();
    }

    void Cam()
    {
       
        if (Input.GetMouseButton(1))
        {
            xmove += Input.GetAxis("Mouse X"); // 마우스의 좌우 이동량을 xmove 에 누적
            ymove -= Input.GetAxis("Mouse Y"); // 마우스의 상하 이동량을 ymove 에 누적
        }
      
        transform.rotation = Quaternion.Euler(Mathf.Clamp(ymove, -90, 110),xmove, 0);// 이동량에 따라 카메라의 바라보는 방향을 조정, 없으면 마우스 회전 안먹힘

        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance); // 카메라가 바라보는 앞방향은 Z 축

        transform.position = Player.transform.position - transform.rotation * reverseDistance; // 플레이어의 위치에서 카메라가 바라보는 방향에 벡터값을 적용한 상대 좌표를 차감,없으면 플레이어 안따라감

        //레이캐스트 벽에 충돌하면 카메라 이동 ,카메라가 벽을뚫는것을 방지
        Debug.DrawRay(Player.transform.position, transform.position - Player.transform.position, Color.red,2f);
       
        if (Physics.Raycast(Player.transform.position, transform.position -Player.transform.position, out rayhit,6f))
        {
            if (rayhit.transform.gameObject.tag != "Player"&& rayhit.transform.gameObject.tag != "Furniture")//레이케스트 성공시
            {
                transform.position = rayhit.point;
             
                transform.Translate(0f, 0.3f, 0f);
              
            }
        }

    }



}
 
       