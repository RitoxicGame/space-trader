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
    public TextMeshProUGUI InventoryReadout;
    public TextMeshProUGUI BalanceReadout;

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

    public void ReloadInventoryReadout()
    {
        InventoryReadout.text = ""; 
        BalanceReadout.text = "";
        foreach (TradeItem item in allTradeItems)
        {
            InventoryReadout.text += item.itemName + ": " + player.cargoHold[item] + "\n";
        }
        BalanceReadout.text = "Balance: " + player.playerMoney + "";
    }
}
