using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    public Transform Player;
    Vector2 aaa;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        aaa = Player.transform.position;

        transform.position = Camera.main.WorldToScreenPoint(aaa + new Vector2(0,1));
    }
}
