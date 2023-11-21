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

    private void Start()//����� ������ ������ ui�� �̸� �ҷ������Ѵ�. �ϴ� �ð�����
    {
        DataManager.instance.data.GameDataFileName = this.gameObject.name;
        DataManager.instance.LoadGameData();    // �ش� ���� ������ �ҷ���
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
            //Debug.Log();//�긦 ui�� ǥ��

        }

    }
  
}
