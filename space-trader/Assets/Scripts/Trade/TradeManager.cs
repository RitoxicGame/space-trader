using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeManager: MonoBehaviour
{
    public static TradeManager Instance;

    [SerializeField] TravelManager travelManager;
    [SerializeField] GameObject tradeWindow;
    //[SerializeField] Planet[] planets;

    //private Dictionary<Planet, PlanetMarketInstance> planetas;

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

    public void displayCurrentMarket()
    {

    }
}
