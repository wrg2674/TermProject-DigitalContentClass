using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private float cleanPoint = 1.0f; // 청결도
    private int affectionPoint = 0; // 호감도
    private float satietyPoint = 0.25f; // 포만도
    private float scalePoint = 1.0f;
    private float hungryTimer = 0f;
    private float dirtyTimer = 0f;
    public Material cleanMaterial;
    public Material dirtyMaterial;
    public Gauge cleanGauge;
    public Gauge satietyGauge;
    public Gauge maxCleanGauge;
    public Gauge maxSatietyGauge;
    // Start is called before the first frame update
    public void updateColor()
    {
        float r = clean * cleanMaterial.color.r + (1 - clean) * dirtyMaterial.color.r;
        float g = clean * cleanMaterial.color.g + (1 - clean) * dirtyMaterial.color.g;
        float b = clean * cleanMaterial.color.b + (1 - clean) * dirtyMaterial.color.b;
        float a = clean * cleanMaterial.color.a + (1 - clean) * dirtyMaterial.color.a;
        this.GetComponent<Renderer>().material.color = new Color(r, g, b, a);
    }
    public void updateScale()
    {
        this.transform.localScale = new Vector3(size*0.75f, size*0.75f, size*0.75f);
    }
    private void timerFunction(ref float time, ref float key, float value, double period)
    {
        time += Time.deltaTime;
        if (time > period)
        {
            time = 0;
            key -= value;
        }
        if(key > 1.0f)
        {
            key = 1.0f;
        }
        if(key < 0.0f)
        {
            key = 0.0f;
        }
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        timerFunction(ref hungryTimer, ref satietyPoint, 0.05f, 20.0);
        timerFunction(ref dirtyTimer, ref cleanPoint, 0.03f, 35.0);
        size = satiety * 2 + 0.5f;
        updateColor();
        updateScale();
        cleanGauge.SettingLine(clean);
        satietyGauge.SettingLine(satiety);
        maxCleanGauge.SettingLine(1.0f);
        maxSatietyGauge.SettingLine(1.0f);
    }
    public float clean
    {
        get
        {
            return cleanPoint;
        }
        set
        {
            if (value > 1.0f)
            {
                value = 1.0f;
            }
            if (value < 0.0f)
            {
                value = 0.0f;
            }
            cleanPoint = value;
        }
    }

    public int affection
    {
        get
        {
            return affectionPoint;
        }
        set
        {
            affectionPoint = value;
        }
    }
    public float satiety
    {
        get
        {
            return satietyPoint;
        }
        set
        {
            if (value > 1.0f)
            {
                value = 1.0f;
            }
            if (value < 0.0f)
            {
                value = 0.0f;
            }
            satietyPoint = value;
        }
    }
    public float size
    {
        get
        {
            return scalePoint;
        }
        set
        {
            if (value > 3.0f)
            {
                value = 3.0f;
            }
            if (value < 0.5f)
            {
                value = 0.5f;
            }
            scalePoint = value;
        }
    }
}
