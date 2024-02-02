using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionTaps : MonoBehaviour
{
    Toggle toggle;
    public GameObject Operate;
    private void Start()
    {
        toggle = this.GetComponent<Toggle>();
    }
    
    public void TabToggleEnter()//-416->-556
    {
        this.gameObject.transform.localPosition = new Vector2(-556, this.transform.localPosition.y);
    }
    public void TabToggleExit()
    {
        if(toggle.isOn==false)
        {
            this.gameObject.transform.localPosition = new Vector2(-416, this.transform.localPosition.y);
        }
       

    }

    public void ToggleOff()
    {
        if(toggle.isOn==false)
        {
            Operate.SetActive(false);
            TabToggleExit();
        }
        else
        {
            Operate.SetActive(true);
        }
    }
}
