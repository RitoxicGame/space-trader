using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfirmationWindow : MonoBehaviour
{
    /// <summary>
    /// The button which confirms the transaction --
    /// This passes necessary transaction data to the TradeManager for processing
    /// </summary>
    private ConfirmationWindowButton confirmButton;

    /// <summary>
    /// The TradeWindowPanel that holds the transaction info
    /// </summary>
    public TradeWindowPanel panel;

    //Static text fields to indicate whether the player is buying or selling
    public TextMeshProUGUI playerBuyQuantityText;
    public TextMeshProUGUI playerSellQuantityText;
    public TextMeshProUGUI playerBuyValueText;
    public TextMeshProUGUI playerSellValueText;

    //Variable text fields to display item and transaction data
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI baseMarketValueField;
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
            && baseMarketValueField != null
            && quantityField != null
            && valueField != null)
        {
            //Debug.Log("From ConfirmationWindow: " + panel);
            confirmButton.panel = panel;
            nameField.text = panel.item.itemName;
            baseMarketValueField.text = panel.item.baseMarketValue + "";
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

    /// <summary>
    /// Purge the data-holding component references and hide the static text windows
    /// </summary>
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
