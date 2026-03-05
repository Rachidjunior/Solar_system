using UnityEngine;
using System;

public class AppBootstrapper : MonoBehaviour
{
    public SolarSystemConfig config;
    public PlanetView[] planets;
    public TimeController timeController;
    public OrbitRenderer[] orbits;
    public FocusController focusController;   // ← AJOUT : référence au FocusController

    TimeModel timeModel;
    PlanetSystemController controller;
    IPlanetEphemerisService ephemeris;

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

        // 6. Passer le timeModel au FocusController
        // AJOUT : FocusController a besoin de timeModel pour afficher
        // la date simulée dans le panel UI. TimeModel est une classe C# pure
        // donc il ne peut pas être assigné via l'Inspecteur — on le passe ici.
        if (focusController != null)
            focusController.timeModel = timeModel;

        Debug.Log("[BOOT] Done — Planets: " + planets.Length);
    }

    void DrawAllOrbits()
    {
        if (orbits == null) return;

        foreach (var orbit in orbits)
        {
            orbit.DrawOrbit(ephemeris, DateTime.Now);
        }

        Debug.Log("[BOOT] Orbits drawn: " + orbits.Length);
    }
}