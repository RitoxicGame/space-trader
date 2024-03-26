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
            System.Math.Abs(panel.Value * panel.quantityToBuy) +
            " in-game currency");

        if (panel.tradeType == TradeType.playerBuy) //if the player is trying to buy something
        {
            if (PlayerInventoryManager.Instance.player.playerMoney > panel.Value) //if the player has enough money
            {
                if (PlayerInventoryManager.Instance.player.cargoSpaceInUse //if the current cargo volume...
                    + (panel.quantityToBuy * panel.item.cargoVolume) //...plus the volume of items the player is attempting to buy...
                    <= PlayerInventoryManager.Instance.player.ship.cargoSpace) //...is no greater than the ship's cargo capacity...
                {
                    //Subtract cost from player money
                    //(NOTE: panel.Value will **always be NEGATIVE** for TradeType.playerBuy transactions
                    //See also the summary in TradeWindowPanel.cs
                    PlayerInventoryManager.Instance.player.playerMoney += panel.Value;

                    //Add the given item to the player's cargo hold
                    PlayerInventoryManager.Instance.player.cargoHold[panel.item] += panel.quantityToBuy * panel.item.cargoVolume;

                    //Update the player's cargo space usage
                    PlayerInventoryManager.Instance.player.cargoSpaceInUse += panel.quantityToBuy * panel.item.cargoVolume;
                }
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
