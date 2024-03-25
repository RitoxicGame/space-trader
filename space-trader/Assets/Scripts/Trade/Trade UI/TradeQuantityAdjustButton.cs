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
                break;
            case IncOrDec.inc:
                panel.quantityToBuy++;
                break;
        }
        panel.UpdateBuyQuantity();
    }
}
