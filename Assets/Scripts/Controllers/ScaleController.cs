using UnityEngine;

public class ScaleController : MonoBehaviour
{
    [Header("Références")]
    public Transform solarSystemRoot;

    [Header("Limites")]
    public float minScale = 0.1f;
    public float maxScale = 5f;
    public float defaultScale = 1f;

    private float _currentScale = 1f;

    void Start()
    {
        SetScale(defaultScale);
    }

    public void SetScale(float value)
    {
        Debug.Log("[INPUT] Scale requested: " + value);

        float clamped = Mathf.Clamp(value, minScale, maxScale);

        if (clamped != value)
            Debug.LogWarning("[WARN] Scale clamped: " + value + " → " + clamped);

        _currentScale = clamped;
        ApplyScale();

        Debug.Log("[XR] Scale applied: " + _currentScale);
    }

    public void ScaleUp()   => SetScale(_currentScale + 0.1f);
    public void ScaleDown() => SetScale(_currentScale - 0.1f);

    public void ResetScale()
    {
        SetScale(defaultScale);
        Debug.Log("[XR] Reset Echelle");
    }

    public float GetCurrentScale() => _currentScale;

    void ApplyScale()
    {
        if (solarSystemRoot != null)
            solarSystemRoot.localScale = Vector3.one * _currentScale;
    }
}