using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TradeType { playerSell, playerBuy }

public class PlanetMarketInstance: MonoBehaviour
{
    /// <summary>
    /// Market value shenanigans
    /// </summary>
    public PlanetMarketPosting[] market;

    /// <summary>
    /// prices at which the player can sell their goods to planets
    /// </summary>
    private Dictionary<TradeItem,float> salePrices;

    /// <summary>
    /// prices at which the player can buy goods from planets
    /// </summary>
    private Dictionary<TradeItem,float> buyPrices;

    //To be implemented
    //[SerializeField] Agent assignedAgent;

    // Start is called before the first frame update
    void Start()
    {
        salePrices = new Dictionary<TradeItem,float>();
        buyPrices = new Dictionary<TradeItem,float>();

        foreach (PlanetMarketPosting postings in market)
        {
            //Debug.Log("Setting prices for " + postings.item.name);
            if (postings.demand > 0)
            {
                salePrices[postings.item] = System.Math.Max(1.10f * (postings.item.baseMarketValue + postings.demand), postings.item.minimumValue);
                buyPrices[postings.item] = System.Math.Max(2.50f * (postings.item.baseMarketValue + postings.demand), postings.item.minimumValue);
            }
            else if (postings.demand < 0)
            {
                salePrices[postings.item] = System.Math.Max(0.30f * (postings.item.baseMarketValue + postings.demand), postings.item.minimumValue);
                buyPrices[postings.item] = System.Math.Max(0.80f * (postings.item.baseMarketValue + postings.demand), postings.item.minimumValue);
            }
            else
            {
                salePrices[postings.item] = 0.95f * (postings.item.baseMarketValue + postings.demand);
                buyPrices[postings.item] = 1.20f * (postings.item.baseMarketValue + postings.demand);
            }
        }
    }

    public float GetSalePrice(TradeItem item)
    {
        return salePrices[item];
    }

    public float GetBuyPrice(TradeItem item)
    {
        return buyPrices[item];
    }
}
