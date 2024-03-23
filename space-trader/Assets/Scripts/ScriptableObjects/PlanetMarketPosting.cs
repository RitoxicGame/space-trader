using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlanetMarketPosting")]

public class PlanetMarketPosting: ScriptableObject
{
    public TradeItem item;
    public float supply;
    public float demand;
}
