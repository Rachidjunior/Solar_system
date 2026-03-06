using UnityEngine;

public class SolarSystemMover : MonoBehaviour
{
    [Header("Configuration")]
    public Vector3 defaultPosition = Vector3.zero;

    void Awake()
    {
        Debug.Log("[SolarSystemMover] Awake OK");
    }

    public void ResetPosition()
    {
        transform.position = defaultPosition;
        Debug.Log("[SolarSystemMover] Reset Position → " + defaultPosition);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}