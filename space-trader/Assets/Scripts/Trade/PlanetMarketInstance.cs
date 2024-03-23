using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMarketInstance: MonoBehaviour
{
    //Market value shenanigans
    [SerializeField] public PlanetMarketPosting[] market;

    private Dictionary<TradeItem,float> salePrices;
    private Dictionary<TradeItem,float> buyPrices;

    //To be implemented
    //[SerializeField] Agent assignedAgent;

    //Including a ref back to the planet, just in case
    //[SerializeField] Planet planeta;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (PlanetMarketPosting markets in market)
        {
            salePrices[markets.item] = markets.item.baseMarketValue - markets.supply;
            buyPrices[markets.item] = markets.item.baseMarketValue + markets.demand;
            i++;
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
