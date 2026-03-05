using System;
using UnityEngine;

public class PlanetEphemerisService : IPlanetEphemerisService
{
    public Vector3 GetPlanetPosition(PlanetData.Planet planet, DateTime date)
    {
        Vector3 pos = PlanetData.GetPlanetPosition(planet, date);

        // Correction du système de coordonnées :
        // Astronomique (écliptique) → Unity
        // X → X  (identique)
        // Y → Z  (plan orbital horizontal dans Unity)
        // Z → Y  (inclinaison orbitale → légère hauteur dans Unity)
        return new Vector3(pos.x, pos.z, pos.y);
    }
}