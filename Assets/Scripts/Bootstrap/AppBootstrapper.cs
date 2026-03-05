using UnityEngine;
using System;

public class AppBootstrapper : MonoBehaviour
{
    public SolarSystemConfig config;
    public PlanetView[] planets;
    public TimeController timeController;
    public OrbitRenderer[] orbits;   // ← nouveau tableau d'orbites

    TimeModel timeModel;
    PlanetSystemController controller;
    IPlanetEphemerisService ephemeris;  // ← stocké pour les orbites

    void Start()
    {
        Debug.Log("[BOOT] Initializing application");

        // 1. Créer le modèle
        timeModel = new TimeModel();

        // 2. Créer le service — stocké dans le champ de classe
        ephemeris = new PlanetEphemerisService();

        // 3. Créer le controller
        controller = new PlanetSystemController(
            timeModel,
            ephemeris,
            planets
        );

        // 4. Démarrer le TimeController
        timeController.Init(timeModel);

        // 5. Dessiner les orbites
        DrawAllOrbits();

        Debug.Log("[BOOT] Done — Planets: " + planets.Length);
    }

    void DrawAllOrbits()
    {
        if (orbits == null) return;   // sécurité si pas assigné

        foreach (var orbit in orbits)
        {
            orbit.DrawOrbit(ephemeris, DateTime.Now);
        }

        Debug.Log("[BOOT] Orbits drawn: " + orbits.Length);
    }
}