using UnityEngine;
using System;

[RequireComponent(typeof(LineRenderer))]
public class OrbitRenderer : MonoBehaviour
{
    public PlanetData.Planet planet;
    public int samples = 100;       // nombre de points de l'orbite
    public float orbitDays = 365f;  // période à afficher

    LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.loop = true;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
    }

    public void DrawOrbit(IPlanetEphemerisService ephemeris, DateTime start)
    {
        Vector3[] points = new Vector3[samples];

        for (int i = 0; i < samples; i++)
        {
            DateTime t = start.AddDays(i * (orbitDays / samples));
            points[i] = ephemeris.GetPlanetPosition(planet, t);
        }

        lineRenderer.positionCount = samples;
        lineRenderer.SetPositions(points);
    }
}