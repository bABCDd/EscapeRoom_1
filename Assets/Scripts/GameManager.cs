using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UserData userData;
    public NumberUnit numberUnit;

    void Awake()
    {
        //userData = new UserData("Kim", 100000, 50000);

        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        //numberUnit.Refresh();
        if (File.Exists(Application.persistentDataPath + "/UserData.json"))
        {
            LoadUserData();
        }
    }

    public void SaveUserData()  //Json���� ���� ������ ����
    {        
        string saveData = JsonUtility.ToJson(userData);
        File.WriteAllText(Application.persistentDataPath + "/UserData.json", saveData);
    }

    public void LoadUserData() //Json���� ���� ������ �ҷ�����
    {   
        string path = File.ReadAllText(Application.persistentDataPath + "/UserData.json");
        userData = JsonUtility.FromJson<UserData>(path);
    }
}
