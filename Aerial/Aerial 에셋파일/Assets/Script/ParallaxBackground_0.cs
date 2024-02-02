using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  Cinemachine;


public class ParallaxBackground_0 : MonoBehaviour
{
   
    [Header("Layer Setting")]
    public float[] Layer_Speed = new float[7];
    public GameObject[] Layer_Objects = new GameObject[7];

    private Transform _camera;
    private float[] startPos = new float[7];
    private float boundSizeX;
    private float sizeX;

    //public GameObject ga;
    //public CinemachineVirtualCamera cam;

    //public Type type;
    //public enum Type 
    //{ 
    //    Camera,
    //    Layer
    //}
    void Start()
    {
       
        _camera = Camera.main.transform;
        sizeX = Layer_Objects[0].transform.localScale.x;
        boundSizeX = Layer_Objects[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        for (int i = 0; i < 3; i++)
        {
            startPos[i] = _camera.position.x;
        }

        // _camera = cam.transform;
        // sizeX = ga.transform.localScale.x;
        //// boundSizeX = Layer_Objects[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        // for (int i = 0; i < 2; i++)
        // {
        //     startPos[i] = _camera.position.x;
        // }
    }

    void Update()
    {

        for (int i = 0; i < 3; i++)
        {
            float temp = (_camera.position.x * (1 - Layer_Speed[i]));
            float distance = _camera.position.x * Layer_Speed[i];

            //y축 제거 
            Layer_Objects[i].transform.position = new Vector2(startPos[i] + distance, 1);

            if (temp > startPos[i] + boundSizeX * sizeX)
            {
                startPos[i] += boundSizeX * sizeX;
                //Debug.Log(1);

            }
            else if (temp < startPos[i] - boundSizeX * sizeX)
            {
                startPos[i] -= boundSizeX * sizeX;
                //Debug.Log(2);

            }

        }
        //for (int i = 0; i < 2; i++)
        //{
        //    float temp = (_camera.position.x * (1 - Layer_Speed[i]));
        //    float distance = _camera.position.x * Layer_Speed[i];

        //    //y축 제거 
        //    Layer_Objects[i].transform.position = new Vector2(startPos[i] + distance, 1);

        //    //if (temp > startPos[i] + boundSizeX * sizeX)
        //    //{
        //    //    startPos[i] += boundSizeX * sizeX;
        //    //    //Debug.Log(1);

        //    //}
        //    //else if (temp < startPos[i] - boundSizeX * sizeX)
        //    //{
        //    //    startPos[i] -= boundSizeX * sizeX;
        //    //    //Debug.Log(2);

        //    //}

        //}
    }
}
