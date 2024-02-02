using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float FlySpeed = 3.0f;
    static public float rotationSpeed = 360.0f;


    CharacterController characterController;
    Animator animator;
    SceneManger scene;
    Obj_Interaction obj_interaction;

    public  string objectName;

    RaycastHit rayhit;

    

    private static Player instance;
   
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

        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        scene = GameObject.Find("GameManager").GetComponent<SceneManger>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Raycast();
    }

    void Move()
    {

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //ī�޶� ���� ������ ������ �ϱ�
        direction = Camera.main.transform.TransformDirection(direction);

        //ȸ��
        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);
        }
        //���� ����
        if (Input.GetKey(KeyCode.Space))
        {
            characterController.Move(Vector3.up * FlySpeed * Time.deltaTime);
        }

        //�����̴� �ڵ�
        characterController.Move(direction * moveSpeed * Time.deltaTime);

        //���ƴٴҶ� �ִϸ��̼�
        animator.SetFloat("Speed", characterController.velocity.magnitude);

    }

    void Raycast()
    {
        obj_interaction = GameObject.Find("GameManager").GetComponent<Obj_Interaction>();
        obj_interaction.E.SetActive(false);
        Debug.DrawRay(transform.position, transform.forward, Color.blue);
        if (Physics.Raycast(transform.position, transform.forward, out rayhit, 3))
        {
            if (rayhit.transform.tag == "Item")
            {
                obj_interaction.E.SetActive(true);
              
                if (Input.GetKeyUp(KeyCode.E))
                {
                    objectName = rayhit.transform.name;
                    GameObject.Find("GameManager").GetComponent<Obj_Interaction>().Interaction();
                   
                }
            }
         
        }
     }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Ending")
        {
            scene.Ending();
        }
    }
}
