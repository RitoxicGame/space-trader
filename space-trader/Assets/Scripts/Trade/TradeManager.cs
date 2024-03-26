using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TradeManager: MonoBehaviour
{
    public static TradeManager Instance;

    public TravelManager travelManager;
    public ConfirmationWindow confirmationWindow;
    //[SerializeField] TradeUI tradeWindow;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //tradeWindow.gameObject.SetActive(false);
        //I might be stupid lol ~QP
        /*planets = travelManager.gameObject.GetComponentsInChildren<Planet>();
        foreach (Planet market in planets)
        {
            planetas[market] = market.get;
        }*/
    }

    public bool CompleteTransaction(TradeWindowPanel panel)
    {
        Debug.Log((panel.tradeType == TradeType.playerSell ? "Giving player " : "Charging player ") +
            System.Math.Abs(panel.Value) +
            " in-game currency");

        if (panel.tradeType == TradeType.playerBuy) //if the player is trying to buy something
        {
            if (PlayerInventoryManager.Instance.player.playerMoney > System.Math.Abs(panel.Value)) //if the player has enough money
            {
                //TODO: factor in planet TradeItem stock/availability

                if (PlayerInventoryManager.Instance.player.cargoSpaceInUse //if the current cargo volume...
                    + (panel.quantityToBuy * panel.item.cargoVolume) //...plus the volume of items the player is attempting to buy...
                    <= PlayerInventoryManager.Instance.player.ship.shipCargoSpace) //...is no greater than the ship's cargo capacity...
                {
                    //Subtract cost from player money
                    //(NOTE: panel.Value will **always be NEGATIVE** for TradeType.playerBuy transactions
                    //See also the summary in TradeWindowPanel.cs
                    PlayerInventoryManager.Instance.player.playerMoney += panel.Value;

                    //Add the given item to the player's cargo hold
                    PlayerInventoryManager.Instance.player.cargoHold[panel.item] += panel.quantityToBuy;

                    //Update the player's cargo space usage
                    PlayerInventoryManager.Instance.player.cargoSpaceInUse += panel.quantityToBuy * panel.item.cargoVolume;

                    Debug.Log("Remaining currency: " + PlayerInventoryManager.Instance.player.playerMoney);

                    panel.ResetUI();
                    PlayerInventoryManager.Instance.ReloadInventoryReadout();
                    return true;
                }
                else //The player doesn't have space for the new items
                {
                    //NOTE: this should never display, as it should be handled elsewhere.
                    Debug.Log("Not enough cargo space!" +
                    "\nThis exception should have been handled in TradeQuantityAdjustButton!");
                }
            }
            else //The player doesn't have enough money to afford the purchase
            {
                //give feedback -- not enough money
                Debug.Log("Not enough money!");
            }
        }
        else if(panel.tradeType == TradeType.playerSell) //player is *selling* something
        {
            if (PlayerInventoryManager.Instance.player.cargoHold[panel.item]
                >= panel.quantityToBuy) //if the player actually has the item quantity they wish to sell
            {
                //Give the player the money
                PlayerInventoryManager.Instance.player.playerMoney += panel.Value;

                //Subtract the appropriate volume from the player's cargo hold
                PlayerInventoryManager.Instance.player.cargoHold[panel.item] -= panel.quantityToBuy;

                //Update the player's cargo space usage
                PlayerInventoryManager.Instance.player.cargoSpaceInUse -= panel.quantityToBuy * panel.item.cargoVolume;

                Debug.Log("Current currency total: " + PlayerInventoryManager.Instance.player.playerMoney);

                panel.ResetUI();
                PlayerInventoryManager.Instance.ReloadInventoryReadout();
                return true;
            }
            else //the player doesn't have what they want to sell
            { //NOTE: this should never display, as it should be handled elsewhere.
                Debug.Log("You don't have enough " + panel.item.itemName + "!" +
                    "\nThis exception should have been handled in TradeQuantityAdjustButton!");
            }
        }

        return false;
    }

    public void ToggleConfirmationWindow(/*TradeUI tradeWindow /*, ConfirmationWindow confirmationWindow*/)
    {
        confirmationWindow.gameObject.SetActive(!confirmationWindow.gameObject.activeInHierarchy);
    }

    /*public void OpenConfirmationWindow(TradeWindowPanel panel) //not sure what I was gonna do with this lol ~QP
    {

    }*/

    public void ToggleTradeUI(TradeUI tradeWindow)
    {
        confirmationWindow.gameObject.SetActive(false);
        tradeWindow.gameObject.SetActive(!tradeWindow.gameObject.activeInHierarchy);
    }
}
