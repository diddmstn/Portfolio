using UnityEngine;
using System;
using System.IO;

public class Data
{
    //저장해야할것: 오늘날짜, 현재위치, 플레이타임, 이벤트진행도, 전기구체 이정도
    // Transform playerPosition =;
 //   public string Day = DateTime.Now.ToString(("yyyy-MM-dd HH:mm"));
    public string GameDataFileName; //세이브파일 이름
    public string PlayTime; // 플레이 시간
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

public void SaveGameData() //기존에 저장된 시간+ 지금진행한 시간  어떻게 구현하지,,
    {
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.persistentDataPath + "/" + data.GameDataFileName;
        //저장할거 할당
       
        data.PlayTime = calculatorTime();
        File.WriteAllText(filePath, ToJsonData);


        /*일단보류
        for(int i=0; i< data.isUnlock.Length;i++)
        {
            print
        }*/

    }
}