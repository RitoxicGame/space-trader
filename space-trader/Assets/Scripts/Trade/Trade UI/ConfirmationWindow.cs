using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfirmationWindow : MonoBehaviour
{
    private ConfirmationWindowButton confirmButton;
    public TradeWindowPanel panel;
    public TextMeshProUGUI playerBuyQuantityText;
    public TextMeshProUGUI playerSellQuantityText;
    public TextMeshProUGUI playerBuyValueText;
    public TextMeshProUGUI playerSellValueText;
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI quantityField;
    public TextMeshProUGUI valueField;

    public void OnEnable()
    {
        ConfirmationWindowButton[] confirmationWindowButtons = GetComponentsInChildren<ConfirmationWindowButton>();
        foreach (ConfirmationWindowButton button in confirmationWindowButtons)
        {
            if (button != null && button.type == ConfirmationWindowButtonType.confirm)
            {
                confirmButton = button;
            }
        }

        //Debug.Log(confirmButton);

        if (confirmButton != null
            && panel != null
            && nameField != null
            && quantityField != null
            && valueField != null)
        {
            Debug.Log("From ConfirmationWindow: " + panel);
            confirmButton.panel = panel;
            nameField.text = panel.item.itemName;
            quantityField.text = panel.quantityToBuy + "";
            valueField.text = System.Math.Abs(panel.Value * panel.quantityToBuy) + "";
        }

        //Set appropriate text panels (Purchase Cost vs. Sale Value)
        if (panel.tradeType == TradeType.playerSell)
        {
            playerSellValueText.gameObject.SetActive(true);
            playerBuyValueText.gameObject.SetActive(false);
            playerSellQuantityText.gameObject.SetActive(true);
            playerBuyQuantityText.gameObject.SetActive(false);
        }
        else
        {
            playerSellValueText.gameObject.SetActive(false);
            playerBuyValueText.gameObject.SetActive(true);
            playerSellQuantityText.gameObject.SetActive(false);
            playerBuyQuantityText.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        confirmButton = null;
        panel = null;
        playerSellValueText.gameObject.SetActive(false);
        playerBuyValueText.gameObject.SetActive(false);
        playerSellQuantityText.gameObject.SetActive(false);
        playerBuyQuantityText.gameObject.SetActive(false);
    }
}
