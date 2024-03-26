using System.Collections;
using UnityEngine;

public class TravelManager : MonoBehaviour
{
    public Planet currentPlanet;
    public GameObject rocketShip;
    private Vector3 targetPosition;

    public void MoveToPlanet(Planet targetPlanet)
    {
        int totalCost = CalculateTravelCost(currentPlanet, targetPlanet);

        if (CanPlayerAffordTravel(totalCost))
        {
            // Deduct the currency here

            // Update the rocket's target position and start coroutine to move it
            targetPosition = targetPlanet.transform.position;
            StartCoroutine(MoveRocketToTarget());

            // Update currentPlanet
            currentPlanet = targetPlanet;
        }
        else
        {
            // Notify the player they can't afford the travel
        }
    }

    public int CalculateTravelCost(Planet startPlanet, Planet targetPlanet)
    {
        int cost = 0;
        Planet tempPlanet = startPlanet;
        bool backwardsFlag = false;
        // Add cost while traversing through the nodes to the targetPlanet
        while (tempPlanet != targetPlanet)
        {
     
            if ((tempPlanet.nextPlanet != null) && !backwardsFlag)
            {
                Debug.Log("can go forward");
                cost += tempPlanet.nextPlanet.travelCost;
                Debug.Log(tempPlanet.nextPlanet.planetName + tempPlanet.nextPlanet.travelCost);
                tempPlanet = tempPlanet.nextPlanet;
            }
            else if ((tempPlanet.nextPlanet == null) && !backwardsFlag)
            {
                cost = 0;
                tempPlanet = startPlanet;
                backwardsFlag = true;
            }
            else if (tempPlanet.previousPlanet != null) // For backward movement
            {
                Debug.Log("can't go forward");
                cost += tempPlanet.previousPlanet.travelCost;
                Debug.Log(tempPlanet.previousPlanet.planetName + tempPlanet.previousPlanet.travelCost);
                tempPlanet = tempPlanet.previousPlanet;
            }
        }

        return cost;
    }

    private IEnumerator MoveRocketToTarget()
    {
        while (rocketShip.transform.position != targetPosition)
        {
            rocketShip.transform.position = Vector3.MoveTowards(rocketShip.transform.position, targetPosition, 100 * Time.deltaTime);
            yield return null;
        }
    }

    private bool CanPlayerAffordTravel(int cost)
    {
        // TODO: logic to check if the player has enough currency
        return true;
    }

}