using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TradeManager: MonoBehaviour
{
    public static TradeManager Instance;

    [SerializeField] public TravelManager travelManager;
    [SerializeField] TradeUI tradeWindow;

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
        tradeWindow.gameObject.SetActive(false);
        //I might be stupid lol
        /*planets = travelManager.gameObject.GetComponentsInChildren<Planet>();
        foreach (Planet market in planets)
        {
            planetas[market] = market.get;
        }*/
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/

    public void DisplayCurrentMarket()
    {

    }

    public void DisplayConfirmation()
    {

    }

    public void ToggleTradeUI()
    {
        tradeWindow.gameObject.SetActive(!tradeWindow.gameObject.activeInHierarchy);
    }
}
