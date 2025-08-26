using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class NumberUnit : MonoBehaviour
{
    private UserData userData;
    //public int BalanceInput;
    //public int MoneyInput;
    public Text BalanceText;
    public Text MoneyText;
    public Text NameText;

    void Start()
    {
        userData = GameManager.instance.userData;
        Refresh();
    }
    public void Refresh()
    {
        BalanceText.text = string.Format("{0:N0}", userData.Balance);
        MoneyText.text = string.Format("{0:N0}", userData.Cash);
        NameText.text = userData.UserName;
    }
}
