using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public Button portalButton; // Button associated with the portal
    public DestinationMenu destinationMenu; // Reference to the destination menu
    public Transform rocketShip; // Reference to the rocket ship's transform
    public float transitionDuration = 1f; // Duration of the transition in seconds

    private Coroutine teleportCoroutine; // Coroutine reference for teleportation
    private RectTransform selectedDestination; // Selected destination portal

    private void Start()
    {
        // Subscribe to the button's onClick event
        if (portalButton != null)
        {
            portalButton.onClick.AddListener(OpenDestinationMenu);
        }
    }

    // Function to open the destination menu
    private void OpenDestinationMenu()
    {
        // Show the destination menu
        destinationMenu.ShowDestinationMenu();

        // Set the callback for when a destination is selected
        destinationMenu.SetDestinationSelectedCallback(OnDestinationSelected);
    }

    private void OnDestinationSelected(Transform transform)
    {
        throw new NotImplementedException();
    }

    // Callback for when a destination is selected from the menu
    private void OnDestinationSelected(RectTransform destination)
    {
        selectedDestination = destination;
        // Start the teleportation sequence
        StartTeleportSequence();
    }

    // Function to start the teleportation sequence
    private void StartTeleportSequence()
    {
        // Stop any ongoing teleport coroutine
        if (teleportCoroutine != null)
        {
            StopCoroutine(teleportCoroutine);
        }

        if (selectedDestination != null)
        {
            // Start the teleportation sequence coroutine
            teleportCoroutine = StartCoroutine(TeleportSequence(rocketShip, selectedDestination.position));
        }
        else
        {
            Debug.LogWarning("Selected destination is null. Teleportation failed.");
        }
    }

    // Coroutine for the teleportation sequence
    private IEnumerator TeleportSequence(Transform objectToTeleport, Vector3 targetPosition)
    {
        // Move towards the destination portal first
        yield return MoveTowardsDestination(objectToTeleport, targetPosition);

        // Teleport the object to the destination
        TeleportObject(objectToTeleport, targetPosition);
    }

    // Coroutine for moving towards the destination portal
    private IEnumerator MoveTowardsDestination(Transform objectToMove, Vector3 targetPosition)
    {
        Vector3 initialPosition = objectToMove.position;
        float startTime = Time.time;

        // Perform the transition towards the destination over time
        while (Time.time - startTime < transitionDuration)
        {
            float progress = (Time.time - startTime) / transitionDuration;
            objectToMove.position = Vector3.Lerp(initialPosition, targetPosition, progress);
            yield return null;
        }

        // Ensure the object reaches the destination position
        objectToMove.position = targetPosition;
    }

    // Function to teleport the object to the destination point
    private void TeleportObject(Transform objectToTeleport, Vector3 targetPosition)
    {
        // Perform instant teleportation to the destination
        objectToTeleport.position = targetPosition;

        // Reset the coroutine reference
        teleportCoroutine = null;
    }
}
