using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeQuantityAdjustButton : MonoBehaviour
{
    /// <summary>
    /// Whether this button increases (+) or decreases (-) the quantity field
    /// </summary>
    [SerializeField] IncOrDec type;

    /// <summary>
    /// The trade panel itself -- used to pass back adjusted quantity data
    /// and call methods to update text field
    /// </summary>
    [SerializeField] TradeWindowPanel panel;

    public void OnClick()
    {
        switch(type)
        {
            //Minus was pressed -- Decrement the quantity field
            case IncOrDec.dec:
                if (Input.GetButton("Control") && Input.GetButton("Shift"))
                {
                    panel.quantityToBuy = System.Math.Max(panel.quantityToBuy - 1000, 0);
                }
                else if (Input.GetButton("Control"))
                {
                    panel.quantityToBuy = System.Math.Max(panel.quantityToBuy - 100, 0);
                }
                else if (Input.GetButton("Shift"))
                {
                    panel.quantityToBuy = System.Math.Max(panel.quantityToBuy - 10, 0);
                }
                else
                {
                    panel.quantityToBuy = System.Math.Max(panel.quantityToBuy - 1, 0);
                }
                break;
            //Plus was pressed -- Increment the quantity field
            case IncOrDec.inc:
                if (Input.GetButton("Control") && Input.GetButton("Shift"))
                {
                    panel.quantityToBuy += 1000;
                }
                else if (Input.GetButton("Control"))
                {
                    panel.quantityToBuy += 100;
                }
                else if (Input.GetButton("Shift"))
                {
                    panel.quantityToBuy += 10;
                }
                else
                {
                    panel.quantityToBuy += 1;
                }
                if (panel.tradeType == TradeType.playerBuy/* &&
                    (panel.quantityToBuy * panel.item.cargoVolume) + PlayerInventoryManager.Instance.player.cargoSpaceInUse
                    > PlayerInventoryManager.Instance.player.ship.shipCargoSpace*/)
                {
                    //When player is buying something, increment the quantityToBuy ONLY IF they have enough cargo space to hold it
                    panel.quantityToBuy = System.Math.Min(
                        (int) ((PlayerInventoryManager.Instance.player.ship.shipCargoSpace
                        - PlayerInventoryManager.Instance.player.cargoSpaceInUse)
                        / panel.item.cargoVolume),
                        panel.quantityToBuy);

                    //TODO: give feedback for this in-game
                    //Debug.Log("Not enough inventory space to fit any more!");
                }
                else if (panel.tradeType == TradeType.playerSell/* &&
                    panel.quantityToBuy > PlayerInventoryManager.Instance.player.cargoHold[panel.item]*/)
                {
                    //When player is selling, increment quantityToBuy ONLY IF they have enough of the item in their inventory
                    panel.quantityToBuy = System.Math.Min(PlayerInventoryManager.Instance.player.cargoHold[panel.item], panel.quantityToBuy);

                    //TODO: give feedback for this in-game
                    //Debug.Log("Not enough " + panel.item.itemName + " to sell any more!");
                }
                break;
        }
        panel.UpdateBuyQuantity();
    }
}
