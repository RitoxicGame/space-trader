using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    private TradeWindowPanel panel;
    //public ConfirmationWindow confirmation; frick me am I ever stupid XD ~QP

    private void OnEnable()
    {
        panel = this.gameObject.GetComponentInParent<TradeWindowPanel>();
    }

    public void OnClick()
    {
        if (panel != null)
        {
            if (panel.quantityToBuy > 0)
            {
                //Debug.Log("Loading confirmation window for " + panel.item.itemName);
                TradeManager.Instance.confirmationWindow.panel = panel;
                //Debug.Log("From PurchaseButton: " + confirmation.panel);
                TradeManager.Instance.ToggleConfirmationWindow(/*confirmation*/);
            }
            else Debug.Log("Buy somethin', will ya?");
        }
    }
}
