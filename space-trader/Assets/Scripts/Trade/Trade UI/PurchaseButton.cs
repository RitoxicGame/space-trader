using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public TradeWindowPanel panel;
    public ConfirmationWindow confirmation;

    /*private void Awake()
    {
        panel = this.gameObject.GetComponentInParent<TradeWindowPanel>();
    }*/

    public void OnClick()
    {
        if (panel != null && confirmation != null)
        {
            TradeManager.Instance.ToggleConfirmationWindow(confirmation);
            confirmation.panel = panel;
        }
    }
}
