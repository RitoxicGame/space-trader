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
    //public InventoryReadout inventoryReadout;
    //public BalanceReadout balanceReadout;

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

    /*public void ReloadInventoryReadout()
    {
        inventoryReadout.UpdateInventoryReadout();
        balanceReadout.UpdateBalanceReadout();
    }*/
}
