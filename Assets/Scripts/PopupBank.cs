using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public GameObject Deposit;
    public GameObject ATM;
    public GameObject Withdraw;
    public GameManager gameManager;

    public void OpenDeposit()
    {
        Deposit.SetActive(true);
        Withdraw.SetActive(false);
        ATM.SetActive(false);
    }
    public void OpenWithdraw()
    {
        Deposit.SetActive(false);
        Withdraw.SetActive(true);
        ATM.SetActive(false);
    }
    public void CloseBtn()
    {
        Deposit.SetActive(false);
        Withdraw.SetActive(false);
        ATM.SetActive(true);
    }

    public void DepositBtn(int amount)
    {
        GameManager.instance.userData.Cash -= amount;
        GameManager.instance.userData.Balance += amount;
    }
    public void WithdrawBtn(int amount)
    {
        GameManager.instance.userData.Cash += amount;
        GameManager.instance.userData.Balance -= amount;
    }
}
