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

    //puzzle�� �ڽ��� answerTile�� �ڽ� ������ ���� (gameobj)
    //�ڽ��� ��ũ��Ʈ�� Puzzle_Tile�� ������ ������Ʈ�� ȸ������ ���ϰ� �Ȱ����� true ��ȯ(bool)
    //�ڽĵ��� ��� true�� �ذ� �ƴϸ� ��� ���
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
                Debug.Log("����");
                break;
            }
            yield return null;

        }

    }
}
