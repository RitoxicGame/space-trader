using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMarket : MonoBehaviour
{
    //Market value shenanigans
    [SerializeField] MarketPostingPurchase[] planetBuys;
    [SerializeField] MarketPostingSale[] planetSells;

    //To be implemented
    //[SerializeField] Agent assignedAgent;

    //Including a ref back to the planet, just in case
    [SerializeField] Planet planeta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
