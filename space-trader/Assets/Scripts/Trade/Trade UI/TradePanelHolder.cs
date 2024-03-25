using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Implementation *heavily* inspired by that which was used in Apply to the Industry Simulator, coded chiefly by Rob Reddick and Eduardo Escudero

public class TradePanelHolder : MonoBehaviour
{
    public GameObject panel;
    public WindowType windowType;
    private ISelectionWindow selectionWindow;

    private void OnEnable()
    {
        selectionWindow = SelectWindowType.ChooseWindowType(windowType);
        selectionWindow.LoadData();
        GridLayoutGroup layout = GetComponentInChildren<GridLayoutGroup>();
        selectionWindow.DisplayPanels(layout, panel);
    }

    private void OnDisable()
    {
        GridLayoutGroup layout = GetComponentInChildren<GridLayoutGroup>();
        for (int i = 0; i < layout.transform.childCount; i++)
        {
            Destroy(layout.transform.GetChild(i).gameObject);
        }
    }
}
