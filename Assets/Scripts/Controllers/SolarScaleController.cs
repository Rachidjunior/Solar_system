using UnityEngine;

public class SolarScaleController : MonoBehaviour  // ← renommé
{
    [Header("Références")]
    public Transform solarSystemRoot;

    [Header("Limites")]
    public float minScale = 0.1f;
    public float maxScale = 5f;

    [Header("Valeur courante")]
    public float currentScale = 1f;

    void Start()
    {
        ApplyScale(currentScale);
    }

    public void SetScale(float value)
    {
        Debug.Log("[INPUT] Scale requested: " + value);

        float clamped = Mathf.Clamp(value, minScale, maxScale);

        if (clamped != value)
            Debug.LogWarning("[WARN] Scale clamped: " + value + " → " + clamped);

        currentScale = clamped;
        ApplyScale(currentScale);

        Debug.Log("[XR] Scale applied: " + currentScale);
    }

    public void ScaleUp()   => SetScale(currentScale + 0.1f);
    public void ScaleDown() => SetScale(currentScale - 0.1f);

    void ApplyScale(float scale)
    {
        if (solarSystemRoot != null)
            solarSystemRoot.localScale = Vector3.one * scale;
    }
}