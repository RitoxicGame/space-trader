using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerShip")]

public class PlayerShip : ScriptableObject
{
    /// <summary>
    /// The icon representing the player's ship
    /// </summary>
    public Sprite shipIcon;

    /// <summary>
    /// The name of the player's ship
    /// </summary>
    public string shipName;

    /// <summary>
    /// YET TO BE IMPLEMENTED.
    /// Will determine travel time/cost
    /// </summary>
    public float shipSpeed;

    /// <summary>
    /// Amount of Volume a ship can carry
    /// </summary>
    public int shipCargoSpace;
}
