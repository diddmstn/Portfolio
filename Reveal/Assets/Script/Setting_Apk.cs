using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting_Apk : MonoBehaviour
{
    public GameObject MenuScreen;
    public GameObject Operate_Setting;
    public GameObject ExitWarning_Operate;
    public GameObject EndingWarning_Operate;

    public string EndingSceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingApk()
    {
        Operate_Setting.SetActive(true);
    }
    public void Operate_Exit_Waring()
    {
        ExitWarning_Operate.SetActive(true);
    }
    public void Operate_Ending_Waring()
    {
        EndingWarning_Operate.SetActive(true);
    }

    public void Back()
    {
        Operate_Setting.SetActive(false);
        MenuScreen.SetActive(true);
    }

    public void SettingApkBack()
    {
        ExitWarning_Operate.SetActive(false);
        EndingWarning_Operate.SetActive(false);
    }
    public void GameExit()
    {
        Application.Quit();
    }

    public void Ending()
    {
        SceneManager.LoadScene(EndingSceneToLoad);
    }
}
