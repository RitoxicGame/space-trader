using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfirmationWindow : MonoBehaviour
{
    public ConfirmationWindowButton confirmButton;
    public TradeWindowPanel panel;
    public TextMeshProUGUI quantityField;
    public TextMeshProUGUI valueField;

    private void OnEnable()
    {
        if(confirmButton != null && confirmButton.type == ConfirmationWindowButtonType.confirm)
        {

        }
    }
}
