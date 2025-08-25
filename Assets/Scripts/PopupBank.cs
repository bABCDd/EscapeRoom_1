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
    public NumberUnit numberUnit; // Uncommented and added a reference to NumberUnit
    public InputField inputDeposit;
    public InputField inputWithdraw;
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
        if (GameManager.instance.userData.Cash < amount) 
            return;
        GameManager.instance.userData.Cash -= amount;
        GameManager.instance.userData.Balance += amount;
        numberUnit.Refresh();
    }
    public void WithdrawBtn(int amount)
    {
        if (GameManager.instance.userData.Balance < amount)
            return;
        GameManager.instance.userData.Cash += amount;
        GameManager.instance.userData.Balance -= amount;
        numberUnit.Refresh();
    }

    public void InputDepositBtn(int amount)
    {
        amount = int.Parse(inputDeposit.text);
        if (GameManager.instance.userData.Cash < amount)
            return;
        GameManager.instance.userData.Cash -= amount;
        GameManager.instance.userData.Balance += amount;
        numberUnit.Refresh();
    }

    public void InputWithdrawBtn(int amount)
    {
        amount = int.Parse(inputWithdraw.text);
        if (GameManager.instance.userData.Balance < amount)
            return;
        GameManager.instance.userData.Cash += amount;
        GameManager.instance.userData.Balance -= amount;
        numberUnit.Refresh();
    }
}
