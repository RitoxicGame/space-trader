using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TradeItem : ScriptableObject
{
    //Base sell price for an item
    public float baseMarketValue;

    //Multiplier for market shifts
    public float volatility; //to be implemented later

    //Max amount that can be held in one cargo slot
    public int maxStackSize;

    //Illegal?
    public bool contraband; //to be implemented

    //Sprite to use when displaying the trade good
    public Sprite sprite;
}
