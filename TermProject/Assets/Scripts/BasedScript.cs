using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasedScript : MonoBehaviour
{
    protected Slime slime;
    public void SetSlime(Slime param)
    {
        this.slime = param;
    }
    private void OnDestroy()
    {
        Do();
    }

    public abstract void Do();
}
