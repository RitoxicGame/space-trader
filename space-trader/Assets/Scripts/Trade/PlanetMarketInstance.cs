using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TradeType { playerSell, playerBuy }

public class PlanetMarketInstance: MonoBehaviour
{
    //Market value shenanigans
    public PlanetMarketPosting[] market;

    /// <summary>
    /// prices at which **planets** will sell their goods
    /// **to the player**.
    /// </summary>
    private Dictionary<TradeItem,float> salePrices;

    /// <summary>
    /// prices at which **planets** will buy goods
    /// **from the player**;
    /// </summary>
    private Dictionary<TradeItem,float> buyPrices;

    //To be implemented
    //[SerializeField] Agent assignedAgent;

    // Start is called before the first frame update
    void Start()
    {
        foreach (PlanetMarketPosting markets in market)
        {
            Debug.Log("Setting prices for " + markets.item.name);
            if (markets.demand < 0)
            {
                salePrices[markets.item] = markets.item.baseMarketValue + markets.demand;
                buyPrices[markets.item] = 0.5f * (markets.item.baseMarketValue + markets.demand);
            }
            else if (markets.demand > 0)
            {
                salePrices[markets.item] = 0.5f * (markets.item.baseMarketValue + markets.demand);
                buyPrices[markets.item] = markets.item.baseMarketValue + markets.demand;
            }
            else
            {
                salePrices[markets.item] = markets.item.baseMarketValue + markets.demand;
                buyPrices[markets.item] = markets.item.baseMarketValue + markets.demand;
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
