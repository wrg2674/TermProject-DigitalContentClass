using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Slime slime;
    public List<GameObject> rewards;
    private int level = 1;
    public int step
    {
        get
        {
            return level;
        }
        set
        {
            int preLevel = level;
            
            if(preLevel != value)
            {
                level = value;
            }

        }
    }
    public void Update()
    {
        level = slime.affection / 10;
    }
    public void LevelUp()
    {
        rewards[level].SetActive(true);
    }
}
