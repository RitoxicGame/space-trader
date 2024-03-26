using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipAndInventory : MonoBehaviour
{
    /// <summary>
    /// The player's current ship
    /// </summary>
    public PlayerShip ship;

    /// <summary>
    /// Amount of currency the player has
    /// </summary>
    public float playerMoney;

    /// <summary>
    /// Associates TradeItems to the Cargo Volume they occupy in the player's inventory
    /// </summary>
    public Dictionary<TradeItem, int> cargoHold;

    /// <summary>
    /// Extrapolated value from the TradeItems occupying Cargo Space
    /// </summary>
    public int cargoSpaceInUse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
