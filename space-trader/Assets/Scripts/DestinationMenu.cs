using UnityEngine;
using UnityEngine.UI;

public class DestinationMenu : MonoBehaviour
{
    public GameObject destinationMenu; // Reference to the destination menu panel
    public Button Alajuela;
    public Button Cartago;
    public Button Heredia;
    public Button Guanacaste;
    public Button Puntarenas;

    private System.Action<Transform> onDestinationSelected; // Callback for destination selection

    private void Awake()
    {
        destinationMenu.SetActive(false);

        Alajuela.onClick.AddListener(() => SelectDestination(Alajuela.transform));
        Cartago.onClick.AddListener(() => SelectDestination(Cartago.transform));
        Heredia.onClick.AddListener(() => SelectDestination(Heredia.transform));
        Guanacaste.onClick.AddListener(() => SelectDestination(Guanacaste.transform));
        Puntarenas.onClick.AddListener(() => SelectDestination(Puntarenas.transform));
    }

    // Show the destination menu
    public void ShowDestinationMenu()
    {
        destinationMenu.SetActive(true);
    }

    // Hide the destination menu
    public void HideDestinationMenu()
    {
        destinationMenu.SetActive(false);
    }

    // Set the callback for when a destination is selected
    public void SetDestinationSelectedCallback(System.Action<Transform> callback)
    {
        onDestinationSelected = callback;
    }

    // Select a destination and invoke the callback
    private void SelectDestination(Transform destination)
    {
        if (onDestinationSelected != null)
        {
            onDestinationSelected(destination);
        }
        HideDestinationMenu();
    }
}
