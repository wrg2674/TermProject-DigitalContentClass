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
    private int level = 0;
    private int equipIdx = 0;
    private float sizeWeight = 0.75f;
    
    public Material cleanMaterial;
    public Material dirtyMaterial;
    public Gauge cleanGauge;
    public Gauge satietyGauge;
    public Gauge maxCleanGauge;
    public Gauge maxSatietyGauge;
    public List<GameObject> rewardsEnv;
    public List<GameObject> equipments;
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
        this.transform.localScale = new Vector3(size* sizeWeight, size* sizeWeight, size* sizeWeight);
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
        cleanGauge.SettingLine(clean);
        satietyGauge.SettingLine(satiety);
        maxCleanGauge.SettingLine(1.0f);
        maxSatietyGauge.SettingLine(1.0f);
    }
    private void Update()
    {
        timerFunction(ref hungryTimer, ref satietyPoint, 0.05f, 20.0);
        timerFunction(ref dirtyTimer, ref cleanPoint, 0.03f, 35.0);
        size = satiety * 2 + 0.5f;
        updateColor();
        updateScale();
        cleanGauge.SettingLine(cleanPoint);
        satietyGauge.SettingLine(satiety);

    }
    public float clean
    {
        get
        {
            return cleanPoint;
        }
        set
        {
            cleanPoint = value;
            if (cleanPoint > 1.0f)
            {
                cleanPoint = 1.0f;
            }
            if (cleanPoint < 0.0f)
            {
                cleanPoint = 0.0f;
            }
            
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
            step = affectionPoint / 1;
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
            satietyPoint = value;
            if (satietyPoint > 1.0f)
            {
                satietyPoint = 1.0f;
            }
            if (satietyPoint < 0.0f)
            {
                satietyPoint = 0.0f;
            }
            
            Debug.Log("포만감 : " + satiety);
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
            scalePoint = value;
            if (scalePoint > 3.0f)
            {
                scalePoint = 3.0f;
            }
            if (scalePoint < 0.5f)
            {
                scalePoint = 0.5f;
            }
            
        }
    }
    public int step
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
            if(equipIdx >= equipments.Count)
            {
                return;
            }
            if(level <= rewardsEnv.Count)
            {
                LevelUpEnv();
            }
            else
            {
                equipments[equipIdx].GetComponent<Equipment>().LevelUp(size* sizeWeight);
                if(equipments[equipIdx].GetComponent<Equipment>().isEnd == true)
                {
                    equipIdx++;
                }
            }

        }
    }
    public void LevelUpEnv()
    {
        rewardsEnv[level - 1].SetActive(true);
    }
}
