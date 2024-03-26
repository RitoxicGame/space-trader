using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    /// <summary>
    /// Singleton player inventory manager instance
    /// </summary>
    public static PlayerInventoryManager Instance;

    /// <summary>
    /// Instance holding data for the player's ship, cargo, and money
    /// </summary>
    public PlayerShipAndInventory player;

    //List of Agents the player has at their disposal goes here

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
