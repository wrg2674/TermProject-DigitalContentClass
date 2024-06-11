using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    public GameObject startPos;
    public GameObject endPos;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetWidth(0.3f, 0.3f);
        lineRenderer.positionCount = 2;
    }

    public void SettingLine(float weight)
    {
        Vector3 startPoint = startPos.transform.position;
        Vector3 endPoint = startPos.transform.position*(1-weight) + endPos.transform.position*weight;

        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }
}
