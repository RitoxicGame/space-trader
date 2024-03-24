using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public TradeWindowPanel panel;
    public ConfirmationWindow confirmation;

    public void OnClick()
    {
        if (panel != null)
        {
            TradeManager.Instance.ToggleConfirmationWindow(confirmation);
            confirmation.panel = panel;
        }
    }
}
