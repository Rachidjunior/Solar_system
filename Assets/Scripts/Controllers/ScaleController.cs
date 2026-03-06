using UnityEngine;

public class ScaleController : MonoBehaviour
{
    [Header("Configuration")]
    public float defaultScale = 1f;
    public float minScale = 0.1f;
    public float maxScale = 5f;

    private float _currentScale = 1f;

    void Awake()
    {
        _currentScale = defaultScale;
        Debug.Log("[ScaleController] Awake OK");
    }

    public void ScaleUp()
    {
        _currentScale = Mathf.Clamp(_currentScale + 0.1f, minScale, maxScale);
        ApplyScale();
    }

    public void ScaleDown()
    {
        _currentScale = Mathf.Clamp(_currentScale - 0.1f, minScale, maxScale);
        ApplyScale();
    }

    public void ResetScale()
    {
        _currentScale = defaultScale;
        ApplyScale();
        Debug.Log("[ScaleController] Reset Scale");
    }

    public float GetCurrentScale()
    {
        return _currentScale;
    }

    void ApplyScale()
    {
        transform.localScale = Vector3.one * _currentScale;
        Debug.Log("[ScaleController] Scale → " + _currentScale);
    }
}