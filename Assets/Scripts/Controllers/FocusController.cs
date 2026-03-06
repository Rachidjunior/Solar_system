using UnityEngine;
using TMPro;

public class FocusController : MonoBehaviour
{
    [Header("UI")]
    public GameObject infoPanel;
    public TextMeshProUGUI planetNameText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI periodText;
    public TextMeshProUGUI dateText;

    [Header("Références")]
    public TimeModel timeModel;

    PlanetView focusedPlanet;

    void Start()
    {
        infoPanel.SetActive(false);
        PlanetSelectionSystem.Instance.OnPlanetSelected += FocusOn;
        Debug.Log("[XR] FocusController initialisé");
    }

    public void FocusOn(PlanetView planet)
    {
        focusedPlanet = planet;
        Debug.Log("[XR] Focus sur : " + planet.planet);
        planet.transform.localScale = Vector3.one * planet.displaySize * 2f;
        infoPanel.SetActive(true);
        UpdateUI(planet);
    }

    void UpdateUI(PlanetView planet)
    {
        planetNameText.text = planet.planet.ToString();
        distanceText.text   = "Distance : " + GetDistance(planet.planet) + " UA";
        periodText.text     = "Periode : " + GetPeriod(planet.planet) + " jours";
        dateText.text       = "Date : " + timeModel?.CurrentTime.ToString("dd/MM/yyyy");

        Debug.Log("[XR] UI mise a jour pour : " + planet.planet);
    }

    float GetDistance(PlanetData.Planet p)
    {
        switch (p)
        {
            case PlanetData.Planet.Mercury: return 0.39f;
            case PlanetData.Planet.Venus:   return 0.72f;
            case PlanetData.Planet.Earth:   return 1.00f;
            case PlanetData.Planet.Mars:    return 1.52f;
            case PlanetData.Planet.Jupiter: return 5.20f;
            case PlanetData.Planet.Saturn:  return 9.58f;
            case PlanetData.Planet.Uranus:  return 19.2f;
            case PlanetData.Planet.Neptune: return 30.1f;
            default: return 0f;
        }
    }

    int GetPeriod(PlanetData.Planet p)
    {
        switch (p)
        {
            case PlanetData.Planet.Mercury: return 88;
            case PlanetData.Planet.Venus:   return 225;
            case PlanetData.Planet.Earth:   return 365;
            case PlanetData.Planet.Mars:    return 687;
            case PlanetData.Planet.Jupiter: return 4333;
            case PlanetData.Planet.Saturn:  return 10759;
            case PlanetData.Planet.Uranus:  return 30687;
            case PlanetData.Planet.Neptune: return 60190;
            default: return 0;
        }
    }

    void OnDestroy()
    {
        if (PlanetSelectionSystem.Instance != null)
            PlanetSelectionSystem.Instance.OnPlanetSelected -= FocusOn;

        Debug.Log("[XR] FocusController detruit");
    }
}