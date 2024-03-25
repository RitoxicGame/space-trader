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
        }
    }

    public void UpdateBuyQuantity()
    {
        amount.text = "" + quantityToBuy;
    }
}
