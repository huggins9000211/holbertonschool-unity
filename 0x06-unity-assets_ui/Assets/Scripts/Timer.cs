using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour
{
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Tick", 0.01f, 0.01f);
    }

    public void StopRepp()
    {
        CancelInvoke("Tick");
    }

    public void StartRepp()
    {
        InvokeRepeating("Tick", 0.01f, 0.01f);
    }
    void Tick()
    {
        DateTime current = DateTime.ParseExact(timerText.text, "m:ss.ff", null);
        current = current.AddSeconds(0.01);
        timerText.text = current.ToString("m:ss.ff");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
