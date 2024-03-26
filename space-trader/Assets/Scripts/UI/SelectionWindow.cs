using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Implementation *heavily* inspired by that which was used in Apply to the Industry Simulator,
// which was coded chiefly by Rob Reddick and Eduardo Escudero

public enum WindowType { buyTrade, sellTrade, agent }

public interface ISelectionWindow
{
    public void LoadData();
    public void DisplayPanels(GridLayoutGroup layoutContainer, GameObject panelPrefab);
}

public class BuyTradeWindow : ISelectionWindow
{
    PlanetMarketInstance planetMarket;

    public void LoadData()
    {
        planetMarket = TradeManager.Instance.travelManager.currentPlanet.GetComponent<PlanetMarketInstance>();
    }

    public void DisplayPanels(GridLayoutGroup layoutContainer, GameObject panelPrefab)
    {
        foreach (PlanetMarketPosting p in planetMarket.market)
        {
            //Create the button
            GameObject panelButton = Object.Instantiate(panelPrefab);

            //Set it to be a child of the grid layout
            panelButton.transform.SetParent(layoutContainer.transform);

            //Add the Trade Item data
            TradeWindowPanel panel = panelButton.GetComponent<TradeWindowPanel>();
            panel.tradeType = TradeType.playerBuy;
            panel.item = p.item;
            panel.Value = panel.baseValue = planetMarket.GetBuyPrice(p.item);
            panel.stock = p.stockAvailable;
            panel.ResetUI();
        }
    }
}

public class SellTradeWindow : ISelectionWindow
{
    PlanetMarketInstance planetMarket;

    public void LoadData()
    {
        planetMarket = TradeManager.Instance.travelManager.currentPlanet.GetComponent<PlanetMarketInstance>();
    }

    public void DisplayPanels(GridLayoutGroup layoutContainer, GameObject panelPrefab)
    {
        foreach (PlanetMarketPosting p in planetMarket.market)
        {
            //Create the button
            GameObject panelButton = Object.Instantiate(panelPrefab);

            //Set it to be a child of the grid layout
            panelButton.transform.SetParent(layoutContainer.transform);

            //Add the Trade Item data
            TradeWindowPanel panel = panelButton.GetComponent<TradeWindowPanel>();
            panel.tradeType = TradeType.playerSell;
            panel.item = p.item;
            panel.Value = panel.baseValue = planetMarket.GetSalePrice(p.item);
            panel.stock = p.stockAvailable;
            panel.ResetUI();
        }
    }
}

//Agent display window goes here

public static class SelectWindowType
{
    public static ISelectionWindow ChooseWindowType(WindowType type) 
    {
        switch(type)
        {
            case WindowType.buyTrade:
                return new BuyTradeWindow();
                
            case WindowType.sellTrade:
                return new SellTradeWindow();

            default: return null;
        }
    }
}