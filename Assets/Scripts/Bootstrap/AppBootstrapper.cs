using UnityEngine;
using System;

public class AppBootstrapper : MonoBehaviour
{
    public SolarSystemConfig config;
    public PlanetView[] planets;
    public TimeController timeController;  // ← nouveau champ public

    TimeModel timeModel;
    PlanetSystemController controller;

    void Start()
    {
        Debug.Log("[BOOT] Initializing application");

        // 1. Créer le modèle
        timeModel = new TimeModel();

        // 2. Créer le service
        var ephemeris = new PlanetEphemerisService();

        // 3. Créer le controller (s'abonne à OnTimeChanged)
        controller = new PlanetSystemController(
            timeModel,
            ephemeris,
            planets
        );

        // 4. Démarrer le TimeController
        timeController.Init(timeModel);  // ← connecte le TimeController au modèle

        Debug.Log("[BOOT] Done — Planets: " + planets.Length);
    }
}