using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum IncOrDec { inc, dec }

//Implementation inspired by that which was used in Apply to the Industry Simulator, coded chiefly by Rob Reddick and Eduardo Escudero

public class TradeWindowPanel : MonoBehaviour
{
    /// <summary>
    /// The item being bought or sold.
    /// </summary>
    public TradeItem item;

    /// <summary>
    /// The type of transaction -- buy or sell.
    /// </summary>
    public TradeType tradeType;

    /// <summary>
    /// The amount of a given item available in a given market.
    /// Has yet to be implemented -- for now all stocks are infinite.
    /// </summary>
    public int stock;

    /// <summary>
    /// The amount the player intends to buy
    /// </summary>
    public int quantityToBuy = 0;

    //UI Text and Image fields to be filled
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI cost;
    [SerializeField] TextMeshProUGUI amount;
    [SerializeField] TextMeshProUGUI purchaseText;
    [SerializeField] TextMeshProUGUI sellText;
    [SerializeField] Image sprite;

    /// <summary>
    /// The total value of the transaction.
    /// Positive values mean the player is selling something, while
    /// Negative values mean the player is buying someting.
    /// </summary>
    private float _value;
    public float Value
    {
        get { return _value; }
        set
        { 
            if(this.tradeType == TradeType.playerBuy) _value = value * -1;
            else if(this.tradeType == TradeType.playerSell) _value = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetUI();
    }

    /// <summary>
    /// Reset the UI when a major change occurs, such as the window being reloaded.
    /// </summary>
    public void ResetUI()
    {
        purchaseText.gameObject.SetActive(false);
        sellText.gameObject.SetActive(false);
        if (item != null)
        {
            itemName.text = item.name;
            cost.text = "Value: " + System.Math.Abs(_value);

            if (sprite != null)
            {
                sprite.sprite = item.sprite;
            }
            quantityToBuy = 0;
            amount.text = "" + quantityToBuy;
            if(tradeType == TradeType.playerBuy)
            {
                purchaseText.gameObject.SetActive(true);
                sellText.gameObject.SetActive(false);
            }
            else
            {
                purchaseText.gameObject.SetActive(false);
                sellText.gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Update th Quantity text field when the value changes -- see TradeQuantityAdjustButton.cs
    /// </summary>
    public void UpdateBuyQuantity()
    {
        amount.text = "" + quantityToBuy;
    }

    /// <summary>
    /// ToString override for debugging purposes.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "Panel containing " + quantityToBuy + " " + item.itemName + " valued at " + System.Math.Abs(_value) + " currency each";
    }
}
