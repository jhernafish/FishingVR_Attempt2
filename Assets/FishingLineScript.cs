using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public Transform rodTip;
    public Transform hookPoint;

    private LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.SetPosition(0, rodTip.position);
        lineRenderer.SetPosition(1, hookPoint.position);
    }
}