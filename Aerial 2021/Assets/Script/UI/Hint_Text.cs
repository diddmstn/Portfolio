using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint_Text : MonoBehaviour
{
    [TextArea]
    public string Text;
    Text Hint;

    private void Start()
    {
        Hint = GameObject.Find("Hints").transform.Find("Hint").transform.Find("Image").transform.Find("Text").transform.Find("HintText").GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Hint.text = Text;
        }
    }
}
