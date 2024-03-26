using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalanceReadout : MonoBehaviour
{
    public TextMeshProUGUI balanceReadout;

    void Start()
    {
        //balanceReadout = GetComponentInChildren<TextMeshProUGUI>();
        //UpdateBalanceReadout();
    }

    public void UpdateBalanceReadout()
    {
        Debug.Log(PlayerInventoryManager.Instance.player.playerMoney + "");
        balanceReadout.text = "Balance: " + PlayerInventoryManager.Instance.player.playerMoney + "";
    }
}
