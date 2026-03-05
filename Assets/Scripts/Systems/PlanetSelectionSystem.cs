using UnityEngine;
using System;

public class PlanetSelectionSystem : MonoBehaviour  // ← nom exact
{
    public static PlanetSelectionSystem Instance { get; private set; }

    public event Action<PlanetView> OnPlanetSelected;

    PlanetView activePlanet;

    void Awake()
    {
        Instance = this;
    }

    public void SelectPlanet(PlanetView planet)
    {
        activePlanet = planet;
        Debug.Log("[SELECTION] Active planet: " + planet.planet);

        OnPlanetSelected?.Invoke(activePlanet);
    }

    public PlanetView GetActivePlanet() => activePlanet;
}