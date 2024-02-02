using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] GameObject Dialogue_Image;
    [SerializeField] GameObject DialogueCanvas;

    [SerializeField] TMP_Text Dialogue_text;
    [SerializeField] TMP_Text Name_text;

    Dialogue[] dialogues;

    bool isNext = false;
    [SerializeField] public bool isDialogue = false;
    public GameObject DroneImage = null;
    int lineCount = 0;
    int contextCount = 0;

    string ReplaceText;
    // Start is called before the first frame update


    //private void Start()
    //{
    //    ShowDialogue(this.GetComponent<InteractionEvent>().GetDialogue());  
    //}

    private void Update()
    {
        if(Name_text.text!=null)
        {
            if (Name_text.text == "╫ц╫╨еш")
            {
                if(DroneImage!=null)
                {
                    DroneImage.SetActive(false);
                }
                DialogueCanvas.transform.localPosition = new Vector2(0, 344);
            }
            else
            {
                DialogueCanvas.transform.localPosition = new Vector2(0, -360);
            }
        }
       
        if (isDialogue)
        {
            if(isNext)
            {
                if (Input.GetKeyDown(KeyCode.E) && Time.timeScale == 1)
                {
                    isNext = false;
                    Dialogue_text.text = "";
                    
                    if(++contextCount<dialogues[lineCount].contexts.Length)
                    {
                        StartCoroutine(TypeWriter());

                    }
                    else
                    {
                        contextCount = 0;
                        if (++lineCount<dialogues.Length)
                        {
                            StartCoroutine(TypeWriter());
                        }
                        else
                        {
                            StartCoroutine(EndDialogue());
                        }
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E) && Time.timeScale == 1)
                {
                    StopAllCoroutines();
                    Dialogue_text.text = ReplaceText;
                    isNext = true;

                }
            }
        }
    }

    IEnumerator EndDialogue()
    {
        Dialogue_Image.SetActive(false);
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        isDialogue = false;

        yield return new WaitForSecondsRealtime(0.3f);
        Player.PlayerActive = true;


    }
    public void ShowDialogue(Dialogue[] p_dialogue)
    {
        isDialogue = true;
        Dialogue_text.text = "";
        Name_text.text = "";
        dialogues = p_dialogue;

        StartCoroutine(TypeWriter());
    }

    IEnumerator TypeWriter()
    {
        //ActiveUI();
       
        ReplaceText = dialogues[lineCount].contexts[contextCount];
        ReplaceText = ReplaceText.Replace("'",",");
        ReplaceText = ReplaceText.Replace("\\n","\n");
        ReplaceText = ReplaceText.Replace("$","'");

        //Dialogue_text.text = ReplaceText;
        Name_text.text = dialogues[lineCount].name;
     
        for (int i = 0; i < ReplaceText.Length; i++)
        {
            Dialogue_text.text += ReplaceText[i];
            yield return new WaitForSeconds(0.1f);
            

        }
      
        isNext = true;

        yield return null;

    }

    public void ActiveDialogue_UI()
    {
        Player.PlayerActive = false;

        Dialogue_Image.SetActive(true);
        ShowDialogue(this.GetComponent<InteractionEvent>().GetDialogue());

    }


}
