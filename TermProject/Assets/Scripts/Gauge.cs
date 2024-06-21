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
        lineRenderer.startWidth = 0.3f;
        lineRenderer.endWidth = 0.3f;
        lineRenderer.positionCount = 2;
    }

    public void SettingLine(float weight)
    {
        Vector3 startPoint = startPos.transform.position;
        weight += 0.00013f;
        Debug.Log(this.transform.name + " weight : " + weight);
        Vector3 endPoint = startPos.transform.position*(1.0f-weight) + endPos.transform.position*weight;
        Debug.Log("endPoint : " + endPoint);
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }
}
