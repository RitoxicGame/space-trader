using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlanetMarketPosting")]

public class PlanetMarketPosting: ScriptableObject
{
    public TradeItem item;
    public float demand;
    public int stockAvailable; //To be implemented: For now, assume all stocks are infinite
}
