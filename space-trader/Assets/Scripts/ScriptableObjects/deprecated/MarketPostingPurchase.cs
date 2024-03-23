using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/MarketPostingPurchase")]

//Planet's buy order for a given item
public class MarketPostingPurchase : ScriptableObject
{
    //The trade item in question
    public TradeItem item;

    //The price multiplier on this posting
    public float priceFactor;

    //function for recalculating price based on time goes here
}
