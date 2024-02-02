using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Guidline : MonoBehaviour
{
    public CanvasGroup Guideline;
    public GameObject Guide;
    private bool Active ;
    // Start is called before the first frame up

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Guide.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Active = true;
            StartCoroutine(Fade_In(Guideline));
        }
    }

    IEnumerator Fade_In(CanvasGroup canvas)
    {
       
        while (canvas.alpha >0f)
        {
            canvas.alpha -= 0.01f;
            yield return new WaitForSeconds(0.00001f);
        }
        if(canvas.alpha==0f)
        {
            Destroy(this.gameObject);
        }
        yield return null;

    }
}
