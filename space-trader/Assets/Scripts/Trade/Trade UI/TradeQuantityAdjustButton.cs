using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeQuantityAdjustButton : MonoBehaviour
{
    [SerializeField] IncOrDec type;
    [SerializeField] TradeWindowPanel panel;

    public void OnClick()
    {
        switch(type)
        {
            case IncOrDec.dec:
                panel.quantityToBuy--;
                panel.quantityToBuy = System.Math.Max(panel.quantityToBuy, 0);
                break;
            case IncOrDec.inc:
                panel.quantityToBuy++;
                //CHECK TO SEE IF IT WILL FIT IN CARGO HOLD ~QP
                break;
        }
        panel.UpdateBuyQuantity();
    }
}
