using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    /// <summary>
    /// Singleton player inventory manager instance
    /// </summary>
    public static PlayerInventoryManager Instance;

    /// <summary>
    /// Instance holding data for the player's ship, cargo, and money
    /// </summary>
    public PlayerShipAndInventory player;

    /// <summary>
    /// A list of all TradeItem scriptable objects currently in use.
    /// Please add new ones here when they are made!
    /// </summary>
    public TradeItem[] allTradeItems;

    //Text fields to display inventory and balance
    public TextMeshProUGUI inventoryReadout;
    public TextMeshProUGUI balanceReadout;

    //List of Agents the player has at their disposal goes here

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {

    }

    public void ReloadInventoryReadout()
    {
        inventoryReadout = InventoryReadout.Instance.inventoryReadout;
        balanceReadout = BalanceReadout.Instance.balanceReadout;

        inventoryReadout.text = "";
        balanceReadout.text = "";

        foreach (TradeItem item in allTradeItems)
        {
            Debug.Log("Adding " + item.itemName + " to Readout");
            inventoryReadout.text += item.itemName + ": " + player.cargoHold[item] + "\n";
        }
        balanceReadout.text = "Balance: " + player.playerMoney + "";
    }
}
