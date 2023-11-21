using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField]
    GameObject Player; // �÷��̾� ���󰡱�
    [SerializeField]
    Camera mainCamera; // �÷��̾� ���󰡱�

    float xmove = 0;  // X�� ���� �̵���
    float ymove = 0;  // Y�� ���� �̵���

    [SerializeField]
     float distance = 6f;

    RaycastHit rayhit;


    static public PlayerCam instance;
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject); // ���� ������Ʈ �ı�����
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
            xmove += Input.GetAxis("Mouse X"); // ���콺�� �¿� �̵����� xmove �� ����
            ymove -= Input.GetAxis("Mouse Y"); // ���콺�� ���� �̵����� ymove �� ����
        }
      
        transform.rotation = Quaternion.Euler(Mathf.Clamp(ymove, -90, 110),xmove, 0);// �̵����� ���� ī�޶��� �ٶ󺸴� ������ ����, ������ ���콺 ȸ�� �ȸ���

        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance); // ī�޶� �ٶ󺸴� �չ����� Z ��

        transform.position = Player.transform.position - transform.rotation * reverseDistance; // �÷��̾��� ��ġ���� ī�޶� �ٶ󺸴� ���⿡ ���Ͱ��� ������ ��� ��ǥ�� ����,������ �÷��̾� �ȵ���

        //����ĳ��Ʈ ���� �浹�ϸ� ī�޶� �̵� ,ī�޶� �����մ°��� ����
        Debug.DrawRay(Player.transform.position, transform.position - Player.transform.position, Color.red,2f);
       
        if (Physics.Raycast(Player.transform.position, transform.position -Player.transform.position, out rayhit,6f))
        {
            if (rayhit.transform.gameObject.tag != "Player"&& rayhit.transform.gameObject.tag != "Furniture")//�����ɽ�Ʈ ������
            {
                transform.position = rayhit.point;
             
                transform.Translate(0f, 0.3f, 0f);
              
            }
        }

    }



}
 
       