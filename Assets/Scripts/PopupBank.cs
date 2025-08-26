using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public GameObject Deposit;
    public GameObject ATM;
    public GameObject Withdraw;
    public GameManager gameManager;
    public NumberUnit numberUnit;
    public InputField inputDeposit;
    public InputField inputWithdraw;
    public Image fail;
/*    private UserData userData;

    private void Start()
    {
        userData = GameManager.instance.userData;
    }*/

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
        {
            StartCoroutine(ShowFailImage());
            return;
        }
        GameManager.instance.userData.Cash -= amount;
        GameManager.instance.userData.Balance += amount;
        numberUnit.Refresh();
        GameManager.instance.SaveUserData();
    }

/*    public void TestDeoposit(int amount)
    {
        bool isSuccess = GameManager.instance.userData.Deposit(amount);
        if (!isSuccess)
        {
            StartCoroutine(ShowFailImage());
            return;
        }
        else
        {
            numberUnit.Refresh();
        }
    }*/

    public void WithdrawBtn(int amount)
    {
        if (GameManager.instance.userData.Balance < amount)
        {
            StartCoroutine(ShowFailImage());
            return;
        }
        GameManager.instance.userData.Cash += amount;
        GameManager.instance.userData.Balance -= amount;
        numberUnit.Refresh();
        GameManager.instance.SaveUserData();
    }

    public void InputDepositBtn(int amount)
    {
        amount = int.Parse(inputDeposit.text);
        if (GameManager.instance.userData.Cash < amount)
        {
            StartCoroutine(ShowFailImage());
            return;
        }
        GameManager.instance.userData.Cash -= amount;
        GameManager.instance.userData.Balance += amount;
        numberUnit.Refresh();
        GameManager.instance.SaveUserData();
    }

    public void InputWithdrawBtn(int amount)
    {
        amount = int.Parse(inputWithdraw.text);
        if (GameManager.instance.userData.Balance < amount)
        {
            StartCoroutine(ShowFailImage());
            return;
        }
        GameManager.instance.userData.Cash += amount;
        GameManager.instance.userData.Balance -= amount;
        numberUnit.Refresh();
        GameManager.instance.SaveUserData();
    }
    public IEnumerator ShowFailImage()
    {
        fail.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        fail.gameObject.SetActive(false);
    }
}
