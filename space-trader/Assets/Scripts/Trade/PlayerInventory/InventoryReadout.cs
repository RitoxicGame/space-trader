using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryReadout : MonoBehaviour
{
    public static InventoryReadout Instance;
    public TextMeshProUGUI inventoryReadout;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        inventoryReadout = GetComponent<TextMeshProUGUI>();
    }

    //public static TextMeshProUGUI GetInventoryReadout() { return inventoryReadout; }
}
