using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/TradeItem")]

///<summary>
///Remember to add these to PlayerInventoryManager's allTradeItems list as soon as they are made!
///</summary>
public class TradeItem : ScriptableObject
{
    /// <summary>
    /// Sprite to use when displaying the trade good
    /// </summary>
    public Sprite sprite;

    /// <summary>
    /// Item name
    /// </summary>
    public string itemName;

    /// <summary>
    /// Base sell price for an item
    /// </summary>
    public float baseMarketValue;

    /// <summary>
    /// Absolute minimum buy/sell price for an item
    /// </summary>
    public float minimumValue;

    /// <summary>
    /// Multiplier for market shifts -- to be implemented
    /// </summary>
    public float volatility;

    /// <summary>
    /// How much space one unit takes up in cargo hold
    /// </summary>
    public int cargoVolume;

    /// <summary>
    /// Illegal? -- to be implemented
    /// </summary>
    public bool contraband;
}
