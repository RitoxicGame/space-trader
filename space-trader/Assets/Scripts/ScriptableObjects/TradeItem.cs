using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/TradeItem")]
public class TradeItem : ScriptableObject
{
    //Sprite to use when displaying the trade good
    public Sprite sprite;

    //Item name
    public string itemName;

    //Base sell price for an item
    public float baseMarketValue;

    //How much space one unit takes up in cargo hold
    public int cargoVolume;

    //Multiplier for market shifts
    public float volatility; //to be implemented later

    //Illegal?
    public bool contraband; //to be implemented
}
