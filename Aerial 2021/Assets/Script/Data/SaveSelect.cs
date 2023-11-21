using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class SaveSelect: MonoBehaviour
{
    public TMP_Text PlayTimeText;
    bool[] savefile = new bool[3];
    public Toggle toggle;
   public DataManager dataManager;

    private void Start()//저장된 파일의 정보를 ui에 미리 불러놔야한다. 일단 시간먼저
    {
        DataManager.instance.data.GameDataFileName = this.gameObject.name;
        DataManager.instance.LoadGameData();    // 해당 슬롯 데이터 불러옴
       // Debug.Log(dataManager.data.PlayTime);
        PlayTimeText.text = dataManager.data.PlayTime;

       
    }
    // Update is called once per frame
    public void SaveLoadData()
    {
        if(toggle.isOn==true)//load
        {
            DataManager.instance.LoadGameData();

        }
        else//save
        {
            DataManager.instance.data.GameDataFileName = this.gameObject.name;
            DataManager.instance.SaveGameData();

            PlayTimeText.text = dataManager.data.PlayTime;
            //Debug.Log();//얘를 ui에 표시

        }

    }
  
}
