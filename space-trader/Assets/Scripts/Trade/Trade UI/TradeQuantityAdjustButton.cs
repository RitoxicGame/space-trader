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
                //CHECK TO SEE IF IT WILL FIT IN CARGO HOLD ~QP
                break;
        }
        panel.UpdateBuyQuantity();
    }
}
