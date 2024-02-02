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
            DontDestroyOnLoad(this.gameObject); // 게임 오브젝트 파괴금지
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

        //카메라 보는 방향을 앞으로 하기
        direction = Camera.main.transform.TransformDirection(direction);

        //회전
        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);
        }
        //위로 날기
        if (Input.GetKey(KeyCode.Space))
        {
            characterController.Move(Vector3.up * FlySpeed * Time.deltaTime);
        }

        //움직이는 코드
        characterController.Move(direction * moveSpeed * Time.deltaTime);

        //날아다닐때 애니메이션
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
