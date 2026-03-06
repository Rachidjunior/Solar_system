using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Références UI")]
    public TextMeshProUGUI dateDisplay;
    public Button btnPlayPause;
    public Button btnSpeed1;
    public Button btnSpeed10;
    public Button btnSpeed100;
    public Button btnToggleOrbits;
    public Button btnResetView;
    public Button btnResetScale;

    [Header("Références Systèmes")]
    public TimeController timeController;
    public ScaleController scaleController;
    public OrbitRenderer[] orbitRenderers;
    public SolarSystemMover solarSystemMover;

    private bool _isPlaying = true;
    private bool _orbitsVisible = true;

    void Start()
    {
        btnPlayPause.onClick.AddListener(OnPlayPause);
        btnSpeed1.onClick.AddListener(() => OnSetSpeed(1f));
        btnSpeed10.onClick.AddListener(() => OnSetSpeed(10f));
        btnSpeed100.onClick.AddListener(() => OnSetSpeed(100f));
        btnToggleOrbits.onClick.AddListener(OnToggleOrbits);
        btnResetView.onClick.AddListener(OnResetView);
        btnResetScale.onClick.AddListener(OnResetScale);

        Debug.Log("[UI] UIController initialisé");
    }

    void Update()
    {
        if (timeController != null)
            dateDisplay.text =  timeController.GetCurrentDate();
    }

    void OnPlayPause()
    {
        _isPlaying = !_isPlaying;

        if (timeController != null)
            timeController.SetPaused(!_isPlaying);

        btnPlayPause.GetComponentInChildren<TextMeshProUGUI>().text =
            _isPlaying ? "⏸ Pause" : "▶ Play";

        Debug.Log("[UI] PlayPause → " + (_isPlaying ? "Play" : "Pause"));
    }

    void OnSetSpeed(float speed)
    {
        if (timeController != null)
            timeController.SetSpeed(speed);

        Debug.Log("[INPUT] Scale requested x" + speed);
    }

    void OnToggleOrbits()
    {
        _orbitsVisible = !_orbitsVisible;

        foreach (var orbit in orbitRenderers)
        {
            if (orbit != null)
                orbit.SetVisible(_orbitsVisible);
        }

        btnToggleOrbits.GetComponentInChildren<TextMeshProUGUI>().text =
            _orbitsVisible ? "Orbites ON" : "Orbites OFF";

        Debug.Log("[UI] Orbites → " + (_orbitsVisible ? "ON" : "OFF"));
    }

    void OnResetView()
    {
        if (solarSystemMover != null)
            solarSystemMover.ResetPosition();

        Debug.Log("[XR] Reset Vue");
    }

    void OnResetScale()
    {
        if (scaleController != null)
            scaleController.ResetScale();

        Debug.Log("[XR] Reset Echelle");
    }
}