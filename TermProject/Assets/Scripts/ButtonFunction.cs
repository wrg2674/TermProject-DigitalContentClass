using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    public Slime slime;
    public Button btnShower;
    private void Update()
    {
        if(slime.clean < 0.5f)
        {
            btnShower.interactable = true;
        }
        else
        {
            btnShower.interactable = false;
        }
    }
    public void Shower()
    {
        slime.clean = 1.0f;
        slime.affection += 1;
    }
    
    public void Eat()
    {
        slime.clean -= 0.02f;
        slime.satiety += 0.1f;
        slime.affection += 1;
    }
}
