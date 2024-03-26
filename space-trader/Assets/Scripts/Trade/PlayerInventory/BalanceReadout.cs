using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalanceReadout : MonoBehaviour
{
    public static BalanceReadout Instance;
    public TextMeshProUGUI balanceReadout;

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
        balanceReadout = GetComponent<TextMeshProUGUI>();
    }

    //public TextMeshProUGUI GetBalanceReadout() { return balanceReadout; }
}
