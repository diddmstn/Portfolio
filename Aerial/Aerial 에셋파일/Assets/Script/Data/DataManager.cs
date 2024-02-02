using UnityEngine;
using System;
using System.IO;

public class Data
{
    //�����ؾ��Ұ�: ���ó�¥, ������ġ, �÷���Ÿ��, �̺�Ʈ���൵, ���ⱸü ������
    // Transform playerPosition =;
 //   public string Day = DateTime.Now.ToString(("yyyy-MM-dd HH:mm"));
    public string GameDataFileName; //���̺����� �̸�
    public string PlayTime; // �÷��� �ð�
    public int AllTime;
    
   
}
public class DataManager : MonoBehaviour
{
    public Data data = new Data();

    public string filePath;
    public int nowSlot;
   
    #region Singleton
    public static DataManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    string calculatorTime()
    {
        int playTime = (int)Time.realtimeSinceStartup;
        int hour = playTime / 3600;
        int min = playTime / 60;
        int sec = playTime % 60;

        return (hour.ToString("D2") + ":" + min.ToString("D2") + ":" + sec.ToString("D2"));

    }


    public void LoadGameData()
    {
         filePath = Application.persistentDataPath + "/" + data.GameDataFileName;

        if (File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(FromJsonData);
        }

}

public void SaveGameData() //������ ����� �ð�+ ���������� �ð�  ��� ��������,,
    {
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.persistentDataPath + "/" + data.GameDataFileName;
        //�����Ұ� �Ҵ�
       
        data.PlayTime = calculatorTime();
        File.WriteAllText(filePath, ToJsonData);


        /*�ϴܺ���
        for(int i=0; i< data.isUnlock.Length;i++)
        {
            print
        }*/

    }
}