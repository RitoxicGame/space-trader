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

    public void CompleteTransaction(TradeWindowPanel panel)
    {
        Debug.Log((panel.tradeType == TradeType.playerSell ? "Giving player " : "Charging player ") +
            System.Math.Abs(panel.Value * panel.quantityToBuy) +
            " in-game currency");
        //inventory implementation goes here
    }

    public void ToggleConfirmationWindow(/*TradeUI tradeWindow /*, ConfirmationWindow confirmationWindow*/)
    {
        confirmationWindow.gameObject.SetActive(!confirmationWindow.gameObject.activeInHierarchy);
    }

    public void OpenConfirmationWindow(TradeWindowPanel panel)
    {

    }

    public void ToggleTradeUI(TradeUI tradeWindow)
    {
        confirmationWindow.gameObject.SetActive(false);
        tradeWindow.gameObject.SetActive(!tradeWindow.gameObject.activeInHierarchy);
    }
}
