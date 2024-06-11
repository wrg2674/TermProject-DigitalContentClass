using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedScript : BasedScript
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
    public override void Do()
    {
        slime.clean -= 0.02f;
        slime.satiety += 0.1f;
        slime.affection += 1;
    }
}
