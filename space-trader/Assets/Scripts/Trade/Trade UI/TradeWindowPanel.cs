using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum IncOrDec { inc, dec }

//Implementation inspired by that which was used in Apply to the Industry Simulator, coded chiefly by Rob Reddick and Eduardo Escudero

public class TradeWindowPanel : MonoBehaviour
{
    public TradeItem item;
    public TradeType tradeType;
    public int stock; //To be implemented -- for now all stocks are infinite
    public int quantityToBuy = 0;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI cost;
    [SerializeField] TextMeshProUGUI amount;
    [SerializeField] TextMeshProUGUI purchaseText;
    [SerializeField] TextMeshProUGUI sellText;
    [SerializeField] Image sprite;


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

    public void UpdateBuyQuantity()
    {
        amount.text = "" + quantityToBuy;
    }

    public override string ToString()
    {
        return "Panel containing " + quantityToBuy + " " + item.itemName + " valued at " + System.Math.Abs(_value) + " currency each";
    }
}
