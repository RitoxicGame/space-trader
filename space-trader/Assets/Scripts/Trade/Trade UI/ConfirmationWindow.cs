using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfirmationWindow : MonoBehaviour
{
    private ConfirmationWindowButton confirmButton;
    public TradeWindowPanel panel;
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI quantityField;
    public TextMeshProUGUI valueField;

    private void Start()
    {
        ConfirmationWindowButton[] confirmationWindowButtons = GetComponentsInChildren<ConfirmationWindowButton>();
        foreach (ConfirmationWindowButton button in confirmationWindowButtons)
        {
            if (button != null && button.type == ConfirmationWindowButtonType.confirm)
            {
                confirmButton = button;
            }
        }
    }

    private void OnEnable()
    {
        if(confirmButton != null
            && panel != null
            && nameField != null
            && quantityField != null
            && valueField != null
            && confirmButton.type == ConfirmationWindowButtonType.confirm)
        {
            nameField.text = panel.item.itemName;
            quantityField.text = panel.quantityToBuy + "";
            valueField.text = panel.Value + "";
        }
    }
}
