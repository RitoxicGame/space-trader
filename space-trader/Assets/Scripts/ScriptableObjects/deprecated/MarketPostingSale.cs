using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/MarketPostingSale")]

//Planet's posting for an item for sale
public class MarketPostingSale : ScriptableObject
{
    //The trade item in question
    public TradeItem item;

    //The price multiplier on this posting
    public float priceFactor;

    //function for recalculating price based on time goes here
}
