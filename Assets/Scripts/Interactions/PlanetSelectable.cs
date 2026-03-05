using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlanetSelectable : MonoBehaviour
{
    public PlanetView planetView;

    UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        if (interactable == null)
            interactable = gameObject.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();

        interactable.selectEntered.AddListener(OnSelected);
    }

    void OnSelected(SelectEnterEventArgs args)
    {
        Debug.Log("[XR] Planet selected: " + planetView.planet);

        // Signale au système central — pas de logique ici
        PlanetSelectionSystem.Instance?.SelectPlanet(planetView);
    }

    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSelected);
    }
}