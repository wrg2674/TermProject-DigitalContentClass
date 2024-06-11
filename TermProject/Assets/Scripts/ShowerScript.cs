using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerScript : BasedScript
{
    public float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);  
    }
    public override void Do()
    {
        slime.clean = 1.0f;
        slime.affection += 1;
        slime.satiety -= 0.3f;
    }
}
