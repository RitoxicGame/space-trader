using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    /// Amount of a given TradeItem the player has in their inventory
    /// </summary>
    public Dictionary<TradeItem, int> cargoHold;

    /// <summary>
    /// Extrapolated value from the TradeItems occupying Cargo Space
    /// </summary>
    public int cargoSpaceInUse;

    /// <summary>
    /// The Image for the ship's associated GameObject
    /// </summary>
    private Image playerSprite;

    //readouts for inventory and balance
    [SerializeField] InventoryReadout inventoryReadout;
    [SerializeField] BalanceReadout balanceReadout;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = 1000; //arbitrary value for testing

        playerSprite = GetComponent<Image>();
        playerSprite.sprite = ship.shipIcon;

        cargoHold = new Dictionary<TradeItem, int>();

        foreach(TradeItem item in PlayerInventoryManager.Instance.allTradeItems)
        {
            cargoHold[item] = 0;
        }
        inventoryReadout.UpdateInventoryReadout();
        balanceReadout.UpdateBalanceReadout();
    }

    /// <summary>
    /// Update the ship's icon.
    /// This should be called whenever the ship changes.
    /// </summary>
    public void UpdateShipIcon()
    {
        playerSprite.sprite = ship.shipIcon;
    }
}
