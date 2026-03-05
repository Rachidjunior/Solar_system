using UnityEngine;

public class PlanetView : MonoBehaviour
{
    public PlanetData.Planet planet;
    public float displaySize = 0.5f;   // taille visuelle dans la scène

    void Start()
    {
        transform.localScale = Vector3.one * displaySize;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }
}