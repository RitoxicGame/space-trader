using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TravelConfirmationPanelController : MonoBehaviour
{
    public TextMeshProUGUI costText;
    public TextMeshProUGUI nameText;
    public Button yesButton;
    public Button noButton;
    public GameObject panelGameObject;

    private Action onConfirmAction;
    private Action onCancelAction;

    private void Awake()
    {
        panelGameObject.SetActive(false);

        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);
    }

    public void ShowConfirmation(String planetName, int cost, Action onConfirm, Action onCancel)
    {
        nameText.text = $"Travel to: {planetName}?";
        costText.text = $"Cost: {cost}";
        onConfirmAction = onConfirm;
        onCancelAction = onCancel;
        panelGameObject.SetActive(true);
        
    }

    private void OnYesClicked()
    {
        onConfirmAction?.Invoke();
        panelGameObject.SetActive(false);
    }

    private void OnNoClicked()
    {
        onCancelAction?.Invoke();
        panelGameObject.SetActive(false);
    }
}
