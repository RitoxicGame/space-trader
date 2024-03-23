using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Implementation *heavily* inspired by that which was used in Apply to the Industry Simulator, coded chiefly by Rob Reddick and Eduardo Escudero

//public enum WindowType { trade, agent }

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
            panel.Value = planetMarket.GetSalePrice(p.item);
            panel.stock = p.stockAvailable;
            panel.ResetUI();
        }
    }
}

//Agent display window goes here