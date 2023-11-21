using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class TilePuzzleManager : MonoBehaviour
{
    CinemachineVirtualCamera vcam;
    CinemachineBrain brain;

    Vector3 MousePosition;

    bool InputActive;
    bool TileActive;

    public GameObject Puzzle;
    public Camera cam;

    List<Transform> PuzzleTile = new List<Transform>();
    List<Puzzle_Tile> TileScript = new List<Puzzle_Tile>();
    List<bool> Check = new List<bool>();

    //puzzle의 자식인 answerTile의 자식 갯수를 저장 (gameobj)
    //자식의 스크립트인 Puzzle_Tile의 변수와 오브젝트의 회전값을 비교하고 똑같으면 true 반환(bool)
    //자식들이 모두 true면 해결 아니면 계속 계산
    // Start is called before the first frame update
    void Start()
    {
        brain = CinemachineCore.Instance.GetActiveBrain(0);
        vcam = brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();

       StartCoroutine(CheckAnswer());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InputActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InputActive = false;

        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InputActive == true)
        {
            TilePuzzleActive();
        }
        if( Input.GetMouseButtonUp(0)&& TileActive == true)
        {
            MousePosition = Input.mousePosition;
            MousePosition = cam.ScreenToWorldPoint(MousePosition);

            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, 15f);

            if (hit.collider != null&& hit.collider.CompareTag("Test"))
            {
                hit.collider.gameObject.GetComponent<Puzzle_Tile>().Rotation();
            }
        }
        
    }

    void TilePuzzleActive()
    {
        if (TileActive == true)
        {
            Player.PlayerActive = true;
            TileActive = false;
            vcam.Follow = GameObject.Find("Player").transform;
        }
        else
        {
            Player.PlayerActive = false;
            TileActive = true;
            vcam.Follow = Puzzle.transform;
        }
    }
    IEnumerator CheckAnswer()
    {
        int Count =Puzzle.transform.GetChild(0).transform.childCount;

        for (int i=0; i<Count; i++)
        {
            PuzzleTile.Add(Puzzle.transform.GetChild(0).transform.GetChild(i).GetComponent<Transform>());
            TileScript.Add(Puzzle.transform.GetChild(0).transform.GetChild(i).GetComponent<Puzzle_Tile>());
            
            yield return null;
        }
        while(true)
        {
            int a = 0;
            for (int i = 0; i < Count; i++)
            {
                if(PuzzleTile[i].transform.eulerAngles.z== TileScript[i].Answer)
                {
                    a++;
                }
                yield return null;

            }

            if (Count==a)
            {
                Debug.Log("성공");
                break;
            }
            yield return null;

        }

    }
}
