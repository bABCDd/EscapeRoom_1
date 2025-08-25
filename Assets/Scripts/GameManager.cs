using System.Collections;
using System.Collections.Generic;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
