using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryReadout : MonoBehaviour
{
    public TextMeshProUGUI inventoryReadout;

    private void Start()
    {
        //inventoryReadout = GetComponentInChildren<TextMeshProUGUI>();
        //UpdateInventoryReadout();
    }

    public void UpdateInventoryReadout()
    {
        inventoryReadout.text = "";

        foreach (TradeItem item in PlayerInventoryManager.Instance.allTradeItems)
        {
            Debug.Log("Adding " + item.itemName + " to Readout");
            /*if (inventoryReadout.text == null || inventoryReadout == null)
            {
                Debug.Log("frick me dude");
            }*/
            if (PlayerInventoryManager.Instance.player == null)
            {
                Debug.Log("frick me dude");
            }
            inventoryReadout.text += item.itemName + ": " + PlayerInventoryManager.Instance.player.cargoHold[item] + "\n";
        }
    }
}