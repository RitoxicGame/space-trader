using System;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public TravelManager travelManager;
    public TravelConfirmationPanelController confirmationPanelController;

    public string planetName;
    public int travelCost;
    public Planet previousPlanet;
    public Planet nextPlanet;
    internal int portalName;
    internal object portal;

    public void OnPlanetSelected(Planet targetPlanet)
    {
        int travelCost = travelManager.CalculateTravelCost(travelManager.currentPlanet, targetPlanet);
        confirmationPanelController.ShowConfirmation(targetPlanet.planetName, travelCost, () => travelManager.MoveToPlanet(targetPlanet), () => { });
    }
}
