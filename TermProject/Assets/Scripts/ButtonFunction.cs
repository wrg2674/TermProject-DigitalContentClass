using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    public Slime slime;
    public Button btnShower;
    public Button btnTalk;
    public Button btnFeed;
    public Button btnStopTalk;
    public Text txtAffection;
    public MicrophoneClass microphone;
    public Transform pos;
    public ParticleSystem showerEffect;
    public GameObject feedEffect;
    
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
        if (slime.satiety < 1.0f)
        {
            btnFeed.interactable = true;
        }
        else
        {
            btnFeed.interactable = false;
        }
        txtAffection.text = slime.affection.ToString();
    }
    public void Talk()
    {
        btnTalk.gameObject.SetActive(false);
        btnStopTalk.gameObject.SetActive(true);
        if (microphone.checkMicrophoneDevice())
        {
            microphone.microphoneStart();
        }
        slime.satiety -= 0.2f;
        slime.affection += 1;

    }
    public void StopTalk()
    {
        btnTalk.gameObject.SetActive(true);
        btnStopTalk.gameObject.SetActive(false);
        if (microphone.checkMicrophoneDevice())
        {
            microphone.microphoneStop();
        }
    }
    public void Shower()
    {
        slime.clean = 1.0f;
        slime.affection += 1;
        slime.satiety -= 0.3f;
        GameObject obj = Instantiate(showerEffect).gameObject;
        obj.transform.position = pos.position;
    }
    
    public void Eat()
    {
        slime.clean -= 0.02f;
        slime.satiety += 0.1f;
        slime.affection += 1;
        GameObject obj = Instantiate(showerEffect).gameObject;
        obj.transform.position = pos.position;
    }
}
